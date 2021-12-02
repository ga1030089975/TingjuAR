using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Android;
public class WebManager : SingletonUnity<WebManager>
{
    [HideInInspector]
    public UniWebView _webView;
    public GameObject prefab;
    private Texture2D captureImage;
    private string FileName;
    [HideInInspector]
    public string FilePath;
    string hmtlstring = "";
    string LocalBookKEY = "LocalBook";

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        readjson(Global.BookName);
    }

    public void LoadFromFile()
    {
        if (_webView != null)
        {
            return;
        }
        _webView = CreateWebView();
        StreamReader sr = new StreamReader(Global.LOCAL_RES_PATH + "/Home/start.html");
        hmtlstring = sr.ReadToEnd();
        sr.Close();
        Debug.Log("hmtlstring: " + hmtlstring + "  baseurl: " + " \"file://\" + Global.LOCAL_RES_PATH + \"/Home/");
        _webView.LoadHTMLString(hmtlstring, "file://" + Global.LOCAL_RES_PATH + "/Home/");
        //_webView.Load("http://114.214.170.35:3000");
        _webView.OnReceivedMessage += OnReceivedMessage;
        _webView.Show();
    }
   
    #region 用于android 生命周期内回调，确保unityplayeractivity生命周期正常。
    /// <summary>
    /// 显示webview
    /// </summary>
    public void showweb()
    {
        _webView.Show();
    }
    /// <summary>
    /// 隐藏webview
    /// </summary>
    public void hideweb()
    {
        _webView.Hide();
    }
    #endregion
    void OnReceivedMessage(UniWebView webView, UniWebViewMessage message)
    {
        if (message.path == "open")
        {

            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                 string folderToBeDeleted = Global.LOCAL_RES_PATH + "Home/" + Global.BookName[int.Parse(message.args["index"])] + "/" + Global.BookName[int.Parse(message.args["index"])] + ".unity3d";
                FileInfo files = new FileInfo(folderToBeDeleted);
                if (files.Exists)
                {
                    Global.BookIndex = int.Parse(message.args["index"]);
                    Global.NextSceneName = Global.BookName[int.Parse(message.args["index"])];
                    Application.LoadLevel("Loading");
                }
                else
                {
                    string code = "Return(\"" + Global.BookName[int.Parse(message.args["index"])] + "\")";
                    RunScript(code);
                    DeleteFolder(message.args["index"]);
                }
            }
            else
            {
                string code = "alert('您还没有开启相机权限，无法打开！请开启权限！');";
                RunScript(code);
            }

            
        }
        if (message.path == "getordown")
        {
            if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                message = getordownfunc(message, "name", "index", "size", "type");
            }
            else
            {
                string code = "alert('您还没有开启读写手机存储权限，无法下载！请开启权限！');";
                RunScript(code);
            }
            
        }
        if (message.path == "delete")
        {
            string sb = message.args["index"];
            string[] sbs = sb.Split('x');
            foreach (var item in sbs)
            {
                if (item != "0")
                {
                    if (this.transform.Find(item))
                    {
                        this.transform.Find(item).GetComponent<HTML5ResUpdate>().isDownLoad = false;
                        PlayerPrefs.SetInt(Global.BookName[int.Parse(item)] + "progressCache", 0);
                        DeleteFolder(item);
                    }
                }
            }
        }
        if (message.path == "cancle")
        {
            string BookIndex = message.args["index"];
            if (Global.BookName.ContainsKey(int.Parse(BookIndex)) == false)
            {
                //获取取消
                if (this.transform.Find(BookIndex))
                {
                    this.transform.Find(BookIndex).GetComponent<HTML5ResUpdate>().isDownLoad = false;
                    PlayerPrefs.SetInt(Global.BookName[int.Parse(BookIndex)] + "progressCache", 0);
                    DeleteFolder(BookIndex);
                }
            }else
            {
                //更新取消
                this.transform.Find(BookIndex).GetComponent<HTML5ResUpdate>().isDownLoad = false;
                PlayerPrefs.SetInt(Global.BookName[int.Parse(BookIndex)] + "progressCache", 0);
                this.transform.Find(BookIndex).GetComponent<HTML5ResUpdate>().close();
                Deletezip(BookIndex);
            }
        }
        if (message.path == "stoporstart")
        {
            this.transform.Find(message.args["suspendedindex"]).GetComponent<HTML5ResUpdate>().close();
            message = getordownfunc(message, "getordownname", "getordownindex", "getordownsize", "type");
        }
        if (message.path == "suspended")
        {
            this.transform.Find(message.args["index"]).GetComponent<HTML5ResUpdate>().close();
        }
        if (message.path == "restart")
        {
            WServer.instance.startWebsocket();
        }
        if (message.path == "photo")
        {
            reflash.instance.SavePhotoToGallery();
        }
        if (message.path == "changeLandscape")
        {
            if (Screen.orientation==ScreenOrientation.Portrait)
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
			StartCoroutine (testxuanzhuan());
            ChangeScreenResolution();
            if (message.args["AutoPlay"] == "AutoPlay")
            {
                if (Global.CanTimeLose == false)
                {
                    StartCoroutine(playvideo(message.args["name"]));
                }
            }
        }
        if (message.path == "changeAuto")
        {
#if UNITY_IPHONE || UNITY_IPAD
            GameObject.Find("HTML5Manager").GetComponent<Manager>().btn.SetActive(false);      
#endif
            Screen.orientation = ScreenOrientation.AutoRotation;
			Screen.autorotateToLandscapeLeft = true;
			Screen.autorotateToLandscapeRight = true;
			Screen.autorotateToPortrait = true;
			Screen.autorotateToPortraitUpsideDown = true;
            _webView.insets = new UniWebViewEdgeInsets(0, 0, 0, 0);
            GameObject.Find("camera").GetComponent<Camera>().backgroundColor = new Color32(255, 255, 255, 255);
            //更改屏幕比为原始比
        }
        if (message.path == "OpenUrl")
        {
#if UNITY_IPHONE || UNITY_IPAD
           GameObject.Find("HTML5Manager").GetComponent<Manager>().btn.SetActive(true); 
            _webView.insets = new UniWebViewEdgeInsets(50, 0, 0, 0);
            GameObject.Find("camera").GetComponent<Camera>().backgroundColor = new Color32(74, 74, 74, 255);
#endif
        }
    }
    IEnumerator playvideo(string videoname)
    {

#if UNITY_ANDROID
        hideweb();
        Global.showweb = true;
        string videopath = Global.LOCAL_RES_PATH + "Home/" + videoname;
#elif UNITY_IPHONE || UNITY_IPAD
		string videopath=Global.LOCAL_RES_URL+ "Home/"  + videoname;
#endif
        bool web = Handheld.PlayFullScreenMovie(videopath, Color.black, FullScreenMovieControlMode.Hidden);
        Handheld.StopActivityIndicator();
		yield return new WaitForSeconds(0.1f);
        Global.CanTimeLose = true;
        showweb ();
        Global.showweb = false;
        yield return new WaitForSeconds(0.1f);
        string Code = "GetDeviceId(\"" + SystemInfo.deviceUniqueIdentifier + "\")";
        RunScript(Code);
        yield return new WaitForSeconds(1f);
        Global.CanTimeLose = false;
    }
    

    //控制屏幕横屏
    IEnumerator testxuanzhuan()
	{
		yield return new WaitForSeconds (0.3f);
		Screen.orientation = ScreenOrientation.AutoRotation;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
	}
    void ChangeScreenResolution()
    {
        GameObject.Find("camera").GetComponent<Camera>().backgroundColor = new Color32(42, 42, 42, 255);
        int SideInset=0;
        if (Global.screenheight> Global.screenwidth)
        {
            SideInset = (Global.screenheight - Global.screenwidth / 3 * 4) / 2;
        }
        else
        {
            SideInset = (Global.screenwidth- Global.screenheight / 3 * 4) / 2;
        }
        _webView.insets = new UniWebViewEdgeInsets(0, SideInset, 0, SideInset);
    }
    /// <summary>
    /// 获取与更新
    /// </summary>
    /// <param name="message">UniWebViewMessage</param>
    /// <param name="name">书籍名</param>
    /// <param name="index">书籍代号</param>
    /// <param name="size">书籍尺寸param>
    /// <param name="type">书籍类型</param>
    /// <returns>UniWebViewMessage</returns>
    private UniWebViewMessage getordownfunc(UniWebViewMessage message, string name, string index, string size, string type)
    {
        Global.spaces = SDSpace.instance.returnHtml();
        if (Global.spaces < GetNumberInt(message.args[size]))
        {
            string code = "TipsRemain(\"" + message.args[name] + "\")";
            RunScript(code);
        }
        else
        {
            if (Global.BookName.ContainsKey(int.Parse(message.args[index])) == false)
            {
                StartCoroutine(GetVersionMessage(message.args[name], message.args[index], message.args[type]));
            }
            else
            {
                HTML5ResUpdate res = this.transform.Find(message.args[index]).GetComponent<HTML5ResUpdate>();
                res.DownLoadRes(message.args[type]);
            }
        }
        return message;
    }

    /// <summary>
    /// 正则表达式剔除HTML5书籍大小中非数字字符
    /// </summary>
    /// <param name="size">书籍大小</param>
    /// <returns>书籍大小</returns>
    float GetNumberInt(string size)
    {
        float result = 0;
        if (size != null && size != string.Empty)
        {
            size = Regex.Replace(size, @"[^\d.\d]", "");// 正则表达式剔除非数字字符（不包含小数点.）   
            if (Regex.IsMatch(size, @"^[+-]?\d*[.]?\d*$"))    // 如果是数字，则转换为decimal类型 
            {
                result = float.Parse(size);
            }
        }
        return result;
    }
   
    /// <summary>
    /// 获取书籍信息，生成场景载体，下载新增书籍Zip包，写入本地书籍字典，写入文件文本
    /// </summary>
    /// <param name="name">书名</param>
    /// <param name="index">书籍代号</param>
    /// <param name="booktype">书籍类型</param>
    /// <returns></returns>
    IEnumerator GetVersionMessage(string name, string index, string booktype)
    {
        Global.BookName.Add(int.Parse(index), name);
        InstantiateHTMLPrefab(int.Parse(index));
        yield return new WaitForSeconds(1f);
        this.transform.Find(index).GetComponent<HTML5ResUpdate>().DownLoadRes(booktype);
        writejson();
    }
  
    /// <summary>
    /// 根据书籍名删除文件夹
    /// </summary>
    /// <param name="bookIndex">书籍代号</param>
    public void DeleteFolder(string bookIndex)
    {
        string folderToBeDeleted = Global.LOCAL_RES_PATH + "Home/" + Global.BookName[int.Parse(bookIndex)] + "/";
        DirectoryInfo folder = new DirectoryInfo(folderToBeDeleted);
        if (folder.Exists)
        {
            folder.Delete(true);
            Global.BookName.Remove(int.Parse(bookIndex));
            writejson();
            Destroy(this.transform.Find(bookIndex));
        }
    }
  
    /// <summary>
    /// 根据书籍名删除文件zip包
    /// </summary>
    /// <param name="bookIndex">书籍代号</param>
    public void Deletezip(string bookIndex)
    {
        string ZipToBeDeleted = Global.LOCAL_RES_PATH + "Home/" + Global.BookName[int.Parse(bookIndex)] + ".zip";
        FileInfo File = new FileInfo(ZipToBeDeleted);
        if (File.Exists)
        {
            File.Delete();
        }
    }
  
    /// <summary>
    /// 根据书籍名，生成本地文件夹，生成场景中的书籍载体
    /// </summary>
    /// <param name="bookindex">书籍序号</param>
    public void InstantiateHTMLPrefab(int bookindex)
    {
        if (!Directory.Exists(Global.LOCAL_RES_PATH + "Home/" + Global.BookName[bookindex] + "/"))
        {
            Directory.CreateDirectory(Global.LOCAL_RES_PATH + "Home/" + Global.BookName[bookindex] + "/");
        }
        GameObject book = (GameObject)Instantiate(prefab);
        book.name = bookindex.ToString();
        book.transform.SetParent(this.transform);
        book.GetComponent<HTML5ResUpdate>().Startcheck();
    }
  
    /// <summary>
    /// 读取本地文件信息到本地书籍名称字典
    /// </summary>
    /// <param name="dict">书籍字典</param>
    public void readjson(Dictionary<int, string> dict)
    {
        string sb = PlayerPrefs.GetString(LocalBookKEY, "");
        if (sb == null || sb.Length == 0)
        {
            return;
        }
        string[] items = sb.Split(new char[] { '\n' });
        foreach (string item in items)
        {
            string[] info = item.Split(new char[] { ',' });
            if (info != null && info.Length == 2)
            {
                dict.Add(int.Parse(info[0]), info[1]);
                InstantiateHTMLPrefab(int.Parse(info[0]));
            }
        }
    }
  
    /// <summary>
    /// 将本地书籍名称字典写入本地文件
    /// </summary>
    public void writejson()
    {
        StringBuilder versions = new StringBuilder();
        foreach (var item in Global.BookName)
        {
            versions.Append(item.Key).Append(",").Append(item.Value).Append("\n");
        }
        PlayerPrefs.SetString(LocalBookKEY, versions.ToString());
    }
  
    /// <summary>
    /// 执行js脚本
    /// </summary>
    /// <param name="JSCode">传入js方法字符串</param>
    public void RunScript(string JSCode)
    {
        if (_webView == null)
        {
            return;
        }
        _webView.EvaluatingJavaScript(JSCode);
    }
  
    /// <summary>
    /// 创建uniwebview
    /// </summary>
    /// <returns></returns>
    UniWebView CreateWebView()
    {
        var webViewGameObject = GameObject.Find("WebView");
        if (webViewGameObject == null)
        {
            webViewGameObject = new GameObject("WebView");
        }
        var webView = webViewGameObject.AddComponent<UniWebView>();
        webView.toolBarShow = false;
        return webView;
    }
}
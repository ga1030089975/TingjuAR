using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Android;
public class DownloadManager : MonoBehaviour
{
    //int类
    int zipStep = 0;
    int DownloadStep = 0;
    int progress = 0;
    //MyHttp类
    MyHttp http = null;
    public List<MyHttp> https = new List<MyHttp>();
    public GameObject Tippanel;
    public GameObject userPanel;
    public GameObject privacyPanel;
    
    //string类变量
    string ServerVersionKEY = "ServerVersionKEY";
    string LocalVersionKEY = "LocalVersionKEY";
    List<string> NeedDownFiles = new List<string>();
    Dictionary<string, string> LocalResVersion = new Dictionary<string, string>();
    Dictionary<string, string> ServerResVersion = new Dictionary<string, string>();
    
    
    //bool类变量
    //用户是否同意协议
    private bool agree = false;
    bool zipsuccess = false;
    bool NeedUpdateLocalVersionFile = false;
    bool zips = true;
    bool CanDownload = true;
    
    // Start is called before the first frame update
    //start会对一些权限进行探测
    void Start()
    {
        CheckAgreement();
        CheckWritePermission();
        // yield return new WaitForSeconds(1);
        CheckCameraPermission();
        // Screen.orientation = ScreenOrientation.Portrait;
        // yield return new WaitForSeconds(3);
        // yield return StartCoroutine(CheckNet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 检查“同意用户协议和隐私协议”状态，已同意过：隐藏面板Tippanel，未同意过：激活面板Tippanel
    /// </summary>
    /// <returns></returns>
     public void CheckAgreement() {
        //if (PlayerPrefs.HasKey("同意用户协议和隐私协议"))
        if (false)
        {
            Tippanel.SetActive(false);
            agree = true;
        }
        else
        {
            Tippanel.SetActive(true);
        }
    }
    //检查读写权限
    private void CheckWritePermission()
    {
 
        if (!PlayerPrefs.HasKey("Write权限"))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            PlayerPrefs.SetInt("Write权限", 10);
        }
        
    }
    //检查摄像头权限
    private void CheckCameraPermission()
    {
        if (!PlayerPrefs.HasKey("Camera权限"))
        {
            Permission.RequestUserPermission(Permission.Camera);
            PlayerPrefs.SetInt("Camera权限", 10);
        }
    }
    // private IEnumerator CheckNet()
    // {
    //     if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
    //     {
    //         //Debug.Log("WiFi");
    //         StartCoroutine(DownLoad(Global.SERVER_RES_URL + "Home/" + "updateversion.json"));
    //     }
    //     if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork
    //         || Application.internetReachability == NetworkReachability.NotReachable)
    //     {
    //         //Debug.Log("网络不可用或者移动网络");
    //         if (PlayerPrefs.GetInt("first", 0) == 0)
    //         {
    //             StartCoroutine(DownLoad(Global.SERVER_RES_URL + "Home/" + "updateversion.json"));
    //             PlayerPrefs.SetInt("first", 1);
    //             //TODO 弹窗询问是否打开WiFi继续下载
    //         }
    //         else
    //         {
    //             yield return new WaitUntil(() => agree == true);
    //             sceneManager.LoadScene();
    //         }
    //     }
    // }

    IEnumerator CheckVersion()
    {
        yield return new WaitForSeconds(0.1f);
        string LocalVersionST = PlayerPrefs.GetString(LocalVersionKEY, "");
        string ServerVersionST = PlayerPrefs.GetString(ServerVersionKEY, "");
        // LocalResVersion = ParseVersionFile(LocalVersionST);
        // ServerResVersion = ParseVersionFile(ServerVersionST);
        CompareVersion();
        // yield return new WaitForSeconds(0.5f);
        // yield return StartCoroutine(CompareResult());
    }

//  private void UpdateLocalVersionFile()
//     {
//         string datas = JsonMapper.ToJson(ServerResVersion);
//         PlayerPrefs.SetString(LocalVersionKEY, datas);
//     }

private void CompareVersion()
    {
        foreach (var version in ServerResVersion)
        {
            string fileName = version.Key;
            string serverMd5 = version.Value;
            // if (!LocalResVersion.ContainsKey(fileName))
            // {
            //     NeedDownFiles.Add(fileName);
            // }
            // else
            // {
            //     string localMd5;
            //     LocalResVersion.TryGetValue(fileName, out localMd5);
            //     if (!serverMd5.Equals(localMd5))
            //     {
            //         NeedDownFiles.Add(fileName);
            //     }
            // }
        }
    }
    // private IEnumerator CompareResult()
    // {
    //     NeedUpdateLocalVersionFile = NeedDownFiles.Count > 0;
    //     if (NeedUpdateLocalVersionFile == false)
    //     {
    //         yield return new WaitUntil(() => agree == true);
    //         sceneManager.LoadScene();
    //     }
    //     else
    //     {
    //         for (int i = 0; i < NeedDownFiles.Count; i++)
    //         {
    //             https.Add(new MyHttp());
    //         }
    //         sceneManager.loadresobj.SetActive(true);
    //         word.SetActive(false);
    //         sceneManager.loadsceneobj.SetActive(false);
    //     }
    // }
     void DeleteFile(string path)
    {
        FileInfo file = new FileInfo(path);
        if (file.Exists) { file.Delete(); }
    }

    //更新本地的version配置
    // private Dictionary<string, string> ParseVersionFile(string content)
    // {
    //     if (content == null || content =="")
    //     {
    //         Dictionary<string, string> con = new Dictionary<string, string>();
    //         con.Add("defult", "defult");
    //         return con;
    //     }
    //     return JsonMapper.ToObject<Dictionary<string,string>>(content);
    // }



    //点击同意按钮：隐藏面板
    public void OnAgreeButton()
    {
        PlayerPrefs.SetInt("同意用户协议和隐私协议", 10);
        Tippanel.SetActive(false);
        agree = true;
    }
    //点击不同意按钮：退出程序
    public void OnDisagreeButton()
    {
        Tippanel.SetActive(false);
        Application.Quit();
    }
    //关闭用户协议界面
    public void OnUserPanelClosed()
    {
        userPanel.SetActive(false);
    }
    //关闭隐私政策界面
    public void OnPrivacyPanelClosed()
    {
        privacyPanel.SetActive(false);
    }

    





    
    /// <summary>
    /// 下载基础HTML5文件
    /// </summary>
    IEnumerator DownLoad(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        // else
        // {
        //     PlayerPrefs.SetString(ServerVersionKEY, www.text);
        // }
        // www.Dispose();
        // StartCoroutine(CheckVersion());
    }

    void FixedUpdate()
    {
        //传出下载进度，完成就解压
        // DownloadProcess();
        //解压完成就删除zip包
        UnZipFile();
        if (NeedUpdateLocalVersionFile)
        {
            DownLoadRes();
        }
    }
     void UnZipFile()
    {
        // if (zipsuccess == true)
        // {
        //     StartCoroutine(IEUnZipFile());
        // }
    }
    
    // IEnumerator IEUnZipFile()
    // {
    //     if (zips == true && zipStep < NeedDownFiles.Count)
    //     {
    //         zips = false;
    //         zips = zipopen.UnZipFile(Global.LOCAL_RES_PATH + NeedDownFiles[zipStep], Global.LOCAL_RES_PATH);
    //         zipStep += 1;
    //     }
    //     if (zipStep == NeedDownFiles.Count)
    //     {
    //         for (int i = 0; i < NeedDownFiles.Count; i++)
    //         {
    //             DeleteFile(Global.LOCAL_RES_PATH + NeedDownFiles[i]);
    //         }

    //         zipsuccess = false;
    //         UpdateLocalVersionFile();
    //         yield return new WaitUntil(() => agree == true);
    //         sceneManager.LoadScene();
    //     }
    // }

    //将下载并替换本地的资源 
    void DownLoadRes()
    {
        // if (DownloadStep < NeedDownFiles.Count)
        // {
        //     if (CanDownload)
        //     {
        //         CanDownload = false;
        //         https[DownloadStep].Download(Global.SERVER_RES_URL + "Home/" + Global.ServerThreeUrl + NeedDownFiles[DownloadStep], Global.LOCAL_RES_PATH);
        //     }
        //     int index = NeedDownFiles.Count - 1;
        //     bool sss = (int)https[index].progress == 100f;
        //     if ((int)https[index].progress == 100)
        //     {
        //         zipsuccess = true;
        //     }
        //     if ((int)https[DownloadStep].progress == 100)
        //     {          
        //         DownloadStep += 1;                
        //         CanDownload = true;
        //     }         
        // }
    }
    // private void DownloadProcess()
    // {
    //     if (NeedDownFiles.Count>0&& DownloadStep< NeedDownFiles.Count)
    //     {
    //         //float progress = Mathf.CeilToInt((DownloadStep + https[DownloadStep].progress / 100) * (100 / NeedDownFiles.Count));//
    //         progressBar.fillAmount = progress / 100f;
    //         loadres.text= progress + "%";
    //     }    
    // }
    
}

using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    GameObject parent;
    HTML5ResUpdate[] Childrens;
    public GameObject btn;
    void Start()
    {
       
        btn = GameObject.Find("Canvas/Button");
        btn.SetActive(false);
        Screen.orientation = ScreenOrientation.AutoRotation;
        parent = GameObject.Find("webview");
        WebManager.instance.LoadFromFile();
        if (parent.transform.childCount > 0)
        {
            Childrens = parent.GetComponentsInChildren<HTML5ResUpdate>();
            foreach (var item in Childrens)
            {
                item.Startcheck();
            }
            Global.hasBook = 1;
            StartCoroutine(NeedUpdateBook());
        }
        else
        {
            Global.hasBook = 0;
        }
        Global.spaces = SDSpace.instance.returnHtml();
    }
    /// <summary>
    /// 需要下载书籍的数量
    /// </summary>
    /// <returns></returns>
    IEnumerator NeedUpdateBook()
    {
        yield return new WaitForSeconds(1);
        string codeneedupdatebookcount = "NeedUpdateBooks(" + Global.hasBook + ")";
        WebManager.instance.RunScript(codeneedupdatebookcount);
    }
    void Update()
    {
        if ((bool)WebManager.instance._webView.show==false && Global.showweb == false)
        {
           StartCoroutine(WebViewShow());
        }
    }

    IEnumerator WebViewShow()
    {
        yield return new WaitForSeconds(1f);
        WebManager.instance._webView.Show();
    }
}

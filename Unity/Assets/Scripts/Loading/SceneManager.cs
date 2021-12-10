// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;

// public class SceneManager : MonoBehaviour
// {
//     public Text text;  //加载进度百分比，范围：0%~99%
//     public GameObject loadsceneobj;  //loading场景的画板loadscene
//     public GameObject loadresBG;  //unity中没有赋值
//     public GameObject loadresobj;  //unity中没有赋值
//     public Animation loadingimg;  //加载进度的动图，转圈圈那个
//     AsyncOperation async;  //异步操作协同程序，这里用来异步加载场景
//     string url;  //猜测：url对应的是本地的下一个场景路径(或者是其他资源的路径？)

//     public void LoadScene()
//     {
//         StartCoroutine(loadscene());
//     }

//     /// <summary>
//     /// 加载场景
//     /// </summary>
//     /// <returns>等待</returns>
//     IEnumerator loadscene()
//     {
//         ///猜测下面if语句的作用是：
//         /// 当loadresobj不为空时，代表有资源要加载，
//         /// 所以一开始要设置为Active为false，unity不显示loadresobj，
//         /// 等加载完loadresobj之后，再把loadresobj的Active设置为true，这时unity显示loadresobj
//         if (loadresobj != null)
//         {
//             loadresobj.SetActive(false);
//         }
//         if (loadresBG != null)
//         {
//             loadresBG.SetActive(false);
//         }
//         loadsceneobj.SetActive(true); // unity一开始就显示画板loadscene，画板loadscene(占内存)非常小，可以瞬间加载
//         for (int i = 0; i < 100; i++)
//         {
//             yield return new WaitForEndOfFrame();
//             text.text = i.ToString() + "%";
//         }
//         yield return new WaitForEndOfFrame();
//         loadingimg.Stop();  // 停止加载进度的动图旋转
//         if (Global.NextSceneName == "Home")
//         {
//             //猜测：url对应的是本地的下一个场景路径(或者是其他资源的路径？)
//             url = Global.LOCAL_RES_URL + Global.NextSceneName + "/" + Global.NextSceneName + ".unity3d"; //2021.12.06 目前Global.LOCAL_RES_URL为空字符串，url为：Home/Home.unity3d
//         }
//         else
//         {
//             url = Global.LOCAL_RES_URL + "Home/" + Global.BookName[Global.BookIndex] + "/" + Global.NextSceneName + ".unity3d";
//         }
//         StartCoroutine(loadingFromAssetBundle()); //加载url对应的场景
//     }

//     /// <summary>
//     /// 加载AssetBundle场景
//     /// </summary>
//     /// <returns>等待</returns>
//     IEnumerator loadingFromAssetBundle()
//     {
//         WWW www = new WWW(url); //unity向url发出get请求，获取相应资源
//         yield return www; // 等待获取到url资源
//         if (www.error != null)
//         { 
//             //获取url资源失败，打印错误信息
//             Debug.Log(www.error);
//         }
//         else
//         {
//             AssetBundle bundle = www.assetBundle;
//             async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(Global.NextSceneName);
//             yield return async; //等待async异步加载完成
//             bundle.Unload(false); //卸载 AssetBundle 释放其数据。
//             // 当 unloadAllLoadedObjects 为 false 时，将释放捆绑包本身中的压缩文件数据，但已从该捆绑包中加载的任何对象实例将保持不变。
//             // 当 unloadAllLoadedObjects 为 true 时，也将销毁从该捆绑包加载的所有对象。如果场景中有 GameObjects 引用这些资源，则对它们的引用将丢失。
//         }
//         www.Dispose(); //释放现有的WWW对象，既释放www。
//     }


// }

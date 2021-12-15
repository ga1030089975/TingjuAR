using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Global : MonoBehaviour
{
    public static int BookIndex;
    public static Dictionary<int, string> BookName = new Dictionary<int, string>();//key is bookindex,value is bookname
    /*-----------------------------AR场景--------------------------------*/

    public static string _LastCaptrue = "";              //最后一张截图
    public static bool _PictureView;                     //是否允许显示图片预览
    public static string _LastExhibitionName = "";       //上一个展品的名称
    public static string _ExhibitionInFocusMode = "";    //当前专注模式下展品的名称
    public static string _CurrentExhibitionName = "";    //当前展品的名称
    public static string MusicName =null;                //动物介绍
    public static bool _LastExhibitionLost = true;       //最近一个展品是否已经丢失

    /*-----------------------------全局--------------------------------*/
	public static float spaces = 0;
    public static string NextSceneName = "Home";         //将要切换到的场景名称
    public static int hasBook = 0;                      //是否有书，决定显示书库还是我的书架0代表没有，1代表有
    public static int screenwidth;
    public static int screenheight;
    public static bool CanTimeLose=false;
    /*------------------------------路径-------------------------------*/
    public static string SaveHTMLPhoto = "";
    public static string SaveHTMLFPhotoPath = "";
    public static string SaveHTMLPhotoPath = "";
    public static string SavePhotoPath = "";             //用户个人存储照片文件夹
    public static bool showweb=false;
    public static string LOCAL_RES_URL;                                                  //本地域名
    public static string SERVER_RES_URL= "http://k.kankexue.com/Books2/";                 //服务器域名
    public static string LOCAL_RES_PATH;                                                 //本地地址
    public static string ServerThreeUrl =
#if UNITY_EDITOR
 "window/";
#elif UNITY_ANDROID
"Android/";
#elif UNITY_IPHONE  //已过时。改用UNITY_IOS。
"ios/";
#endif                                                   //服务器assetbundle包分类存放地址
    void Start()
	{
        screenheight = Screen.height;
        screenwidth = Screen.width;
		LOCAL_RES_URL = "file://" + Application.persistentDataPath + "/kexuehui/";
		LOCAL_RES_PATH = Application.persistentDataPath + "/kexuehui/";
        //CreateFoldforPhoto();
    }
	public static void CreateFoldforPhoto()
	{
#if UNITY_EDITOR
       SavePhotoPath = Application.persistentDataPath + "/科学荟/";
       SaveHTMLFPhotoPath = Application.persistentDataPath + "/科学荟/";
#elif UNITY_IPHONE
		SavePhotoPath = Application.persistentDataPath + "/";
       SaveHTMLFPhotoPath = Application.persistentDataPath + "/";
#elif UNITY_ANDROID
       string sb = Application.persistentDataPath;
       // string[] sbone = sb.Split(new string[] { "/Android/" },StringSplitOptions.None);
       string[] sbone = sb.Split(new string[] { "/Android/" },StringSp);
       SavePhotoPath =sbone[0]+ "/DCIM/科学荟/";
       SaveHTMLFPhotoPath =sbone[0]+"/DCIM/";
#endif
       if (!Directory.Exists(SavePhotoPath))
		{
			Directory.CreateDirectory(SavePhotoPath);
		}
       if (!Directory.Exists(LOCAL_RES_PATH))
       {
           Directory.CreateDirectory(LOCAL_RES_PATH);
       }
	}
}

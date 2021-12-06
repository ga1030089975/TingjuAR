using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadManager : MonoBehaviour
{
    public GameObject Tippanel;
    public GameObject userPanel;
    public GameObject privacyPanel;
    private bool agree = false;
    // Start is called before the first frame update
    void Start()
    {
       CheckAgreement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //检查“同意用户协议和隐私协议”状态，已同意过：隐藏面板Tippanel，未同意过：激活面板Tippanel
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
    
    
    //检查读写权限
    // private void CheckWritePermission()
    // {
 
    //     if (!PlayerPrefs.HasKey("Write权限"))
    //     {
    //         Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    //         PlayerPrefs.SetInt("Write权限", 10);
    //     }
        
    // }

    //检查摄像头权限
    // private void CheckCameraPermission()
    // {
    //     if (!PlayerPrefs.HasKey("Camera权限"))
    //     {
    //         Permission.RequestUserPermission(Permission.Camera);
    //         PlayerPrefs.SetInt("Camera权限", 10);
    //     }
    // }

    
}

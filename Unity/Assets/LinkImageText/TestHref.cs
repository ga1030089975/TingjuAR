using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestHref : MonoBehaviour {

    private LinkImageText textPic;
    public GameObject userGo;
    public GameObject privacyGo;

    void Awake()
    {
        textPic = GetComponent<LinkImageText>();
        // print("test");
    }

    void OnEnable()
    {
        textPic.onHrefClick.AddListener(OnHrefClick);
    }

    void OnDisable()
    {
        textPic.onHrefClick.RemoveListener(OnHrefClick);
    }

    private void OnHrefClick(string hrefName)
    {
        Debug.Log("点击了 " + hrefName);
        switch (hrefName)
        {
            case "fwxy":
                userGo.SetActive(true);
                privacyGo.SetActive(false);
                break;
            case "yszc":
                userGo.SetActive(false);
                privacyGo.SetActive(true);
                break;
            default:
                break;
        }
    }
}

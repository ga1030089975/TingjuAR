using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestHref : MonoBehaviour {

    private HyperlinkText mHyperlinkText;
    public GameObject userGo;
    public GameObject privacyGo;
     public GameObject UserAndPrivacy;

    void Awake()
    {
        mHyperlinkText = GetComponent<HyperlinkText>();
    }


    protected  void OnEnable()
    {
        mHyperlinkText.onHrefClick.AddListener(OnHyperlinkTextInfo);
    }

    protected  void OnDisable()
    {
        mHyperlinkText.onHrefClick.RemoveListener(OnHyperlinkTextInfo);
    }
    /// <summary>
    /// 当前点击超链接回调
    /// </summary>
    /// <param name="info">回调信息</param>
    private void OnHyperlinkTextInfo(string info)
    {
        Debug.Log("超链接信息：" + info);
        switch (info)
        {
            case "yhxy":
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
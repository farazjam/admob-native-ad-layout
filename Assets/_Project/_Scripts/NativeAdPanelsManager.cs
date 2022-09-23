using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

// Old Name: ShowNativeAd
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
public class NativeAdPanelsManager : MonoBehaviour
{
    public NativeAdPanel adPanel;
    public NoAdPanel noAdPanel;

    private void Awake()
    {
        Assert.IsNotNull(adPanel);
        Assert.IsNotNull(noAdPanel);
        adPanel.Init();
    }

    private void OnEnable()
    {
        Assert.IsNotNull(NativeAdsManager.Instance);            // NativeAdManager must be present in hierarchy before this call
        NativeAdsManager.Instance.ShowAd(adPanel, noAdPanel);
    }

    private void OnDisable()
    {
        //NativeAdsManager.Instance.isShow = false;
        //NativeAdsManager.Instance.RequestNativeAd();
    }
}

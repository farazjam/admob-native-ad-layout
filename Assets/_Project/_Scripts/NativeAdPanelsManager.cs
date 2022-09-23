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
    public static NativeAdPanelsManager Instance;
    public NativeAdPanel adPanel;
    public NoAdPanel noAdPanel;

    private void Awake()
    {
        Instance = this;
        Assert.IsNotNull(adPanel);
        Assert.IsNotNull(noAdPanel);
        adPanel.Init();
    }

    private void OnEnable()
    {
        NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;
        Assert.IsNotNull(NativeAdsManager.Instance);            // NativeAdManager must be present in hierarchy before this call
        NativeAdsManager.Instance.ShowAd(adPanel, noAdPanel);
    }

    private void OnDisable()
    {
        NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;
        //NativeAdsManager.Instance.isShow = false;
        //NativeAdsManager.Instance.RequestNativeAd();
    }

    public void OnNativeAdLoaded(bool nativeAdLoaded)
    {
        adPanel.Show(nativeAdLoaded);
        noAdPanel.Show(!nativeAdLoaded);
    }
}

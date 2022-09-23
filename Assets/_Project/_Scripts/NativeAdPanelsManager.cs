using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

// Old Name: ShowNativeAd
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
public class NativeAdPanelsManager : MonoBehaviour
{
    public NativeAdPanel adPanel;
    public GameObject noAdPanel;

    private void Awake()
    {
        Assert.IsNotNull(adPanel);
        Assert.IsNotNull(noAdPanel);
        adPanel.Init();
    }

    private void OnEnable()
    {
        NativeAdsManager.ToggleAdPanels += TogglePanels;
        Assert.IsNotNull(NativeAdsManager.Instance);            // NativeAdManager must be present in hierarchy before this call
        NativeAdsManager.Instance.ShowAd(adPanel);
    }

    private void OnDisable()
    {
        NativeAdsManager.ToggleAdPanels -= TogglePanels;
        NativeAdsManager.Instance.isShow = false;
        NativeAdsManager.Instance.RequestNativeAd();
    }

    private void TogglePanels(bool isNativeLoaded)
    {
        adPanel.contentPanel.gameObject.SetActive(isNativeLoaded);
        noAdPanel.gameObject.SetActive(!isNativeLoaded);
    }
}

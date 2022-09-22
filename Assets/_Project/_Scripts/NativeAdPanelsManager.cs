using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

// Old Name: ShowNativeAd
[DefaultExecutionOrder((int)Order.BeforeNativeAdManager)]
public class NativeAdPanelsManager : MonoBehaviour
{
    public static NativeAdPanelsManager Instance;
    public NativeAdPanel adPanel;
    public NoAdPanel noAdPanel;

    private void Awake()
    {
        Instance = this;
        Assert.IsNotNull(noAdPanel);
        Assert.IsNotNull(adPanel);
        adPanel.Init();
    }

    public Tuple<NativeAdPanel, NoAdPanel> GetPanels() { return Tuple.Create(adPanel, noAdPanel);}

    public void ShowAdAvailablePanel(bool value)
    {
        adPanel.Show(value);
        noAdPanel.Show(!value);
    }

    private void OnDisable()
    {
        //NativeAdsManager.Instance.isShow = false;
        //NativeAdsManager.Instance.RequestNativeAd();
    }
}

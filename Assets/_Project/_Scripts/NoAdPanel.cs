using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

public class NoAdPanel : MonoBehaviour
{
    public GameObject contentPanel;
    public void Awake()
    {
        Assert.IsNotNull(contentPanel);
        Show(false);
    }

    private void OnEnable() => NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;
    private void OnDisable() => NativeAdsManager.NativeAdLoaded -= OnNativeAdLoaded;

    private void OnNativeAdLoaded(bool nativeAdLoaded) => Show(!nativeAdLoaded);

    public void Show(bool value) => contentPanel.SetActive(value);
}

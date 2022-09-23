using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

public class NoAdPanel : MonoBehaviour
{
    public GameObject contentPanel;
    public void Init()
    {
        Assert.IsNotNull(contentPanel);
        Show(false);
    }

    private void OnEnable() => NativeAdsManager.NativeAdLoaded += delegate (bool value) { Show(!value); };
    private void OnDisable() => NativeAdsManager.NativeAdLoaded -= delegate (bool value) { Show(!value); };

    public void Show(bool value) => contentPanel.gameObject.SetActive(value);
}

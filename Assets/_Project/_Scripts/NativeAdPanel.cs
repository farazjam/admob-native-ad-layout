using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

public class NativeAdPanel : MonoBehaviour
{
    public GameObject contentPanel;
    public RawImage adChoiceIcon;
    public RawImage appIcon;
    public AdTextComponent title;
    public AdTextComponent description;
    public LayoutElement layoutElement;         // To ignore it for dynamic resizing of main image
    public AdImageComponent mainImage;
    public AdTextComponent callToAction;

    public void Awake() => Show(false);

    // Init instead of Awake() to make it go through these lines even when object is disabled, which will be initially
    public void Init()
    {
        Show(false);
        Assert.IsNotNull(contentPanel);
        Assert.IsNotNull(adChoiceIcon);
        Assert.IsNotNull(appIcon);
        Assert.IsNotNull(title);
        Assert.IsNotNull(description);
        Assert.IsNotNull(layoutElement);
        Assert.IsNotNull(mainImage);
        Assert.IsNotNull(callToAction);

        title.Init();
        description.Init();
        callToAction.Init();
        mainImage.Init();
        layoutElement.ignoreLayout = true;
    }

    private void OnEnable() => NativeAdsManager.NativeAdLoaded += delegate (bool value) { Show(value); };
    private void OnDisable() => NativeAdsManager.NativeAdLoaded -= delegate (bool value) { Show(value); };

    public void Show(bool value) => contentPanel.gameObject.SetActive(value);
}

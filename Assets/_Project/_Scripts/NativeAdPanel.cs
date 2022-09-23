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
    public RawImage mainImage;
    public AdTextComponent callToAction;

    private BoxCollider boxCollider;
    const float containerHeight = 240;          // Fixed

    public void Awake() => Show(false);

    // Init instead of Awake() to make it go through these lines even when object is disabled, which will be initially
    public void Init()
    {
        Assert.IsNotNull(contentPanel);
        Show(false);
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

        layoutElement.ignoreLayout = true;
        boxCollider = mainImage.GetComponent<BoxCollider>();
        Assert.IsNotNull(boxCollider);

    }

    private void OnEnable() => NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;
    private void OnDisable() => NativeAdsManager.NativeAdLoaded -= OnNativeAdLoaded;

    private void OnNativeAdLoaded(bool nativeAdLoaded)
    {
        if (!nativeAdLoaded) return;
        mainImage.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        mainImage.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        mainImage.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        mainImage.rectTransform.sizeDelta = Vector2.zero;
        if (!mainImage.texture) return;
        mainImage.SetNativeSize();
        float scale = containerHeight / mainImage.texture.height;
        mainImage.rectTransform.localScale = Vector3.one;
        mainImage.rectTransform.localScale *= scale;
        boxCollider.size = mainImage.rectTransform.sizeDelta;
        title.Text = "Hello this is faraz";
        Show(true);
    }

    public void Show(bool value) => contentPanel.gameObject.SetActive(value);
}

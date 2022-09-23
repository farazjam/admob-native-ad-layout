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
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public LayoutElement layoutElement;         // To ignore it for dynamic resizing of main image
    public RawImage mainImage;
    public TextMeshProUGUI callToActionText;
    const float containerHeight = 240;          // Fixed

    public void Awake() => Show(false);

    // Init instead of Awake() to make it go through these lines even when object is disabled, which will be initially
    public void Init()
    {
        Assert.IsNotNull(contentPanel);
        Show(false);
        Assert.IsNotNull(adChoiceIcon);
        Assert.IsNotNull(appIcon);
        Assert.IsNotNull(titleText);
        Assert.IsNotNull(descriptionText);
        Assert.IsNotNull(layoutElement);
        Assert.IsNotNull(mainImage);
        Assert.IsNotNull(callToActionText);
        layoutElement.ignoreLayout = true;
    }

    private void OnEnable() => NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;
    private void OnDisable() => NativeAdsManager.NativeAdLoaded += OnNativeAdLoaded;

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
        mainImage.rectTransform.localScale *= scale;
        mainImage.gameObject.AddComponent<BoxCollider>();
    }

    public void Show(bool value) => contentPanel.gameObject.SetActive(value);
}

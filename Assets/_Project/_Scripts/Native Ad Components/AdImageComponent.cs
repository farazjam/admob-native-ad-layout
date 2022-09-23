using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

/// <summary>
/// Use it only for dynamic ad images
/// </summary>
[Serializable]
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(BoxCollider))]
public class AdImageComponent : MonoBehaviour
{
    private RawImage rawImage;
    private BoxCollider collider;

    public Texture Texture 
    {
        get { return this.rawImage.texture; } 
        set
        {
            if (this.rawImage.texture == value) return;
            this.rawImage.texture = value;
        }
    }

    public void Init()
    {
        rawImage = GetComponent<RawImage>();
        Assert.IsNotNull(rawImage);
        collider = GetComponent<BoxCollider>();
        Assert.IsNotNull(collider);
    }

    private void OnEnable() => StartCoroutine(nameof(ResizeImageAndCollider));

    private void OnDisable() => StopAllCoroutines();

    IEnumerator ResizeImageAndCollider()
    {
        yield return new WaitForEndOfFrame();
        rawImage.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rawImage.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rawImage.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rawImage.rectTransform.sizeDelta = Vector2.zero;
        if (!rawImage.texture) yield return null;
        rawImage.SetNativeSize();
        float scale = transform.parent.GetComponent<RectTransform>().sizeDelta.y / rawImage.texture.height;
        rawImage.rectTransform.localScale = Vector3.one;
        rawImage.rectTransform.localScale *= scale;
        collider.size = rawImage.rectTransform.sizeDelta;
    }

}
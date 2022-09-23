using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

[Serializable]
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
public class AdImageComponent : MonoBehaviour
{
    private RawImage image;
    private BoxCollider collider;

    public RawImage Image 
    {
        get { return this.image; }
        set { this.image = value; }
    }

    public void Init()
    {
        image = GetComponent<RawImage>();
        collider = GetComponent<BoxCollider>();
        Assert.IsNotNull(image);
        Assert.IsNotNull(collider);
    }

    private void OnEnable() => StartCoroutine(nameof(ResizeImageAndCollider));

    private void OnDisable() => StopAllCoroutines();

    IEnumerator ResizeImageAndCollider()
    {
        yield return new WaitForEndOfFrame();
        image.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        image.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        image.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        image.rectTransform.sizeDelta = Vector2.zero;
        if (!image.texture) yield return null;
        image.SetNativeSize();
        float scale = transform.parent.GetComponent<RectTransform>().sizeDelta.y / image.texture.height;
        image.rectTransform.localScale = Vector3.one;
        image.rectTransform.localScale *= scale;
        collider.size = image.rectTransform.sizeDelta;
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

/// <summary>
/// Use it only for dynamic ad texts
/// </summary>
[Serializable]
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(BoxCollider))]
public class AdTextComponent : MonoBehaviour
{
    private TextMeshProUGUI text;
    private BoxCollider collider;

    public string Text 
    {
        get { return this.text.text; }
        set 
        {
            if (this.text.text == value) return;
            this.text.text = value; 
        }
    }

    public void Init()
    {
        text = GetComponent<TextMeshProUGUI>();
        collider = GetComponent<BoxCollider>();
        Assert.IsNotNull(text);
        Assert.IsNotNull(collider);
    }

    private void OnEnable() => StartCoroutine(nameof(ResizeCollider));

    private void OnDisable() => StopAllCoroutines();

    IEnumerator ResizeCollider()
    {
        yield return new WaitForEndOfFrame();
        this.collider.size = this.text.rectTransform.sizeDelta;
    }

}
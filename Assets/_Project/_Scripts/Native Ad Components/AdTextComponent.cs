using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

/// <summary>
/// Use it only for dynamic ad texts
/// </summary>
[Serializable]
[DefaultExecutionOrder((int)Order.AfterNativeAdManager)]
[RequireComponent(typeof(Text))]
[RequireComponent(typeof(BoxCollider))]
public class AdTextComponent : MonoBehaviour
{
    public enum AdTextType { None, Headline = 25, Body = 90, CallToAction = 15}
    [SerializeField] private AdTextType type;
    private Text text;
    private BoxCollider collider;

    public string Text 
    {
        get { return this.text.text; }
        set 
        {
            if (this.text.text == value) return;
            Assert.AreNotEqual(type, AdTextType.None);
            this.text.text = value.Length > (int)type ? value.Substring(0, (int)type) : value;
        }
    }

    public void Init()
    {
        text = GetComponent<Text>();
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
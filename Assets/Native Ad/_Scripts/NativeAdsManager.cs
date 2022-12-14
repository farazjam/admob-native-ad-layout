using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

enum Order { _NativeAdsManager, AfterNativeAdManager }; 

[DefaultExecutionOrder((int)Order._NativeAdsManager)]
public class NativeAdsManager : MonoBehaviour
{
    public static NativeAdsManager Instance;
    public static event Action<bool> ToggleAdPanels;
    public static event Action Enable_NativeAdPanel_AfterAssignments;
    [SerializeField] private bool nativeAdLoaded = false;
    [HideInInspector] public bool isShow;
    private NativeAdPanel adPanel;

    [Header("Dummy Ad Params")]
    [SerializeField] Texture dummyMainImage;    // Assign ad image here to test if main image resizes, remove in real usage

    private void Awake() => Instance = this;

    public void ShowAd(NativeAdPanel adPanel)
    {
        this.adPanel = adPanel;
        isShow = true;
        ToggleAdPanels?.Invoke(nativeAdLoaded);
    }

    private void Update()
    {
        if (this.nativeAdLoaded && isShow)
        {
            this.nativeAdLoaded = false;
            isShow = false;

            Texture2D adChoiceLogoTexture = null; // this.nativeAd.GetAdChoicesLogoTexture();
            if (adChoiceLogoTexture != null)
            {
                //adChoiceTexture.texture = adChoiceLogoTexture;        // Old
                adPanel.adChoiceIcon.texture = adChoiceLogoTexture;     // New

                /*if (!this.nativeAd.RegisterAdChoicesLogoGameObject(adChoiceTexture.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register adchoice.");
                }*/
            }

            Texture2D iconTexture = null;// this.nativeAd.GetIconTexture();
            if (iconTexture != null)
            {
                //appIcon.texture = iconTexture;                        // Old
                adPanel.appIcon.texture = iconTexture;                  // New

                /*if (!this.nativeAd.RegisterAdChoicesLogoGameObject(appIcon.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register appIcon.");
                }*/
            }

            string headline = "This is a test headline";// this.nativeAd.GetHeadlineText();
            if (headline != null)
            {
                //heading.text = headline;                              // Old
                adPanel.headline.Text = headline;                          // New

                /*if (!this.nativeAd.RegisterHeadlineTextGameObject(heading.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register headline.");
                }*/
            }

            string bodyText = "This is a sample body text and it should be max 90 chars long. This one is also 90 ch long";// this.nativeAd.GetBodyText();
            if (bodyText != null)
            {
                //this.bodyText.text = bodyText;                        // Old
                adPanel.body.Text = bodyText;                    // New

                /*if (!this.nativeAd.RegisterBodyTextGameObject(this.bodyText.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register body text.");
                }*/
            }

            //if (this.nativeAd.GetImageTextures().Count > 0)
            {
                //List<Texture2D> imageList = this.nativeAd.GetImageTextures();
                //mainAdImage.texture = imageList[0];                   // Old
                adPanel.mainImage.Texture = dummyMainImage;/*imageList[0];*/      // New

                //List<GameObject> regList = new List<GameObject>();
                //regList.Add(mainAdImage.gameObject);                  // Old
                //regList.Add(adPanel.mainImage.gameObject);            // New
                //this.nativeAd.RegisterImageGameObjects(regList);
            }

            string buttonText = "Install xyz";// this.nativeAd.GetCallToActionText();
            if (buttonText != null)
            {
                //this.callToActionText.text = buttonText;              // Old
                adPanel.callToAction.Text = buttonText;                 // New

                /*if (!this.nativeAd.RegisterCallToActionGameObject(this.callToActionText.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register call to action text.");
                }*/
            }

            Enable_NativeAdPanel_AfterAssignments?.Invoke();

        }
    }


    public void RequestNativeAd()
    {
        /*if (!ArcadianAdsManager.Agent.nativeAdPlacement.autoLoad)
        {
            if (ArcadianAdsManager.Agent.enableAdLogs)
                print(":* Native Ads are disabled");
            return;
        }
        AdLoader adLoader = new AdLoader.Builder(ArcadianAdsManager.Agent.GetNativeAdId()).ForNativeAd().Build();

        adLoader.OnNativeAdLoaded += this.HandleNativeAdLoaded;
        adLoader.OnAdFailedToLoad += this.HandleNativeAdFailedToLoad;
        adLoader.OnNativeAdClicked += this.HandleNativeAdClicked;
        adLoader.OnNativeAdImpression += this.HandleNativeAdImpression;

        adLoader.LoadAd(new AdRequest.Builder().Build());*/
    }
}
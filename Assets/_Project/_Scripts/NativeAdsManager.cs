using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

enum Order { BeforeNativeAdManager, _NativeAdsManager};

[DefaultExecutionOrder((int)Order._NativeAdsManager)]
public class NativeAdsManager : MonoBehaviour
{
    public static NativeAdsManager Instance;
    public static event Action NativeAdLoaded;
    public bool showTestAd = false;             // For test, if enabled in inspector, only then test ad will show. Remove in real use
    private bool nativeAdLoaded = false;
    [HideInInspector] public bool isShow;
    private NativeAdPanel adPanel;
    private NoAdPanel noAdPanel;
    [SerializeField] Texture dummyMainImage;    // Assign ad image here to test if main image resizes, remove in real usage

    private void Awake()
    {
        Instance = this;
        // Get panels from Panels Manager so that we toggle on/off them at our will
        // NativeAdsPanelManager have to load first, then should load NativeAdsManager
        Tuple<NativeAdPanel, NoAdPanel> panels = NativeAdPanelsManager.Instance.GetPanels();
        adPanel = panels.Item1;
        noAdPanel = panels.Item2; 
    }

    IEnumerator Start()
    {
        // Mimicking as if ad is loaded after 1 seconds, will show
        yield return new WaitForSeconds(1f);
        if (showTestAd)
        {
            nativeAdLoaded = true;
            ShowAd();
        }
    }

    private void ShowAd()
    {
        if (!nativeAdLoaded) return;
        NativeAdPanelsManager.Instance.ShowAdAvailablePanel(nativeAdLoaded);
        isShow = true;
        adPanel.mainImage.texture = dummyMainImage ? dummyMainImage : null; // To test if main image resizes, remove in real usage
        NativeAdLoaded?.Invoke();                   // Place this call when the ad is loaded so that main image resizes
    }


    private void Update()
    {
        return; // For testing, remove it for real usage...
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

            string headline = null;// this.nativeAd.GetHeadlineText();
            if (headline != null)
            {
                //heading.text = headline;                              // Old
                adPanel.titleText.text = headline;                      // New

                /*if (!this.nativeAd.RegisterHeadlineTextGameObject(heading.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register headline.");
                }*/
            }

            string bodyText = null;// this.nativeAd.GetBodyText();
            if (bodyText != null)
            {
                //this.bodyText.text = bodyText;                        // Old
                adPanel.descriptionText.text = bodyText;                // New

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
                adPanel.mainImage.texture = null;/*imageList[0];*/      // New

                //List<GameObject> regList = new List<GameObject>();
                //regList.Add(mainAdImage.gameObject);                  // Old
                //regList.Add(adPanel.mainImage.gameObject);            // New
                //this.nativeAd.RegisterImageGameObjects(regList);
            }

            string buttonText = null;// this.nativeAd.GetCallToActionText();
            if (buttonText != null)
            {
                //this.callToActionText.text = buttonText;              // Old
                adPanel.callToActionText.text = buttonText;             // New

                /*if (!this.nativeAd.RegisterCallToActionGameObject(this.callToActionText.gameObject))
                {
                    if (ArcadianAdsManager.Agent.enableAdLogs)
                        print(":* Handle failure to register call to action text.");
                }*/
            }

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
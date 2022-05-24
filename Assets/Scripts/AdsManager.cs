using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Unity;

public class AdsManager : MonoBehaviour
{

#if UNITY_ANDROID
    [Header("   Ads Id  Android  ")]
    public string _bannerId;
    public string _interstitialId = "ca-app-pub-3940256099942544/1033173712";
    public string _rewardId="ca-app-pub-3940256099942544/5224354917";
    // public string _rewardedId;
#elif UNITY_IPHONE
    [Header("   Ads Id  IPhone  ")]
    public string _bannerId ;
    public string _rewardId="ca-app-pub-3940256099942544/1712485313";
    public string _interstitialId ;
 //   public string _rewardedId ;
#else
    string adUnitId = "unexpected_platform";
#endif

    public static AdsManager instance;
    public object obj;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // [Serializable]
    // public class myClass
    // {
    //     public int age;
    // }
    // public myClass myClassObject;
    public BannerView bannerView;
    public RewardedAd rewardedAd;
    private void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        RequestInterstitial();
        RequestRewarded();
         
    }
    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            ShowIntersititial();
        }
        if (Input.GetKeyDown("b"))
        {
            ShowBanner();
        }
        if (Input.GetKeyDown("r"))
        {
            ShowRewared();
        }
    }
    private void RequestBanner()
    {
        bannerView = new BannerView(_bannerId, AdSize.SmartBanner, AdPosition.Top);
        AdRequest _req = new AdRequest.Builder().Build();
        bannerView.LoadAd(_req);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoadedBanner;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoadBanner;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpenedBanner;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosedBanner;
        // Called when the ad click caused the user to leave the application.
        // this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }
    void HandleOnAdLoadedBanner(object obj, EventArgs args)
    {
        print("ad loaded success");
    }
    public void HandleOnAdFailedToLoadBanner(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: "
                            + args);
    }

    public void HandleOnAdOpenedBanner(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    public void HandleOnAdClosedBanner(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        print("HandleAdLeavingApplication event received");
    }
    public void BannerHide()
    {
        bannerView.Destroy();
    }
    public void ShowBanner()
    {
        //  bannerView.Show();
        RequestBanner();
    }
    public InterstitialAd interstitialAd;
    void RequestInterstitial()
    {
        interstitialAd = new InterstitialAd(_interstitialId);
        AdRequest _req = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(_req);
        // Called when an ad request has successfully loaded.
        this.interstitialAd.OnAdLoaded += this.HandleOnAdLoadedBanner;
        // Called when an ad request failed to load.
        this.interstitialAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoadBanner;
        // Called when an ad is clicked.
        this.interstitialAd.OnAdOpening += this.HandleOnAdOpenedInterstitial;
        // Called when the user returned from the app after an ad click.
        this.interstitialAd.OnAdClosed += this.HandleOnAdClosedInterstitial;
        // Called when the ad click caused the user to leave the application.
        // this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    void HandleOnAdLoadedInterstitial(object obj, EventArgs args)
    {
        print("ad loaded success");
    }
    public void HandleOnAdFailedToLoadInterstitial(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleAdOpened event received");
    }
    public void HandleOnAdOpenedInterstitial(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    public void HandleOnAdClosedInterstitial(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }
    /*  public void HandleOnAdLeavingApplication(object sender, EventArgs args)
      {
          print("HandleAdLeavingApplication event received");
      }*/
    public void DestroyIntersitital()
    {
        interstitialAd.Destroy();
    }
    public void ShowIntersititial()
    {
        interstitialAd.Show();
        RequestInterstitial();
    }
    public void ShowRewared()
    {
        rewardedAd.Show();
        RequestRewarded();
    }
    public void DestroyRewarded()
    {
        rewardedAd.Destroy();
    }
    public void RequestRewarded()
    {
        this.rewardedAd = new RewardedAd(_rewardId);
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}


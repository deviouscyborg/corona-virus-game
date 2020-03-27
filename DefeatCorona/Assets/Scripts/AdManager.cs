using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-4500169197993541~1454919148";
    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAD;
    public static int interstitialAdCounter = 0;
    public static int videoAdCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(APP_ID);

        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();

    }

    void RequestBanner() {
        string banner_Id = "ca-app-pub-4500169197993541/5159194581";
        bannerAD = new BannerView(banner_Id, AdSize.Banner, AdPosition.Top);

        //for real
        AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        // AdRequest adRequest = new AdRequest.Builder()
        // .AddTestDevice("33BE2250B43518CCDA7DE426D04EE232").Build();

        bannerAD.LoadAd(adRequest);
    }


    void RequestInterstitial() {
        string interstitial_Id = "ca-app-pub-4500169197993541/8300911987";
        interstitialAd = new InterstitialAd(interstitial_Id);

        //for real
        AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        // AdRequest adRequest = new AdRequest.Builder()
        // .AddTestDevice("33BE2250B43518CCDA7DE426D04EE232").Build();

        interstitialAd.LoadAd(adRequest);
    }

    void RequestVideoAd() {
        string video_Id = "ca-app-pub-4500169197993541/6013412571";
        rewardVideoAD = RewardBasedVideoAd.Instance;

        //for real
        AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        // AdRequest adRequest = new AdRequest.Builder()
        // .AddTestDevice("33BE2250B43518CCDA7DE426D04EE232").Build();

        rewardVideoAD.LoadAd(adRequest, video_Id);
    }

    public void Display_Banner() {
        bannerAD.Show();
    }

    public void Display_Interstital() {
        interstitialAdCounter++;
        if(interstitialAdCounter == 3 && videoAdCounter != 5) {
            if(interstitialAd.IsLoaded()) {
            interstitialAd.Show();
            interstitialAdCounter = 0;
        }
        }
        
    }

    public void Display_Reward_Video() {
        videoAdCounter++;
        if(videoAdCounter == 5 && interstitialAdCounter != 3) {
            if(rewardVideoAD.IsLoaded()){
            rewardVideoAD.Show();
            videoAdCounter = 0;
        }
        }
        
    }


    //handle events

     public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    void HandleBannerAds(bool subscribe) {

        if(subscribe) {
             // Called when an ad request has successfully loaded.
        this.bannerAD.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerAD.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerAD.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerAD.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerAD.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        } else {
             // Called when an ad request has successfully loaded.
        this.bannerAD.OnAdLoaded -= this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerAD.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerAD.OnAdOpening -= this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerAD.OnAdClosed -= this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerAD.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }
       
    }

    void OnEnable() {
        HandleBannerAds(true);
    }

    void OnDisable() {
        HandleBannerAds(false);
    }
}

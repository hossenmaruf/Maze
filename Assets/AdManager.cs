using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour {

    public static AdManager instance;

    private string appID = "";

  

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "";

  


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
         MobileAds.Initialize((initStatus) => {} ) ;

        RequestFullScreenAd();

       
         
         
    }


    public void RequestFullScreenAd()
    {
        fullScreenAd = new InterstitialAd(fullScreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        fullScreenAd.LoadAd(request);

    }

    public void ShowFullScreenAd()
    {
        if (fullScreenAd.IsLoaded())
        {
            fullScreenAd.Show();
            RequestFullScreenAd()  ;
        }else
        {
            Debug.Log("Full screen ad not loaded");
            RequestFullScreenAd()  ;
        }
    }

  
   


   





   
    
}

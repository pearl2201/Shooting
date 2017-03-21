using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class IAPScreenManager : MonoBehaviour
{
    public tk2dTextMesh txtDollar;
    public tk2dTextMesh txtDiamond;
    public IAPScreenItem[] arrItems;
    private IAPScreenItem currItemIAP;
    public GameObject goPurchaseEnable, goPurchaseDisable;


    void Start()
    {
        for (int i = 0; i < arrItems.Length; i++)
        {
            arrItems[i].Setup();
        }
        currItemIAP = null;
    }
    public void DisplayInfoItem(IAPScreenItem item)
    {

    }

    public void ClickPurchaseItem()
    {

    }


    public void Back()
    {
        pScreenManager.Instance.LoadBackScreen();
    }

    public void RestoreIAP()
    {


    }

    public void ClickWatchAds()
    {

    }

    public void HandleWathchAds(bool isWatchSuccess)
    {

    }


}


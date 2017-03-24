using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class ShopManager : MonoBehaviour
{

    public GameObject pagePrimaryGun;
    public GameObject pageSecondaryGun;
    public GameObject pageGrenade;
    public GameObject pageEquipment;


    public TYPE_ITEM currPage;
    
    
    void Start()
    {
        pScreenManager.Instance.SetQueueUnlockScreen();
    }

    public void SelectPagePrimaryGun()
    {
        SetPageActive(TYPE_ITEM.PRIMARYGUN);
    }

    public void SelectSecondaryGun()
    {
        SetPageActive(TYPE_ITEM.SECONDARYGUN);
    }

    public void SelectGranadeGun()
    {
        SetPageActive(TYPE_ITEM.GRENADE);
    }

    public void SelectEquipmentPage()
    {
        SetPageActive(TYPE_ITEM.EQUIPMENT);
    }

    public void SetPageActive(TYPE_ITEM typePage)
    {
        pagePrimaryGun.gameObject.SetActive(typePage == TYPE_ITEM.PRIMARYGUN);
        pageSecondaryGun.gameObject.SetActive(typePage == TYPE_ITEM.SECONDARYGUN);
        pageGrenade.gameObject.SetActive(typePage == TYPE_ITEM.GRENADE);
        pageEquipment.gameObject.SetActive(typePage == TYPE_ITEM.EQUIPMENT);
    }

    public void ClickBack()
    {
        pScreenManager.Instance.LoadBackScreen();
    }

    public void ClickWatchAds()
    {

    }

    public void UpdateCoin()
    {

    }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class IAPScreenManager : MonoBehaviour
{

    public tk2dTextMesh txtDiamond;
    public IAPScreenItem[] arrItems;
    private IAPScreenItem currItemIAP;
    public GameObject goPurchaseEnable;
    [SerializeField]
    private tk2dTextMesh txtDescription;
    [SerializeField]
    private tk2dTextMesh txtCost;
    [SerializeField]
    private GameObject goSelectedBox;
    [SerializeField]
    private tk2dTextMesh txtName;

    [SerializeField]
    private MoneyButton btnCoin, btnDiamond;
    void Start()
    {
        for (int i = 0; i < arrItems.Length; i++)
        {
            arrItems[i].Setup();
        }
        if (Registry.OPTION_OPEN_SHOP == TYPE_MONEY.COIN)
        {
            DisplayInfoItem(arrItems[1]);
        }
        else if (Registry.OPTION_OPEN_SHOP == TYPE_MONEY.DIAMOND)
        {
            DisplayInfoItem(arrItems[1]);
        }
        else
        {
            DisplayInfoItem(arrItems[0]);
        }
       

        txtDiamond.text = Prefs.Instance.GetCoin().ToString();
    }
    public void DisplayInfoItem(IAPScreenItem item)
    {
        currItemIAP = item;
        goSelectedBox.transform.position = item.transform.position;
        DescriptionIAP decs = null;
        bool showButtonPurchase = true;
        if (item.type == TYPE_IAP.NO_ADS)
        {
            decs = new DescriptionIAP("Remove Ads", "Free Ads removal with purchase on any products", "Free");
            showButtonPurchase = false;
        }
        else if (item.type == TYPE_IAP.COIN_PACK_1)
        {
            decs = new DescriptionIAP("100.000 Game Cash", "Purchase additional 100.000 game cash", "$ 0.99");
        }
        else if (item.type == TYPE_IAP.COIN_PACK_2)
        {
            decs = new DescriptionIAP("250.000 Game Cash", "Purchase additional 250.000 game cash", "$ 1.99");

        }
        else if (item.type == TYPE_IAP.COIN_PACK_3)
        {
            decs = new DescriptionIAP("450.000 Game Cash", "Purchase additional 450.000 game cash", "$ 2.99");
        }
        else if (item.type == TYPE_IAP.INFINITE_ARMOR)
        {
            decs = new DescriptionIAP("Infinite Ammo", "Automatic ammo refill after battle", "$ 1.99");
            showButtonPurchase = !Prefs.Instance.IsHadPurchaseItem(item.type);
        }
        else if (item.type == TYPE_IAP.INFINITE_GRENADE)
        {
            decs = new DescriptionIAP("Infinite Grenade", "Automatic grenade refill after battle", "$ 1.99");
            showButtonPurchase = !Prefs.Instance.IsHadPurchaseItem(item.type);
        }
        else if (item.type == TYPE_IAP.UNLOCK_ALL_STAGE)
        {
            decs = new DescriptionIAP("Unlock All Stages", "There is no need to accumulate any game rating stars, you can directly challenge any stages and mini games", "$ 1.99");
            showButtonPurchase = !Prefs.Instance.IsHadPurchaseItem(item.type);
        }
        txtDescription.text = decs.description;
        txtCost.text = decs.costDecs;
        txtName.text = decs.name;

    }

    public void ClickPurchaseItem()
    {
        // Call IAP
        HandlerIAP();
    }

    public void HandlerIAP()
    {
        if (currItemIAP.type == TYPE_IAP.COIN_PACK_1)
        {
            Prefs.Instance.AddCoin(100000);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
            txtDiamond.text = Prefs.Instance.GetCoin().ToString();
        }
        else if (currItemIAP.type == TYPE_IAP.COIN_PACK_2)
        {
            Prefs.Instance.AddCoin(250000);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
            txtDiamond.text = Prefs.Instance.GetCoin().ToString();
        }
        else if (currItemIAP.type == TYPE_IAP.COIN_PACK_3)
        {
            Prefs.Instance.AddCoin(450000);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
            txtDiamond.text = Prefs.Instance.GetCoin().ToString();
        }
        else if (currItemIAP.type == TYPE_IAP.INFINITE_ARMOR)
        {
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.INFINITE_ARMOR);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
        }
        else if (currItemIAP.type == TYPE_IAP.INFINITE_GRENADE)
        {
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.INFINITE_GRENADE);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
        }
        else if (currItemIAP.type == TYPE_IAP.UNLOCK_ALL_STAGE)
        {
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.UNLOCK_ALL_STAGE);
            Prefs.Instance.SetHadPuchaseItem(TYPE_IAP.NO_ADS);
        }
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
    public void UpdateMoney()
    {
        btnCoin.UpdateMoney();
        btnDiamond.UpdateMoney();
    }

}


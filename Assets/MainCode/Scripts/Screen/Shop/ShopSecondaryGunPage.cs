using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class ShopSecondaryGunPage : ShopPageBase
{
    [SerializeField]
    private tk2dTextMesh txtName, txtCost, txtArmo;
    [SerializeField]
    private GameObject goEquip,goBuyBullet, goBuyItem, goUpgrade;
    [SerializeField]
    private tk2dClippedSprite csprDamage, csprFirerate, csprAccuracy;
    [SerializeField]
    private tk2dSprite sprItem;

    private DataGun dataGun;


    public override void ClickBuyItem()
    {
        if (Prefs.Instance.GetCoin() >= currItem.dataItem.cost)
        {
            Debug.Log(currItem.dataItem.id);
            Prefs.Instance.SetBoughtPrimaryGun(currItem.dataItem.id, true);
            Prefs.Instance.SubCoin(currItem.dataItem.cost);
            Prefs.Instance.SetCurrPrimaryGun(currItem.dataItem.id);
            Prefs.Instance.SetBulletPrimaryGun(currItem.dataItem.id, dataGun.totalBullet);
            goBuyItem.gameObject.SetActive(true);
            ShowInfoItem(currItem);


            shopManager.UpdateMoney();
        }
    }

    public override void ShowInfoItem(ItemShop item)
    {
        Debug.Log(item.dataItem.id);
        for (int i = 0; i < arrItem.Length; i++)
        {

            if (!Prefs.Instance.IsPrimaryGunBought(arrItem[i].dataItem.id))
            {
                arrItem[i].SetStatus(STATUS_ITEMSHOP.NOTBOUGHT);
                arrItem[i].SetActive(false);
            }
            else
            {
                if (arrItem[i] != item)
                {
                    arrItem[i].SetStatus(STATUS_ITEMSHOP.BOUGHT);
                }
                else
                {
                    arrItem[i].SetStatus(STATUS_ITEMSHOP.SELECT);
                }
                if (arrItem[i].dataItem.id == Prefs.Instance.GetCurrPrimaryGun())
                {
                    arrItem[i].SetActive(true);
                }
                else
                {
                    arrItem[i].SetActive(false);
                }
            }

        }
        currItem = item;
        Debug.Log(item.dataItem.id);
        Debug.Log(currItem.dataItem.id);
        dataGun = (DataGun)item.dataItem;
        csprDamage.ClipRect = new Rect(0, 0, ((float)dataGun.damage) / 10, 1);
        csprAccuracy.ClipRect = new Rect(0, 0, ((float)dataGun.accuracy) / 10, 1);
        csprFirerate.ClipRect = new Rect(0, 0, ((float)dataGun.firerate) / 10, 1);
        txtName.text = dataGun.nameItem;
        txtArmo.text = dataGun.noBulletPerCharge + "/" + dataGun.totalBullet;
        if (Prefs.Instance.IsPrimaryGunBought(dataGun.id))
        {
            txtCost.gameObject.SetActive(false);
            goBuyItem.gameObject.SetActive(false);
         
            int currNoBullet = Prefs.Instance.GetNoBulletGun(dataGun.id);
            
            if (currNoBullet <= dataGun.totalBullet - dataGun.noBulletPerBought)
            {
              
                goBuyBullet.gameObject.SetActive(true);
            }
            else if (currNoBullet < dataGun.totalBullet)
            {
               
                goBuyBullet.gameObject.SetActive(true);
            }
            else
            {
                goBuyBullet.gameObject.SetActive(false);
            }
            if (Prefs.Instance.GetCurrPrimaryGun() != dataGun.id)
            {
                goEquip.gameObject.SetActive(true);
            }
            else
            {
                goEquip.gameObject.SetActive(false);
            }
            int levelUpgrade = Prefs.Instance.GetLevelUpgradePrimaryGun(dataGun.id);
            if (levelUpgrade == 3)
            {
                goUpgrade.gameObject.SetActive(false);
            }
            else
            {
                goUpgrade.gameObject.SetActive(true);
            }
        }
        else
        {
            txtCost.gameObject.SetActive(true);
            goBuyItem.gameObject.SetActive(true);
            txtCost.text = dataGun.cost.ToString();
          
            goEquip.gameObject.SetActive(false);
            goUpgrade.gameObject.SetActive(false);

        }

    }

    public override void EquipCurrItem()
    {
        Prefs.Instance.SetCurrPrimaryGun(currItem.dataItem.id);
        for (int i = 0; i < arrItem.Length; i++)
        {
            arrItem[i].SetActive(i == dataGun.id);
        }
    }

    public void ClickBoughtBullet()
    {
        int currNoBullet = Prefs.Instance.GetNoBulletGun(dataGun.id);
       
        if (currNoBullet <= dataGun.totalBullet - dataGun.noBulletPerBought)
        {
            if (Prefs.Instance.GetCoin() >= dataGun.costBulletPerBought)
            {

                Prefs.Instance.SetBulletPrimaryGun(dataGun.id, currNoBullet + dataGun.noBulletPerBought);
                Prefs.Instance.SubCoin(dataGun.costBulletPerBought);
            }


        }
        else
        {
            int noBulletBought = dataGun.totalBullet - currNoBullet;
            int costBought = dataGun.costBulletPerBought * (dataGun.totalBullet - currNoBullet) / dataGun.noBulletPerBought;
            if (Prefs.Instance.GetCoin() - costBought >= 0)
            {
                Prefs.Instance.SetBulletPrimaryGun(dataGun.id, currNoBullet + noBulletBought);
                Prefs.Instance.SubCoin(costBought);
            }
        }
        ShowInfoItem(currItem);
        shopManager.UpdateMoney();

    }

    public void ClickUpgrade()
    {

    }
}


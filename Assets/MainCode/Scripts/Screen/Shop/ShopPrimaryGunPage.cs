using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class ShopPrimaryGunPage : ShopPageBase
{
    [SerializeField]
    private tk2dTextMesh txtName, txtCost, txtArmo, txtCurrBullet, txtInfoBuyBullet;
    [SerializeField]
    private GameObject goEquip, goBuyBullet, goBuyItem, goBoardBuyBullet;
    [SerializeField]
    private tk2dClippedSprite csprDamage, csprFirerate, csprAccuracy;

    private DataGun dataGun;

    void Start()
    {

    }

    public override void ClickBuyItem()
    {
        if (Prefs.Instance.GetCoin() >= currItem.dataItem.cost)
        {
            Prefs.Instance.SetBoughtPrimaryGun(currItem.dataItem.id, true);
            Prefs.Instance.SubCoin(currItem.dataItem.cost);
            Prefs.Instance.SetCurrPrimaryGun(currItem.dataItem.id);
            Prefs.Instance.SetBulletPrimaryGun(currItem.dataItem.id, dataGun.totalBullet);
            goBuyItem.gameObject.SetActive(true);
            goBoardBuyBullet.gameObject.SetActive(true);


            shopManager.UpdateCoin();
        }
    }

    public override void ShowInfoItem(ItemShop item)
    {
        dataGun = (DataGun)item.dataItem;
    }

    public override void EquipCurrItem()
    {
        Prefs.Instance.SetCurrPrimaryGun(currItem.dataItem.id);
    }
}


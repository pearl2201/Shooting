using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public AbstractItem dataItem;

    public ShopPageBase shopPage;

    public tk2dSprite sprBg;
    public GameObject goActive;

    public void Setup()
    {

    }
    public void ShowItem()
    {
        shopPage.ShowInfoItem(this);
    }

    

    public void SetStatus(STATUS_ITEMSHOP status)
    {

        if (status == STATUS_ITEMSHOP.BOUGHT)
        {
            sprBg.color = new Color(0, 0, 0, 0.5f);

        }
        else if (status == STATUS_ITEMSHOP.NOTBOUGHT)
        {
            sprBg.color = new Color(0, 0, 0, 0.75f);
        }
        else if (status == STATUS_ITEMSHOP.SELECT)
        {
            sprBg.color = new Color(0, 0, 0, 1f);
        }
    }

    public void SetActive( bool active)
    {
        goActive.gameObject.SetActive(active);
    }

}


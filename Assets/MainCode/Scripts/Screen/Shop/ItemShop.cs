using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public AbstractItem dataItem;

    public ShopPageBase shopPage;

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

        }
        else if (status == STATUS_ITEMSHOP.NOTBOUGHT)
        {

        }
        else if (status == STATUS_ITEMSHOP.SELECT)
        {

        }
    }

}


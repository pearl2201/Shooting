using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public abstract class ShopPageBase : MonoBehaviour
{

    public TYPE_ITEM typePage;
 
    public ItemShop currItem;
    public ShopManager shopManager;
    [SerializeField]
    protected ItemShop[] arrItem;
    void Start()
    {
        for (int i =0; i<arrItem.Length; i++)
        {
            arrItem[i].Setup();
        }
    }

    public abstract void ClickBuyItem();



    public abstract void ShowInfoItem(ItemShop item);

    public abstract void EquipCurrItem();
}


﻿using System;
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

    public void SelectPagePrimaryGun()
    {

    }

    public void SelectSecondaryGun()
    {

    }

    public void SelectGranadeGun()
    {

    }

    public void SelectEquipmentPage()
    {

    }

    public void ClickPlay()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_GAME);
    }

}



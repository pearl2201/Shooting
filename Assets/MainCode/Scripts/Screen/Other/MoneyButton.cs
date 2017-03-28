using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MoneyButton : MonoBehaviour
{
    public TYPE_MONEY typeMoney;
    public tk2dTextMesh txtMoney;

    public void UpdateMoney()
    {
        if (typeMoney == TYPE_MONEY.COIN)
        {
            txtMoney.text = Prefs.Instance.GetCoin().ToString();
        }
        else if (typeMoney == TYPE_MONEY.DIAMOND)
        {
            txtMoney.text = Prefs.Instance.GetDiamond().ToString();
        }
    }

    public void OpenIAPShop()
    {
        Registry.OPTION_OPEN_SHOP = typeMoney;
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_IAP, true);
    }

}


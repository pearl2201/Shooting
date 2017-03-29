using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class AchivementScreenManager : MonoBehaviour
{
    public AchivementScreenItem[] arrScreenItem;
    [SerializeField]
    private MoneyButton btnCoin, btnDiamond;
    public void UpdateMoney()
    {
        btnCoin.UpdateMoney();
        btnDiamond.UpdateMoney();
    }
    public void Back()
    {
        pScreenManager.Instance.LoadBackScreen();
    }
}


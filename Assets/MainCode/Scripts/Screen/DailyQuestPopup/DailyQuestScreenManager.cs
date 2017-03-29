using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DailyQuestScreenManager : MonoBehaviour
{

    public DailyQuestScreenItem[] arrDailyQuest;

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


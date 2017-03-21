using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DailyQuestScreenManager : MonoBehaviour
{

    public DailyQuestScreenItem[] arrDailyQuest;


    public void Back()
    {
        pScreenManager.Instance.LoadBackScreen();
    }
}


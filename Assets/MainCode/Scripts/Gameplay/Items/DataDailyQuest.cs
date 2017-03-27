using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class DataDailyQuest : ScriptableObject
{
    [SerializeField]
    private List<DailyQuest> dailyQuest;

    public DailyQuest GetDailyQuest(TYPE_DAILYQUEST type)
    {
        Debug.Log("call get data daily quest");
        return dailyQuest[(int)type];
    }
}


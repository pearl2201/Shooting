using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class DataDailyQuest : ScriptableObject
{
    [SerializeField]
    private List<DailyQuest> dailyQuest;

    public DailyQuest GetDataAchivement(TYPE_DAILYQUEST type)
    {
        return dailyQuest[(int)type];
    }
}


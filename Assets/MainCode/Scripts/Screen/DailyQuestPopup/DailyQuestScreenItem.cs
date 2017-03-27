using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DailyQuestScreenItem : MonoBehaviour
{

    public int id;

    private TYPE_DAILYQUEST type;

    private tk2dSprite sprBtnGetReward, sprTypeReward, sprIconQuest;
    private tk2dTextMesh txtNameQuest, txtDescriptionQuest, txtValueReward;
    public void Setup()
    {
        ShowDailyQuest(DailyquestManager.Instance.GetDataID(id));
        this.type = DailyquestManager.Instance.GetDataID(id).daily.type;
    }

    public void ReceiveReward()
    {
        DailyQuestItem data = DailyquestManager.Instance.ReceiveReward(id);
        if (data!=null)
        {
            ShowDailyQuest(data);
        }

    }

    public void ShowDailyQuest(DailyQuestItem data)
    {
        txtNameQuest.text = data.daily.name;
        txtDescriptionQuest.text = data.daily.name.Replace("XX", data.daily.reward.ToString());
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DailyQuestScreenItem : MonoBehaviour
{

    public int id;

    private TYPE_DAILYQUEST type;

    [SerializeField]
    private tk2dSprite sprBtnGetReward, sprTypeReward, sprIconQuest;
    [SerializeField]
    private tk2dTextMesh txtNameQuest, txtDescriptionQuest, txtValueReward, txtProgress;

    private bool isFinishQuest;
    void Start()
    {
        Debug.Log("start");
        ShowDailyQuest(DailyquestManager.Instance.GetDataID(id));
        this.type = DailyquestManager.Instance.GetDataID(id).daily.type;

    }

    public void ReceiveReward()
    {
        DailyQuestItem data = DailyquestManager.Instance.ReceiveReward(id);
        if (data != null)
        {
            ShowDailyQuest(data);
        }

    }

    public void ShowDailyQuest(DailyQuestItem data)
    {
        isFinishQuest = data.isFinish;
        txtNameQuest.text = data.daily.name;
        txtDescriptionQuest.text = data.daily.description.Replace("XX", data.request.ToString());
        txtValueReward.text = data.daily.reward.ToString();
        txtProgress.text = data.curr + "/" + data.request;
        if (isFinishQuest)
        {
            sprBtnGetReward.color = Color.white;
        }
        else
        {
            sprBtnGetReward.color = new Color(1, 1, 1, 0.4f);
        }
    }
}

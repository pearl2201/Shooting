using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class AchivementScreenItem : MonoBehaviour
{

    public AchivementScreenManager achivementManager;
    public TYPE_ACHIVEMENT type;


    [SerializeField]
    private tk2dSprite sprBtnGetReward, sprTypeReward, sprIconQuest, sprFinishAllLevel;
    [SerializeField]
    private tk2dTextMesh txtNameQuest, txtDescriptionQuest, txtValueReward, txtProgress;

    private bool isFinishQuest;
    void Start()
    {
        Debug.Log("start");
        ShowDailyQuest(AchivementManager.Instance.GetDescriptionAchivement(type));


    }

    public void ReceiveReward()
    {
        DataAchivementItem data = AchivementManager.Instance.ReceiveReward(type);
        if (data != null && isFinishQuest)
        {
            ShowDailyQuest(data);
        }

    }

    public void ShowDailyQuest(DataAchivementItem data)
    {
        isFinishQuest = data.isFinished;
        txtNameQuest.text = data.achivement.name;
        int levelDisplay = Mathf.Clamp(data.currLevel, 0, Constants.MAX_LEVEL_ACHIVEMENT - 1);
        txtDescriptionQuest.text = data.achivement.description.Replace("XX", data.achivement.requestPerLevel[levelDisplay].ToString());
        txtValueReward.text = data.achivement.rewardPerLevel[levelDisplay].ToString();
        txtProgress.text = data.currValue + "/" + data.achivement.requestPerLevel[levelDisplay];
        if (data.currLevel == Constants.MAX_LEVEL_ACHIVEMENT)
        {
            sprFinishAllLevel.gameObject.SetActive(true);
        }
        else
        {
            sprFinishAllLevel.gameObject.SetActive(true);
        }
        if (isFinishQuest)
        {
            {
                sprBtnGetReward.color = Color.white;
            }

        }
        else
        {
            sprBtnGetReward.color = new Color(1, 1, 1, 0.4f);
        }
    }




}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DailyquestManager
{
    private static DailyquestManager _instace;

    public static DailyquestManager Instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = new DailyquestManager();

            }
            return _instace;
        }
    }

    private DailyQuestItem[] arrDaily;

    private DateTime today;

    public DailyquestManager()
    {
        // getMission from prefs
        arrDaily = new DailyQuestItem[3];
        if (CheckReset())
        {
            ResetAllMission();
        }
        else
        {
            ReadMission();
        }



    }

    public bool CheckReset()
    {
        today = DateTime.Now;
        DateTime lastDay = DateTime.Parse(Prefs.Instance.GetCurrDay());
        if (today.Day != lastDay.Day)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAllMission()
    {
        for (int i = 0; i < Constants.MAX_TOTAL_DAILY; i++)
        {
            ResetMission(i);
        }
    }

    public void ResetMission(int id)
    {

    }

    public void ReadMission()
    {

    }

    public void UpdateDailyEndGame(InfoGame info, int score, bool isSuccess)
    {
        List<TYPE_DAILYQUEST> _listMission = new List<TYPE_DAILYQUEST>();
        for (int i = 0; i < arrDaily.Length; i++)
        {
            _listMission.Add(arrDaily[i].daily.type);
        }

        if (_listMission.Contains(TYPE_DAILYQUEST.USE_PRI))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.USE_PRI);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += info.countPrimaryKill;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.USE_PRI, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.USE_SECONDARY))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.USE_SECONDARY);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += info.countSecondaryKill;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.USE_SECONDARY, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.USE_GRENADE))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.USE_GRENADE);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += info.countGrenadeKill;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.USE_GRENADE, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.KILLER))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.KILLER);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += info.countEnemyKill;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.KILLER, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.WIN_HIT_RATE) && isSuccess && info.countShootingSuccess*100/info.countShooting>=60)
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.WIN_HIT_RATE);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += 1;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.WIN_HIT_RATE, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.WIN_NO_KILL_CIVIL) && isSuccess && info.civianKilling== 0)
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.WIN_NO_KILL_CIVIL);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += 1;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.WIN_NO_KILL_CIVIL, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.REACH_SCORE))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.REACH_SCORE);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr = score;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.REACH_SCORE, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
        else if (_listMission.Contains(TYPE_DAILYQUEST.SHOOT_BULLET))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.SHOOT_BULLET);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr += info.countShooting;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.SHOOT_BULLET, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }

    }

    public void UpdateDailyBuyGrenade()
    {
        List<TYPE_DAILYQUEST> _listMission = new List<TYPE_DAILYQUEST>();
        for (int i = 0; i < arrDaily.Length; i++)
        {
            _listMission.Add(arrDaily[i].daily.type);
        }
        if (_listMission.Contains(TYPE_DAILYQUEST.BUY_GRENADE))
        {
            int indexMission = _listMission.IndexOf(TYPE_DAILYQUEST.BUY_GRENADE);
            DailyQuestItem item = arrDaily[indexMission];
            item.curr ++;
            item.curr = Mathf.Clamp(item.curr, 0, item.request);
            Prefs.Instance.SetCurrValueDaily((int)TYPE_DAILYQUEST.BUY_GRENADE, item.curr);
            if (item.curr == item.request)
            {
                item.isFinish = true;
            }
        }
    }




}

public class DailyQuestItem
{
    public DailyQuest daily;
    public int curr;
    public int request;
    public bool isFinish;
}

public class DailyQuest
{
    public TYPE_DAILYQUEST type;
    public string name;
    public string description;

    public int reward;
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

    private TYPE_DAILYQUEST[] arrDaily;

    private DateTime today;

    public DailyquestManager()
    {
        // getMission from prefs
        arrDaily = new TYPE_DAILYQUEST[3];
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

    public void UpdateDailyEndGame(InfoGame info, int score)
    {

    }

    public void UpdateDailyBuyGrenade()
    {

    }

   


}

public class DailyQuest
{
    public TYPE_DAILYQUEST type;
    public string name;
    public string description;

    public int reward;
}


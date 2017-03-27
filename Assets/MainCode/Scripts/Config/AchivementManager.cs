using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AchivementManager
{

    private static AchivementManager _instace;

    public static AchivementManager Instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = new AchivementManager();

            }
            return _instace;
        }
    }

    private List<DataAchivementItem> listDataAchivementItem;
    private DataAchivement dataAchivement;
    public AchivementManager()
    {
        listDataAchivementItem = new List<DataAchivementItem>();
        dataAchivement = UnityEngine.Resources.Load<DataAchivement>("DataAchivement/DataAchivement");
        for (int i = 0; i < Constants.MAX_TYPE_ACHIVEMENT; i++)
        {
            DataAchivementItem item = new DataAchivementItem();
            Achivement achiv = dataAchivement.GetDataAchivement((TYPE_ACHIVEMENT)i);
            item.achivement = achiv;
            item.currLevel = Prefs.Instance.GetLevelAchivement((TYPE_ACHIVEMENT)i);
            item.currValue = Prefs.Instance.GetValueAchivement((TYPE_ACHIVEMENT)i);
            if (item.currLevel == Constants.MAX_LEVEL_ACHIVEMENT)
            {
                item.isFinished = true;
            }
            else
            {
                item.isFinished = (item.currValue >= achiv.requestPerLevel[item.currLevel]);
            }
            listDataAchivementItem.Add(item);

        }
    }

    // Update star, update money, update lucky, update killer, update gun
    public void CheckAchivementEndGame(InfoGame infoGame, Player player)
    {
        // Update Lucky
        {

            DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.LUCKY];
            if (!itemCheck.isFinished && player.hp < player.dataCharacter.hp * 0.1f)
            {

                itemCheck.currValue = Prefs.Instance.GetValueAchivement(TYPE_ACHIVEMENT.LUCKY);
                itemCheck.currValue++;
                if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
                {
                    itemCheck.isFinished = true;
                    itemCheck.currValue = itemCheck.achivement.requestPerLevel[itemCheck.currLevel];
                }
                Prefs.Instance.SetValueAchivement(TYPE_ACHIVEMENT.LUCKY, itemCheck.currValue);

            }

        }

        // update bomb man

        {

            DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.BOMB_MAN];
            if (!itemCheck.isFinished)
            {
                if (infoGame.countTrippleKillGrenade > 0)
                {
                    itemCheck.currValue = Prefs.Instance.GetValueAchivement(TYPE_ACHIVEMENT.BOMB_MAN);
                    itemCheck.currValue += infoGame.countTrippleKillGrenade;
                    if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
                    {
                        itemCheck.isFinished = true;
                        itemCheck.currValue = itemCheck.achivement.requestPerLevel[itemCheck.currLevel];
                    }
                    Prefs.Instance.SetValueAchivement(TYPE_ACHIVEMENT.BOMB_MAN, itemCheck.currValue);
                }
            }

        }

        // update killer
        {

            DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.KILLER];
            if (!itemCheck.isFinished && infoGame.countEnemyKill > 0)
            {

                itemCheck.currValue = Prefs.Instance.GetValueAchivement(TYPE_ACHIVEMENT.KILLER);
                itemCheck.currValue += infoGame.countEnemyKill;
                if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
                {
                    itemCheck.isFinished = true;
                    itemCheck.currValue = itemCheck.achivement.requestPerLevel[itemCheck.currLevel];
                }
                Prefs.Instance.SetValueAchivement(TYPE_ACHIVEMENT.KILLER, itemCheck.currValue);

            }

        }

        // update pistol
        {

            DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.PISTOL];
            if (!itemCheck.isFinished && infoGame.countSecondaryKill > 0)
            {

                itemCheck.currValue = Prefs.Instance.GetValueAchivement(TYPE_ACHIVEMENT.PISTOL);
                itemCheck.currValue += infoGame.countSecondaryKill;
                if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
                {
                    itemCheck.isFinished = true;
                    itemCheck.currValue = itemCheck.achivement.requestPerLevel[itemCheck.currLevel];
                }
                Prefs.Instance.SetValueAchivement(TYPE_ACHIVEMENT.PISTOL, itemCheck.currValue);

            }

        }
        // Update primary gun kill
        {
            int startValueGun = (int)TYPE_ACHIVEMENT.PRIMARY_GUN_1;
            int typeMissionCheck = startValueGun + player.primaryGun.dataGun.id;

            DataAchivementItem itemCheck = listDataAchivementItem[typeMissionCheck];
            if (!itemCheck.isFinished && infoGame.countSecondaryKill > 0)
            {

                itemCheck.currValue = Prefs.Instance.GetValueAchivement((TYPE_ACHIVEMENT)typeMissionCheck);
                itemCheck.currValue += infoGame.countSecondaryKill;
                if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
                {
                    itemCheck.isFinished = true;
                    itemCheck.currValue = itemCheck.achivement.requestPerLevel[itemCheck.currLevel];
                }
                Prefs.Instance.SetValueAchivement((TYPE_ACHIVEMENT)typeMissionCheck, itemCheck.currValue);

            }

        }

    }

    public void UpdateAchivementStar()
    {
        int totalStar = Registry.GetTotalStar();
        DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.BATTLE_MASTER];
        if (!itemCheck.isFinished)
        {

            itemCheck.currValue = totalStar;

            if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
            {
                itemCheck.isFinished = true;
            }
        }
    }



    public void UpdateAchivementBuyGun()
    {
        int totalStar = Registry.GetTotalStar();
        DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.BATTLE_MASTER];
        if (!itemCheck.isFinished)
        {

            itemCheck.currValue = totalStar;

            if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
            {
                itemCheck.isFinished = true;
            }
        }
    }

    public void UpdateAchivementBuyCharacter()
    {
        int totalStar = Registry.GetTotalCharacterBought();
        DataAchivementItem itemCheck = listDataAchivementItem[(int)TYPE_ACHIVEMENT.BIG_ARMY];
        if (!itemCheck.isFinished)
        {

            itemCheck.currValue = totalStar;

            if (itemCheck.currValue > itemCheck.achivement.requestPerLevel[itemCheck.currLevel])
            {
                itemCheck.isFinished = true;
            }
        }
    }



    public void UpdateNextLevelAchivement(TYPE_ACHIVEMENT typeAchivement)
    {
        DataAchivementItem result = listDataAchivementItem[(int)typeAchivement];
        result.currLevel++;

        if (result.currLevel >= Constants.MAX_LEVEL_ACHIVEMENT)
        {
            result.currLevel = Constants.MAX_LEVEL_ACHIVEMENT;
            result.isFinished = true;
        }
        else
        {
            result.isFinished = false;

        }
        Prefs.Instance.SetLevelAchivement(typeAchivement, result.currLevel);
    }
}

public class DataAchivementItem
{
    public Achivement achivement;
    public int currLevel;
    public int currValue;
    public bool isFinished;
}
[Serializable]
public class Achivement
{
    public TYPE_ACHIVEMENT typeAchivement;
    public string name;
    public string description;

    public TYPE_MONEY typeReward;
    public int[] requestPerLevel;
    public int[] rewardPerLevel;

}
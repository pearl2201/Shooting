using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Registry
{

    public static int CURR_ID_MAP = 0;
    public static TYPE_MONEY OPTION_OPEN_SHOP = TYPE_MONEY.COIN;

    public static int GetTotalStar()
    {
        int sum = 0;
        for (int i =0; i< Constants.MAX_LEVEL_GAME; i++)
        {
            sum += Prefs.Instance.GetStarLevel(i);
        }
        return sum;
    }

    public static int GetTotalPrimaryGunBought()
    {
        int s = 0;
        for (int i =0; i< Constants.TOTAL_PRIMARY_GUN; i++)
        {
            if (Prefs.Instance.IsPrimaryGunBought(i))
            {
                s++;
            }
        }
        return s;
    }

    public static int GetTotalSecondaryGunBought()
    {
        int s = 0;
        for (int i = 0; i < Constants.TOTAL_SECONDARY_GUN; i++)
        {
            if (Prefs.Instance.IsSecondaryGunBought(i))
            {
                s++;
            }
        }
        return s;
    }

    public static int GetTotalCharacterBought()
    {
        int s = 0;
        for (int i = 0; i < Constants.TOTAL_CHARACTER; i++)
        {
            if (Prefs.Instance.IsHadBoughtCharacter(i))
            {
                s++;
            }
        }
        return s;
    }

}


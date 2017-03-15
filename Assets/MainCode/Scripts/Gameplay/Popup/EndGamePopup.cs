using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class EndGamePopup : MonoBehaviour
{

    public void Setup(bool isSuccess, string levelMap, int hurt, int accuracy, int kill, int bestScore, int currScore, int cassBonus)
    {

    }

    public void Reload()
    {
        pScreenManager.Instance.ReloadLevel(pScreenManager.SCREEN_GAME);
    }

    public void OpenShop()
    {

    }

    public void Continue()
    {

    }

    public void OpenMap()
    {

    }

}


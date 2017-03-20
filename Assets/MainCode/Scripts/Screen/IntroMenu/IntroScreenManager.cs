using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IntroScreenManager : MonoBehaviour
{

    public void ClickStart()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_PICKMAP, false);
    }

    public void ClickMoreGame()
    {

    }

    public void ClickRateGame()
    {

    }

}


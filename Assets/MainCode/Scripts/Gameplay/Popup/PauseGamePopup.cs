using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PauseGamePopup : MonoBehaviour
{
    private GameManager gameManager;

    public void BackToMenu()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_INTRO);
    }

    public void UnPause()
    {
        gameManager.ClickPause();
    }

    public void ClickOption()
    {

    }

}


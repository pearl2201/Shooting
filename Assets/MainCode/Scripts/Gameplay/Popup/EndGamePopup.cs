using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class EndGamePopup : MonoBehaviour
{
    [SerializeField]
    private tk2dTextMesh txtLevel, txtHurt, txtAccuracy, txtKill, txtBest, txtScore, txtCashBonus;
    [SerializeField]
    private GameObject goFail, goSuccess, goTryAgain, goContinue;
    [SerializeField]
    private GameManager gameManager;


    public void Setup(bool isSuccess, string levelMap, int hurt, int accuracy, int kill, int bestScore, int currScore, int cassBonus)
    {
        
        goFail.gameObject.SetActive(isSuccess == false);
        goSuccess.gameObject.SetActive(isSuccess == true);
        goTryAgain.gameObject.SetActive(isSuccess == false);
        goContinue.gameObject.SetActive(isSuccess == true);
        txtLevel.text = levelMap;
        txtHurt.text = hurt.ToString();
        txtAccuracy.text = accuracy.ToString();
        txtKill.text = kill.ToString();
        txtBest.text = bestScore.ToString();
        txtScore.text = currScore.ToString();
        txtCashBonus.text = cassBonus.ToString();
    }

    public void Reload()
    {
        gameManager.Reset();
    }

    public void OpenShop()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_INTRO);
    }

    public void Continue()
    {
        pScreenManager.Instance.ReloadLevel(pScreenManager.SCREEN_GAME);
    }

    public void OpenMap()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_INTRO);
    }

}


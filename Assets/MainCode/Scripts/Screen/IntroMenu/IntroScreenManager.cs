using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IntroScreenManager : MonoBehaviour
{
    [SerializeField]
    private IntroSettingPopup settingPopup;

    public void ClickStart()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_PICKMAP, false);
    }

    public void ClickMoreGame()
    {
        Application.OpenURL("www.google.com.vn");
    }

    public void ClickRateGame()
    {
        Application.OpenURL("www.google.com.vn");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("www.google.com.vn");
    }

    public void OpenHelp()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_HELP, true);
    }

    public void OpenMoreGame()
    {

    }

    public void OpenAchivement()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_ACHIVEMENT, true);
    }

   

    public void OpenIAP()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_IAP, true);
    }

    public void OpenSetting()
    {
        settingPopup.gameObject.SetActive(true);
    }

    public void OpenLeaderBoard()
    {

    }

}


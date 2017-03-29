using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuMapManager : MonoBehaviour
{
    public ItemMap[] itemMap;
    public ItemMap[] itemTutor;

    private int currIdPage;
    [SerializeField]
    private GameObject goPageTutor, goPage;
    [SerializeField]
    private MoneyButton btnCoin, btnDiamond;
   
    void Start()
    {
        pScreenManager.Instance.SetQueueUnlockScreen();
        SelectPage(0);

        if (Prefs.Instance.GetLevel() < 2)
        {
            SelectPage(0);
        }
        else
        {
            SelectPage((Prefs.Instance.GetLevel() - 2) / 8);
        }

        UpdateMoney();
    }


    public void SelectPage(int IDPage)
    {
        currIdPage = IDPage;
        if (currIdPage == 0)
        {
            goPageTutor.SetActive(true);
            goPage.SetActive(false);
            for (int i = 0; i < itemTutor.Length; i++)
            {
                itemTutor[i].SetupBoard(i, i + 1);
            }
        }
        else
        {
            goPageTutor.SetActive(false);
            goPage.SetActive(true);
            for (int i = 0; i < itemMap.Length; i++)
            {
                itemMap[i].SetupBoard((IDPage - 1) * 8 + i + 2, (IDPage - 1) * 8 + i + 1);
            }
        }
    }


    public void ChooseMap(ItemMap map)
    {
        Registry.CURR_ID_MAP = map.idLevel;
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_GAME);

    }

    public void OpenDailyQuest()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_DAILYQUEST, true);
    }

    public void OpenWeaponShop()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_STORE, true);
    }

    public void ClickBack()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_OUT, true);
    }
    public void UpdateMoney()
    {
        btnCoin.UpdateMoney();
        btnDiamond.UpdateMoney();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuMapManager : MonoBehaviour
{
    void Start()
    {
        pScreenManager.Instance.SetQueueUnlockScreen();
    }

    public void ChooseMap(ItemMap map)
    {
        Registry.CURR_ID_MAP = map.idLevel;
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_STORE, false);

    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuScreenManager : MonoBehaviour
{

    void Start()
    {
        pScreenManager.Instance.LoadLevel2(pScreenManager.SCREEN_INTRO_OUT,true);
    }
}


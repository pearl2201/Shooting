﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{

    void Start()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_INTRO);
    }

}


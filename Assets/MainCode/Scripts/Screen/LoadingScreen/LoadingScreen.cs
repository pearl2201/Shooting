using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class LoadingScreen : MonoBehaviour
{

    void Start()
    {
        pScreenManager.Instance.LoadLevel(pScreenManager.SCREEN_INTRO);
    }
}


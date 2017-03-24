using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class HelpScreenManager : MonoBehaviour
{

    public void Back()
    {
        pScreenManager.Instance.LoadBackScreen();
    }
}


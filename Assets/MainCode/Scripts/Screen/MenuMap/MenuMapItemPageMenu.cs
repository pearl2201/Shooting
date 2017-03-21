using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuMapItemPageMenu: MonoBehaviour
{
    public MenuMapManager menuMapManager;
    public int id;

    public void Click()
    {
        menuMapManager.SelectPage(id);
    }



}


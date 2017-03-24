using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    public MenuMapManager menuMapManager;

    public int idLevel;

    [SerializeField]
    private tk2dTextMesh txtMapName;
    public void SetupBoard(int levelBase, int nameLevel)
    {
        idLevel = levelBase;
        if (levelBase == 0)
        {
            txtMapName.text = "Tutor " + nameLevel;
        }
        else if (levelBase == 1)
        {
            txtMapName.text = "Tutor " + nameLevel;
        }
        else
        {
            txtMapName.text = "Map " + nameLevel;
        }
      
    }

    public void Click()
    {
        menuMapManager.ChooseMap(this);
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    public MenuMapManager menuMapManager;
    [HideInInspector]
    public int idLevel;
    [SerializeField]
    private int idInBoard;
    [SerializeField]
    private tk2dTextMesh txtMapName;
    public void SetupBoard(int levelBase)
    {
        idLevel = levelBase + idInBoard;
        txtMapName.text = "Map " + idLevel;
    }

    public void Click()
    {
        menuMapManager.ChooseMap(this);
    }

}


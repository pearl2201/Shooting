using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MissionDescriptionPopup : MonoBehaviour
{

    private tk2dTextMesh txtTitle;
    private tk2dTextMesh txtHint;

    public void Setup(DataMap dataMap)
    {
        txtHint.text = "Hint: " + dataMap.hint;
        txtTitle.text = "Level " + (dataMap.idMap + 1) + " " + dataMap.titleMap;
    }

    public void ClickPlay()
    {

    }
}


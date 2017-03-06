using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
public class CreateDataMap
{
    [MenuItem("Assets/Create/Inventory Item List")]
    public static DataMap Create()
    {
        /*
        DataMap asset = ScriptableObject.CreateInstance<DataMap>();
        AssetDatabase.CreateAsset(asset, "Assets/MainCode/Resources/DataMap/DataMap.asset");
        AssetDatabase.SaveAssets();
        return asset;
        */
        return null;
    }
}


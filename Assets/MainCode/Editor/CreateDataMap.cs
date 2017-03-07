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

    [MenuItem("Assets/Create/Item/PrimaryGun")]
    public static DataGun CreatePrimaryGun()
    {

        DataGun asset = ScriptableObject.CreateInstance<DataGun>();
        AssetDatabase.CreateAsset(asset, "Assets/MainCode/Resources/DataPrimaryGun/DataPrimaryGun.asset");
        AssetDatabase.SaveAssets();
        return asset;

    }

    [MenuItem("Assets/Create/Item/SecondaryGun")]
    public static DataGun CreateSecondaryGun()
    {

        DataGun asset = ScriptableObject.CreateInstance<DataGun>();
        AssetDatabase.CreateAsset(asset, "Assets/MainCode/Resources/DataSecondaryGun/DataSecondaryGun.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    [MenuItem("Assets/Create/Item/Bomb")]
    public static DataGrenade CreateGrenade()
    {

        DataGrenade asset = ScriptableObject.CreateInstance<DataGrenade>();
        AssetDatabase.CreateAsset(asset, "Assets/MainCode/Resources/DataGrenade/DataGrenade.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    [MenuItem("Assets/Create/Item/Equipment")]
    public static DataEquipment CreateEquipment()
    {

        DataEquipment asset = ScriptableObject.CreateInstance<DataEquipment>();
        AssetDatabase.CreateAsset(asset, "Assets/MainCode/Resources/DataEquipment/DataEquipment.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}


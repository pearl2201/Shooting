﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Prefs
{
    #region Default
    private static Prefs _instance;

    public static Prefs Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Prefs();
            }
            return _instance;
        }
    }
    // must = -1 when release
    private static string KEY_VERSION_CODE = "key_version_code";
    private static int VERSION_KEYCODE = -1;

    public Prefs()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey(KEY_VERSION_CODE))
        {
            if (PlayerPrefs.GetInt(KEY_VERSION_CODE) != VERSION_KEYCODE)
            {
                Init();
            }
            else
            {
                ReadData();
            }
        }
        else
        {
            Init();
        }
    }

    private int GetInt(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetInt(name);
        }
        else
            return 0;
    }

    private void SetInt(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
    }

    private bool GetBool(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            if (PlayerPrefs.GetInt(name) == 1)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    private void SetBool(string name, bool value)
    {
        if (value)
            PlayerPrefs.SetInt(name, 1);
        else
            PlayerPrefs.SetInt(name, 0);
        PlayerPrefs.Save();
    }

    private void SetString(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
        PlayerPrefs.Save();
    }

    private string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    private void SetFloat(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
        PlayerPrefs.Save();
    }

    private float GetFloat(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetFloat(name);
        }
        else
            return 0f;
    }

    #endregion default

    ///// KEYCODE DERCLARE
    private static string KEY_VOLUME_MUSIC = "volume_music";
    private static string KEY_VOLUME_SOUNDFX = "volume_soundfx";

    // list owner
    private static string KEY_PRIMARY_GUN_OWN = "primary_gun_own";
    private static string KEY_NO_BULLET_PRIMARY_GUN_OWN = "no_bullet_primary_gun";
    private static string KEY_SECONDARY_GUN_OWN = "secondary_gun_own";
    private static string KEY_ARMOR_OWN = "key_armor_own";
    private static string KEY_LEVEL_UPGRADE_PRIMARY_GUN = "key_upgrade_primary_gun";
    private static string KEY_LEVEL_UPGRADE_SECONDARY_GUN = "key_upgrade_secondary_gun";
    // list curr
    private static string KEY_CURR_PRIMARY_GUN = "curr_primary_gun";
    private static string KEY_CURR_SECONDARY_GUN = "curr_secondary_gun";
    private static string KEY_CURR_ARMOR = "curr_armor";
    private static string KEY_NO_BOMB = "no_bomb";

    private static string KEY_COIN_OWNER = "coin_owner";
    private static string KEY_DIAMOND_OWNER = "diamond_owner";
    private static string KEY_CHECK_IAP = "key_check_iap";

    private static string KEY_LEVEL = "key_level";
    private static string KEY_TOTAL_STAR = "key_total_star";

    private static string KEY_CURR_CHARACTER = "key_curr_character";
    private static string KEY_OWN_CHARACTER = "key_own_character";

    private static string KEY_LEVEL_ACHIVEMENT = "key_level_achivement";
    private static string KEY_VALUE_ACHIVEMENT = "key_value_achivement";

    private static string KEY_TYPE_DAILY = "key_type_daily";
    private static string KEY_REQ_DAILY = "key_re_daily";
    private static string KEY_CURR_DAILY = "key_curr_daily";
    private static string KEY_CURR_DAY = "key_day";

    private static string KEY_BESTSCORE_MAP = "key_best_score_map";
    private static string KEY_STAR_MAP = "key_star_map";

    ///// INIT

    void Init()
    {
        Debug.Log("Init");
        SetInt(KEY_VERSION_CODE, VERSION_KEYCODE);
        SetVolumeMusic(0);
        SetVolumeSoundFx(1);
        SetNoGrenade(10);
        SetCurrPrimaryGun(0);
        SetSecondaryGun(0);
        SetCurrArmor(0);
        SetBoughtPrimaryGun(0, true);
        SetBoughtSecondaryGun(0, true);
        SetBulletPrimaryGun(0, 450);
        SetCoin(3000000);
        // init



    }

    ///// READ DATA
    void ReadData()
    {

    }

    /// GET_SET

    public int GetLevel()
    {
        return GetInt(KEY_LEVEL);
    }

    public void SetLevel(int level)
    {
        SetInt(KEY_LEVEL, level);
    }

    public bool IsHadPurchaseItem(TYPE_IAP typeItem)
    {
        return GetBool(KEY_CHECK_IAP + typeItem);
    }

    public void SetHadPuchaseItem(TYPE_IAP typeItem)
    {
        SetBool(KEY_CHECK_IAP + typeItem, true);
    }

    public float GetVolumeSoundFx()
    {
        return GetFloat(KEY_VOLUME_SOUNDFX);
    }

    public float GetVolumeMusic()
    {
        return GetFloat(KEY_VOLUME_MUSIC);
    }

    public void SetVolumeSoundFx(float volume)
    {
        SetFloat(KEY_VOLUME_SOUNDFX, volume);
    }

    public void SetVolumeMusic(float volume)
    {
        SetFloat(KEY_VOLUME_MUSIC, volume);
    }

    public bool IsPrimaryGunBought(int id)
    {
        return GetBool(KEY_PRIMARY_GUN_OWN + id);
    }

    public bool IsSecondaryGunBought(int id)
    {
        return GetBool(KEY_SECONDARY_GUN_OWN + id);
    }

    public bool IsArmorBought(int id)
    {
        return GetBool(KEY_ARMOR_OWN + id);
    }

    public int GetNoBulletGun(int id)
    {
        return GetInt(KEY_NO_BULLET_PRIMARY_GUN_OWN + id);
    }

    public int GetNoGrenade()
    {
        return GetInt(KEY_NO_BOMB);
    }

    public void SetBoughtPrimaryGun(int id, bool isOwn)
    {
        SetBool(KEY_PRIMARY_GUN_OWN + id, isOwn);
    }

    public void SetBoughtSecondaryGun(int id, bool isOwn)
    {
        SetBool(KEY_SECONDARY_GUN_OWN, isOwn);
    }

    public void BuyBomb()
    {
        SetInt(KEY_NO_BOMB, GetNoGrenade() + 1);
    }

    public void SetNoGrenade(int nogrenade)
    {
        SetInt(KEY_NO_BOMB, nogrenade);
    }

    public void BuyBulletPrimaryGun(int id, int countTotal)
    {
        SetInt(KEY_NO_BULLET_PRIMARY_GUN_OWN + id, countTotal);
    }

    public void SetBulletPrimaryGun(int id, int noBullet)
    {
        SetInt(KEY_NO_BULLET_PRIMARY_GUN_OWN + id, noBullet);
    }
    public void AddCoin(int coin)
    {
        SetCoin(GetCoin() + coin);
    }

    public int GetCoin()
    {
        return GetInt(KEY_COIN_OWNER);
    }

    public void SubCoin(int coin)
    {
        SetCoin(GetCoin() - coin);
    }

    public void SetCoin(int coin)
    {
        SetInt(KEY_COIN_OWNER, coin);
    }

    public void AddDiamond(int diamond)
    {
        SetDiamond(GetDiamond() + diamond);
    }

    public int GetDiamond()
    {
        return GetInt(KEY_DIAMOND_OWNER);
    }

    public void SubDiamond(int diamond)
    {
        SetDiamond(GetDiamond() - diamond);
    }

    public void SetDiamond(int diamond)
    {
        SetInt(KEY_DIAMOND_OWNER, diamond);
    }

    public int GetCurrPrimaryGun()
    {
        return GetInt(KEY_CURR_PRIMARY_GUN);
    }

    public void SetCurrPrimaryGun(int id)
    {
        SetInt(KEY_CURR_PRIMARY_GUN, id);
    }

    public int GetCurrSecondaryGun()
    {
        return GetInt(KEY_CURR_SECONDARY_GUN);
    }

    public void SetSecondaryGun(int id)
    {
        SetInt(KEY_CURR_SECONDARY_GUN, id);
    }

    public void SetCurrArmor(int id)
    {
        SetInt(KEY_CURR_ARMOR, id);
    }

    public int GetCurrArmor()
    {
        return GetInt(KEY_CURR_ARMOR);
    }

    public int GetCurrCharacter()
    {
        return GetInt(KEY_CURR_CHARACTER);
    }

    public void SetCurrCharacter(int id)
    {
        SetInt(KEY_CURR_CHARACTER, id);
    }

    public void SetBoughtCharacter(int id, bool isBought)
    {
        SetBool(KEY_OWN_CHARACTER + id, isBought);
    }

    public bool IsHadBoughtCharacter(int id)
    {
        return GetBool(KEY_OWN_CHARACTER + id);
    }

    public int GetLevelAchivement(TYPE_ACHIVEMENT type)
    {
        return GetInt(KEY_LEVEL_ACHIVEMENT + type);
    }

    public void SetLevelAchivement(TYPE_ACHIVEMENT type, int value)
    {
        SetInt(KEY_LEVEL_ACHIVEMENT + type, value);
    }

    public bool IsAchivementFinish(TYPE_ACHIVEMENT type)
    {
        return GetBool(KEY_LEVEL_ACHIVEMENT + type);
    }

    public void SetAchivementFinish(TYPE_ACHIVEMENT type, bool isFinish)
    {
        SetBool(KEY_LEVEL_ACHIVEMENT + type, isFinish);
    }

    public int GetValueAchivement(TYPE_ACHIVEMENT type)
    {
        return GetInt(KEY_VALUE_ACHIVEMENT + type);
    }

    public void SetValueAchivement(TYPE_ACHIVEMENT type, int value)
    {
        SetInt(KEY_VALUE_ACHIVEMENT + type, value);
    }

    public int GetStarLevel(int level)
    {
        return GetInt(KEY_TOTAL_STAR + level);
    }

    public void SetStar(int level, int star)
    {
        int currStar = GetStarLevel(level);
        if (star > currStar)
        {
            SetInt(KEY_TOTAL_STAR + level, star);
        }
    }

    public TYPE_DAILYQUEST GetTypeDaily(int id)
    {
        return (TYPE_DAILYQUEST)GetInt(KEY_TYPE_DAILY + id);
    }

    public void SetTypeDaily(int id, TYPE_DAILYQUEST type)
    {
        SetInt(KEY_TYPE_DAILY + id, (int)type);
    }

    public void SetCurrValueDaily(int id, int value)
    {
        SetInt(KEY_CURR_DAILY + id, value);
    }

    public int GetCurrValueDaily(int id)
    {
        return GetInt(KEY_CURR_DAILY + id);
    }

    public void SetReqDaily(int id, int value)
    {
        SetInt(KEY_REQ_DAILY + id, value);
    }

    public int GetReqDaily(int id)
    {
        return GetInt(KEY_REQ_DAILY + id);
    }

    public string GetCurrDay()
    {
        return GetString(KEY_CURR_DAY);
    }

    public void SetDay(string day)
    {
        SetString(KEY_CURR_DAY, day);
    }

    public int GetBestScore(int id)
    {
        return GetInt(KEY_BESTSCORE_MAP + id);
    }

    public void SetBestScore(int id, int score)
    {
        int bestScore = GetBestScore(id);
        if (score > bestScore)
        {
            SetInt(KEY_BESTSCORE_MAP + id, score);
        }
    }

    public void SetLevelUpgradePrimaryGun(int id, int level)
    {
        SetInt(KEY_LEVEL_UPGRADE_PRIMARY_GUN + id, level);
    }

    public void SetLevelUpgradeSecondaryGun(int id, int level)
    {
        SetInt(KEY_LEVEL_UPGRADE_SECONDARY_GUN+ id, level);
    }

    public int GetLevelUpgradePrimaryGun(int id)
    {
        return GetInt(KEY_LEVEL_UPGRADE_PRIMARY_GUN + id);
    }

    public int GetLevelUpgradeSecondaryGun(int id)
    {
        return GetInt(KEY_LEVEL_UPGRADE_SECONDARY_GUN + id);
    }
}


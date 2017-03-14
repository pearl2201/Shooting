using System;
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

    }

    private void SetString(string name, string value)
    {
        PlayerPrefs.SetString(name, value);

    }

    private string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    private void SetFloat(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);

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

    // list curr
    private static string KEY_CURR_PRIMARY_GUN = "curr_primary_gun";
    private static string KEY_CURR_SECONDARY_GUN = "curr_secondary_gun";
    private static string KEY_CURR_ARMOR = "curr_armor";
    private static string KEY_NO_BOMB = "no_bomb";

    private static string KEY_COIN_OWNER = "coint_owner";

    ///// INIT

    void Init()
    {
        SetInt(KEY_VERSION_CODE, VERSION_KEYCODE);
        SetVolumeMusic(0);
        SetVolumeSoundFx(0);
        SetNoGrenade(10);
        SetCurrPrimaryGun(0);
        SetSecondaryGun(0);
        SetCurrArmor(0);
        SetBoughtPrimaryGun(0, true);
        SetBoughtSecondaryGun(0, true);
        SetBulletPrimaryGun(0, 450);
        // init



    }

    ///// READ DATA
    void ReadData()
    {

    }

    /// GET_SET

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

}


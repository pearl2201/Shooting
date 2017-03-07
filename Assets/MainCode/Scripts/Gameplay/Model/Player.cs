using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{

    public AbstractGun currGun;
    public int noGrenade;
    public DataEquipment dataEquipment;
    public DataGrenade dataGrenade;
    public AbstractGun dataPrimaryGun;
    public AbstractGun dataSecondaryGun;
    public int hp;
    private GameManager gameManager;


    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
        hp = 100;
        {
            GameObject goPrefab = Resources.Load<GameObject>("PrimaryGun/" + Prefs.Instance.GetCurrPrimaryGun());
            dataPrimaryGun = Instantiate(goPrefab).GetComponent<AbstractGun>();
            dataPrimaryGun.noBullet = Prefs.Instance.GetNoBulletGun(dataPrimaryGun.dataGun.id);
            dataPrimaryGun.transform.SetParent(transform);
            dataPrimaryGun.transform.localPosition = Vector3.zero;
        }
        {
            GameObject goPrefab = Resources.Load<GameObject>("Secondary/" + Prefs.Instance.GetCurrSecondaryGun());
            dataPrimaryGun = Instantiate(goPrefab).GetComponent<AbstractGun>();
            dataPrimaryGun.noBullet = Prefs.Instance.GetNoBulletGun(dataPrimaryGun.dataGun.id);
            dataPrimaryGun.transform.SetParent(transform);
            dataPrimaryGun.transform.localPosition = Vector3.zero;
        }
        {
            dataGrenade = Resources.Load<DataGrenade>("");
            dataEquipment = Resources.Load<DataEquipment>("");
            noGrenade = Prefs.Instance.GetNoGrenade();
        }
    }

    public void Reset()
    {

    }

    public void Shooting()
    {

    }

    public void Recharge()
    {

    }
}


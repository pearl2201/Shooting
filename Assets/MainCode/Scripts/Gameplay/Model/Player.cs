using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour, IPoolObj
{
    [HideInInspector]
    public AbstractGun currGun;
    [HideInInspector]
    public int noGrenade;
    [HideInInspector]
    public DataEquipment dataEquipment;
    [HideInInspector]
    public DataGrenade dataGrenade;
    [HideInInspector]
    public AbstractGun primaryGun;
    [HideInInspector]
    public AbstractGun secondaryGun;
    [SerializeField]
    private GameObject sprBeAttacked;
    public int hp;

    private GameManager gameManager;

    public PLAYER_STATE playerState;
    public TYPE_PLAYER_GUN currTypeGun;
    public IEnumerator crtBeAttacked;

    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
        hp = 100;
        {
            GameObject goPrefab = PoolPrefabLookupManager.LookPrefab("PrimaryGun" + Prefs.Instance.GetCurrPrimaryGun());
            primaryGun = PoolManager.SpawnObject(goPrefab).GetComponent<AbstractGun>();
            primaryGun.noBullet = Prefs.Instance.GetNoBulletGun(primaryGun.dataGun.id);
            primaryGun.transform.SetParent(transform);
            primaryGun.transform.localPosition = Vector3.zero;
            primaryGun.gameObject.SetActive(false);
        }
        {
            GameObject goPrefab = PoolPrefabLookupManager.LookPrefab("Secondary" + Prefs.Instance.GetCurrSecondaryGun());
            secondaryGun = PoolManager.SpawnObject(goPrefab).GetComponent<AbstractGun>();
            secondaryGun.noBullet = secondaryGun.dataGun.totalBullet;
            secondaryGun.noBulletActive = Mathf.Min(secondaryGun.dataGun.noBulletPerCharge, secondaryGun.noBullet);
            secondaryGun.transform.SetParent(transform);
            secondaryGun.transform.localPosition = Vector3.zero;
            secondaryGun.gameObject.SetActive(false);
        }
        {
            dataGrenade = Resources.Load<DataGrenade>("DataGrenade/Grenade");
            dataEquipment = Resources.Load<DataEquipment>("DataEquipment/" + Prefs.Instance.GetCurrArmor());
            noGrenade = Prefs.Instance.GetNoGrenade();
        }
        {
            if (primaryGun.noBullet == 0)
            {
                currGun = secondaryGun;
                currTypeGun = TYPE_PLAYER_GUN.SECONDARY_GUN;
            }
            else
            {
                currGun = primaryGun;
                currTypeGun = TYPE_PLAYER_GUN.PRIMARY_GUN;
            }
        }
        playerState = PLAYER_STATE.FREE;

        {
            // fake data:
            noGrenade = 10;
        }


    }

    public void Reset()
    {

    }

    public void Shooting()
    {
        if (playerState == PLAYER_STATE.FREE)
        {
            if (currGun.noBulletActive > 0)
            {
                StartCoroutine(IEShooting());
            }
            else
            {
                Recharge();
            }

        }

    }

    IEnumerator IEShooting()
    {
        Debug.Log("shoot");
        playerState = PLAYER_STATE.SHOOT;
        yield return new WaitForSeconds(Constants.DEFAULT_SPEED_SHOOTING * (10 - currGun.dataGun.firerate) / 10);
        RaycastHit hit;

        if (Physics.Raycast(currGun.tieucu.transform.position, (currGun.tieucu.transform.position - gameManager.currAim.pCam.transform.position) * 10, out hit))

        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("hit");
               
                EnemyComponents enemyComponents = hit.collider.GetComponent<EnemyComponents>();
                if (enemyComponents != null)
                {
                    enemyComponents.GetHit(currGun.dataGun.damage, hit.point,false);
                }
            }
        }
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
        {
            currGun.noBullet--;
            currGun.noBulletActive--;
            if (currGun.noBullet == 0)
            {
                ChangeGun();
            }
            else
            {
                gameManager.UpdateUiChangeGun();
            }
        }
        else
        {

            currGun.noBulletActive--;
            gameManager.UpdateUiChangeGun();
        }

        playerState = PLAYER_STATE.FREE;
    }


    public void ShootGrenade()
    {
        if (playerState == PLAYER_STATE.FREE && noGrenade > 0)
        {
            StartCoroutine(IEShootGrenade());
        }
    }

    IEnumerator IEShootGrenade()
    {
        playerState = PLAYER_STATE.SHOOT;
        yield return new WaitForSeconds(Constants.DEFAULT_SPEED_SHOOTING * (10 - dataGrenade.firerate) / 10);
        Vector3 speedGrenade = Vector3.Normalize((currGun.tieucu.transform.position - gameManager.currAim.pCam.transform.position))*20;
        PlayerGrenade pGrenade = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("PlayerGrenade")).GetComponent<PlayerGrenade>();
        pGrenade.Setup(gameManager, speedGrenade, currGun.tieucu.transform.position);
        noGrenade--;
        gameManager.UpdateUIGrenade();
        playerState = PLAYER_STATE.FREE;
    }

    public void Recharge()
    {
        if (playerState == PLAYER_STATE.FREE)
        {
            StartCoroutine(IERecharge());
        }
    }

    IEnumerator IERecharge()
    {
        playerState = PLAYER_STATE.CHARGE;
        yield return new WaitForSeconds(1f);
        currGun.noBulletActive = currGun.dataGun.noBulletPerCharge;
        gameManager.UpdateUiChangeGun();
        playerState = PLAYER_STATE.FREE;

    }

    public void ChangeGun()
    {
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
        {
            currGun = secondaryGun;
            primaryGun.gameObject.SetActive(false);
            secondaryGun.gameObject.SetActive(true);
        }
        else
        {
            if (primaryGun.noBullet > 0)
            {
                currGun = primaryGun;
                primaryGun.gameObject.SetActive(true);
                secondaryGun.gameObject.SetActive(false);
            }
            else
            {
                // do nothing
            }
        }
    }

    public void BeAttack(int damage)
    {
        Debug.Log("be attack");
        hp -= damage;
        if (crtBeAttacked != null)
        {
            StopCoroutine(crtBeAttacked);
        }
        crtBeAttacked = IEBeAttack();
        StartCoroutine(crtBeAttacked);

        if (hp <= 0)
        {
            gameManager.LoseGame();
        }
        else
        {


        }
    }

    IEnumerator IEBeAttack()
    {
        sprBeAttacked.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        sprBeAttacked.gameObject.SetActive(false);
    }


}


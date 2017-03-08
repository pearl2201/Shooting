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
            GameObject goPrefab = Resources.Load<GameObject>("PrimaryGun/" + Prefs.Instance.GetCurrPrimaryGun());
            primaryGun = Instantiate(goPrefab).GetComponent<AbstractGun>();
            primaryGun.noBullet = Prefs.Instance.GetNoBulletGun(primaryGun.dataGun.id);
            primaryGun.transform.SetParent(transform);
            primaryGun.transform.localPosition = Vector3.zero;
        }
        {
            GameObject goPrefab = Resources.Load<GameObject>("Secondary/" + Prefs.Instance.GetCurrSecondaryGun());
            primaryGun = Instantiate(goPrefab).GetComponent<AbstractGun>();
            primaryGun.noBullet = Prefs.Instance.GetNoBulletGun(primaryGun.dataGun.id);
            primaryGun.noBulletActive = Mathf.Min(primaryGun.dataGun.noArmoPerCharge, primaryGun.noBullet);
            primaryGun.transform.SetParent(transform);
            primaryGun.transform.localPosition = Vector3.zero;
        }
        {
            dataGrenade = Resources.Load<DataGrenade>("Grenade/Grenade");
            dataEquipment = Resources.Load<DataEquipment>("Equipment/" + Prefs.Instance.GetCurrArmor());
            noGrenade = Prefs.Instance.GetNoGrenade();
        }
        {
            if (primaryGun.noBullet == 0)
            {
                currGun = secondaryGun;
            }
            else
            {
                currGun = primaryGun;
            }
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
        playerState = PLAYER_STATE.SHOOT;
        yield return new WaitForSeconds(Constants.DEFAULT_SPEED_SHOOTING * (10 - currGun.dataGun.firerate) / 10);
        RaycastHit hit;

        if (Physics.Raycast(currGun.tieucu.transform.position, (currGun.tieucu.transform.position - gameManager.currAim.pCam.transform.position) * 10, out hit))

        {
            if (hit.collider.tag == "Enemy")
            {
                EnemyComponents enemyComponents = hit.collider.GetComponent<EnemyComponents>();
                if (enemyComponents != null)
                {
                    enemyComponents.GetHit(currGun.dataGun.damage);
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
        currGun.noBulletActive = currGun.dataGun.noArmoPerCharge;
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
        hp -= damage;
        if (hp <= 0)
        {
            gameManager.LoseGame();
        }
        else
        {
            if (crtBeAttacked != null)
            {
                StopCoroutine(crtBeAttacked);
            }
            crtBeAttacked = IEBeAttack();
            StopCoroutine(crtBeAttacked);

        }
    }

    IEnumerator IEBeAttack()
    {
        sprBeAttacked.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sprBeAttacked.gameObject.SetActive(false);
    }


}


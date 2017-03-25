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
    public int energy;

    private GameManager gameManager;

    public PLAYER_STATE playerState;
    public TYPE_PLAYER_GUN currTypeGun;
    public IEnumerator crtBeAttacked;
    [SerializeField]
    private GameObject parentGun;

    [SerializeField]
    private GameObject[] listSprChargeGun;

    public DataCharacter dataCharacter;
    public void Setup(GameManager gameManager)
    {
        this.gameManager = gameManager;
        hp = 100;
        energy = 0;
        {
            GameObject goPrefab = PoolPrefabLookupManager.LookPrefab("PrimaryGun" + Prefs.Instance.GetCurrPrimaryGun());
            primaryGun = PoolManager.SpawnObject(goPrefab).GetComponent<AbstractGun>();
            primaryGun.noBullet = Prefs.Instance.GetNoBulletGun(primaryGun.dataGun.id);
            primaryGun.noBulletActive = Mathf.Min(primaryGun.dataGun.noBulletPerCharge, primaryGun.noBullet);
            primaryGun.noBullet -= primaryGun.noBulletActive;
            primaryGun.transform.SetParent(parentGun.transform);
            primaryGun.transform.localPosition = Vector3.zero;
            primaryGun.gameObject.SetActive(false);
            Debug.Log("no bullet primary Gun: " + primaryGun.noBullet);
        }
        {
            GameObject goPrefab = PoolPrefabLookupManager.LookPrefab("Secondary" + Prefs.Instance.GetCurrSecondaryGun());
            secondaryGun = PoolManager.SpawnObject(goPrefab).GetComponent<AbstractGun>();
            secondaryGun.noBullet = secondaryGun.dataGun.totalBullet;
            secondaryGun.noBulletActive = Mathf.Min(secondaryGun.dataGun.noBulletPerCharge, secondaryGun.noBullet);
            secondaryGun.noBullet -= secondaryGun.noBulletActive;
            secondaryGun.transform.SetParent(parentGun.transform);
            secondaryGun.transform.localPosition = Vector3.zero;
            secondaryGun.gameObject.SetActive(false);
        }
        {
            dataGrenade = Resources.Load<DataGrenade>("DataGrenade/Grenade");
            dataEquipment = Resources.Load<DataEquipment>("DataEquipment/" + Prefs.Instance.GetCurrArmor());
            dataCharacter = Resources.Load<DataCharacter>("DataCharacter/" + Prefs.Instance.GetCurrCharacter());
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


    void LateUpdate()
    {
        Vector3 posGun = parentGun.transform.position;
        posGun.x = Mathf.Clamp(posGun.x, -Constants.MARGIN_GUN_TOP_X, Constants.MARGIN_GUN_TOP_X);
        posGun.y = Mathf.Clamp(posGun.y, Constants.MARGIN_GUN_BOT_Y, Constants.MARGIN_GUN_TOP_Y);
        parentGun.transform.position = posGun;


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
        energy += 2;
        if (energy >= 100)
        {
            energy = 100;
        }
        gameManager.UpdateUIEnergy();
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
        {
            SoundManager.Instance.Play("primaryShot");
        }
        else
        {
            SoundManager.Instance.Play("primaryShot");
        }
        Vector3 oriTieuCu = currGun.tieucu.transform.position;
        float x = UnityEngine.Random.Range(-Constants.DEFAULT_DISTANCE_ACCURACY * (10 - currGun.dataGun.accuracy), Constants.DEFAULT_DISTANCE_ACCURACY * (10 - currGun.dataGun.accuracy));
        float y = UnityEngine.Random.Range(-Constants.DEFAULT_DISTANCE_ACCURACY * (10 - currGun.dataGun.accuracy), Constants.DEFAULT_DISTANCE_ACCURACY * (10 - currGun.dataGun.accuracy));
        // currGun.transform.position += new Vector3(x, y, 0);
        iTween.MoveTo(currGun.gameObject, iTween.Hash("position", currGun.transform.position + new Vector3(x, y, 0), "time", Constants.DEFAULT_SPEED_SHOOTING * (10 - currGun.dataGun.firerate) / 10, "easetype", iTween.EaseType.easeOutElastic));
        yield return new WaitForSeconds(Constants.DEFAULT_SPEED_SHOOTING * (10 - currGun.dataGun.firerate) / 10);
        SoundManager.Instance.Play("explo");

        RaycastHit hit;
        bool hitSuccess = false;
        if (Physics.Raycast(oriTieuCu, (oriTieuCu - gameManager.currAim.pCam.transform.position) * 10, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("hit");
                hitSuccess = true;
                EnemyComponents enemyComponents = hit.collider.GetComponent<EnemyComponents>();
                if (enemyComponents != null)
                {
                    enemyComponents.GetHit(currGun.dataGun.damage, hit.point, false);
                }
            }
            else
            {
                GameObject go = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("hit"));
                go.transform.position = hit.point;
                AutoPool.AttackPool(go, 2f);
            }
        }
        gameManager.AddCountShooting();
        if (hitSuccess)
        {
            gameManager.AddCountShootingSuccess();
            if (currTypeGun == TYPE_PLAYER_GUN.SECONDARY_GUN)
            {
                gameManager.infoGame.countSecondaryKill++;
            }
            else
            {
                gameManager.infoGame.countPrimaryKill++;
            }
        }
           
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
        {

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
        // Move gun:



        playerState = PLAYER_STATE.FREE;

        if ((gameManager.currGameState == GAME_STATE.PLAY || gameManager.currGameState == GAME_STATE.TRANSFER || gameManager.currGameState == GAME_STATE.SETUP) && gameManager.isKeepTouchShoot)
        {
            Shooting();
        }
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
        energy += 5;
        if (energy >= 100)
        {
            energy = 100;
        }
        gameManager.UpdateUIEnergy();
        playerState = PLAYER_STATE.SHOOT;
        SoundManager.Instance.Play("primaryShot");
        yield return new WaitForSeconds(Constants.DEFAULT_SPEED_SHOOTING * (10 - dataGrenade.firerate) / 10);
        Vector3 speedGrenade = Vector3.Normalize((currGun.tieucu.transform.position - gameManager.currAim.pCam.transform.position)) * 20;
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
            if (currGun.noBullet > 0)
            {
                StartCoroutine(IERecharge());
            }
            else
            {
                ChangeGun();
            }

        }
    }

    IEnumerator IERecharge()
    {
        if (currGun != null)
        {
            currGun.gameObject.SetActive(false);
        }
        playerState = PLAYER_STATE.CHARGE;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                listSprChargeGun[j].gameObject.SetActive(true);
            }
            for (int j = i + 1; j < 8; j++)
            {
                listSprChargeGun[j].gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.25f);
        }
        currGun.noBulletActive = Mathf.Min(currGun.dataGun.noBulletPerCharge, currGun.noBullet);
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
            currGun.noBullet -= currGun.noBulletActive;
        gameManager.UpdateUiChangeGun();
        for (int j = 0; j < 8; j++)
        {
            listSprChargeGun[j].gameObject.SetActive(false);
        }
        playerState = PLAYER_STATE.FREE;
        if (currGun != null)
        {
            currGun.gameObject.SetActive(true);
        }

    }

    public void ClickUseEnergy()
    {
        if (energy == 100 && playerState == PLAYER_STATE.FREE)
        {
            StartCoroutine(IEUseEnergy());
        }
    }


    IEnumerator IEUseEnergy()
    {
        yield return null;
    }

    public void ChangeGun()
    {
        Vector3 oldPos = currGun.transform.position;
        if (currTypeGun == TYPE_PLAYER_GUN.PRIMARY_GUN)
        {

            bool stateCurrGun = currGun.gameObject.activeSelf;
            currGun = secondaryGun;
            primaryGun.gameObject.SetActive(false);
            secondaryGun.gameObject.SetActive(stateCurrGun);
            currTypeGun = TYPE_PLAYER_GUN.SECONDARY_GUN;
            currGun.transform.position = oldPos;
            gameManager.UpdateUiChangeGun();
        }
        else
        {
            if (primaryGun.noBullet > 0)
            {

                bool stateCurrGun = currGun.gameObject.activeSelf;
                currGun = primaryGun;
                primaryGun.gameObject.SetActive(stateCurrGun);
                secondaryGun.gameObject.SetActive(false);
                currTypeGun = TYPE_PLAYER_GUN.PRIMARY_GUN;
                currGun.transform.position = oldPos;
                gameManager.UpdateUiChangeGun();
            }
            else
            {
                // do nothing
            }
        }
    }

    public void BeAttack(int damage)
    {

        SoundManager.Instance.Play("explo");
        hp -= damage;
        gameManager.AddDamagePlayerTake(damage);
        if (hp < 0)
        {
            hp = 0;
        }
        energy += 5;
        if (energy >= 100)
        {
            energy = 100;
        }
        gameManager.UpdateUIEnergy();
        gameManager.UpdateUIHp();
        if (crtBeAttacked != null)
        {
            StopCoroutine(crtBeAttacked);
        }
        crtBeAttacked = IEBeAttack();
        StartCoroutine(crtBeAttacked);

        if (hp <= 0)
        {
            gameManager.LoseGame();
            SoundManager.Instance.Play("playerDeath");
        }
        else
        {
            SoundManager.Instance.Play("playerHurt");

        }
    }

    IEnumerator IEBeAttack()
    {
        {
            iTween itScript = gameManager.currAim.pCam.GetComponent<iTween>();
            if (itScript != null)
            {
                Destroy(itScript);
            }
            else
            {
                iTween.ShakePosition(gameManager.currAim.pCam.gameObject, new Vector3(1f, 1f, 1f), 0.4f);
            }
        }


        sprBeAttacked.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);


        sprBeAttacked.gameObject.SetActive(false);
    }


}


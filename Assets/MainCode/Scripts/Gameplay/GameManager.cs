using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private DataMap dataMap;
    [SerializeField]
    private Player player;
    private int turnPhaze;
    private InfoGame infoGame;
    public GAME_STATE currGameState;
    [HideInInspector]
    public GAME_STATE oldGameState;

    private List<AbstractEnemy> listCurrEnemy;

    [SerializeField]
    private EndGamePopup popupEndGame;
    [SerializeField]
    private PauseGamePopup popupPauseGame;
    [HideInInspector]
    public AbstractStrategyAimGun currAim;
    [SerializeField]
    private RelativeAimStrategy relativeAimStg;
    [SerializeField]
    private ScaleAimStrategy scaleAimStg;

    [SerializeField]
    private tk2dTextMesh txtStart, txtHp, txtNoGrenade, txtNoEnemy, txtBullet;
    [SerializeField]
    private tk2dSprite sprPrimaryGun, sprSecondaryGun;
    private int vStart, noEnemy;
    private float cdrUpdate;
    private List<AbstractEnemy> listPrefabEnemyInit;
  

    public Transform rootEnemy;

    void Start()
    {
        listPrefabEnemyInit = new List<AbstractEnemy>();
        listCurrEnemy = new List<AbstractEnemy>();
        currGameState = GAME_STATE.SETUP;
        currAim = relativeAimStg;
        SetupInfo();
    }


    public void Reset()
    {

    }


    void Update()
    {
        if (currGameState == GAME_STATE.START)
        {
            cdrUpdate += Time.deltaTime;
            if (cdrUpdate >= 1)
            {
                vStart--;
                if (vStart == -1)
                {
                    SetupPlay();
                }
                else
                {
                    txtStart.text = vStart.ToString();
                    cdrUpdate = 0;
                }
            }
        }
        else if (currGameState == GAME_STATE.END)
        {

        }
        else if (currGameState == GAME_STATE.PLAY)
        {
            if (listCurrEnemy.Count > 0)
            {

            }
            else
            {
                turnPhaze++;
                if (turnPhaze == dataMap.listFakeTurnSpawn.Length)
                {
                    WinGame();
                }
                else
                {
                    SetupPhaze(turnPhaze);
                }
            }
        }
    }

    void SetupInfo()
    {
        currGameState = GAME_STATE.SETUP;

        // count no enemy
        noEnemy = 0;
        for (int i = 0; i < dataMap.listFakeTurnSpawn.Length; i++)
        {
            for (int j = 0; j < dataMap.listFakeTurnSpawn[i].listEnemyBase.Length; j++)
            {
                if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
                {
                    noEnemy += dataMap.listFakeTurnSpawn[i].listEnemyBase[j].noSpawn;
                }
                else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
                {
                    noEnemy++;
                }
            }
        }
        player.Setup(this);
        infoGame = new InfoGame(noEnemy);
        cdrUpdate = 0;
        vStart = 3;
        txtStart.text = vStart.ToString();
        txtStart.gameObject.SetActive(true);
        currGameState = GAME_STATE.START;
    }

    public void SetupPlay()
    {
        txtStart.gameObject.SetActive(false);
        player.currGun.gameObject.SetActive(true);
        turnPhaze = 0;
        SetupPhaze(turnPhaze);
    }

    public void SetupPhaze(int phaze)
    {
        currGameState = GAME_STATE.SETUP;
        EnemyBase[] listEnemyGen = dataMap.GetDataSpawn()[phaze].listEnemyBase;

        for (int i = 0; i < listEnemyGen.Length; i++)
        {
            if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
            {
                DataMoveFixedShoot dt = (DataMoveFixedShoot)listEnemyGen[i];
                GameObject prefab = null;
                if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.SHOOT)
                {
                    prefab = PoolPrefabLookupManager.LookPrefab("AttackShoot" + dt.idEnemy);
                    EnemyMoveShootBullet enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyMoveShootBullet>();
                    enemy.transform.position = dataMap.listLineMoveShooting[dt.idLineMoveShoot].startP;
                    enemy.transform.SetParent(rootEnemy);
                    enemy.Setup(this, dt, dataMap.listLineMoveShooting[dt.idLineMoveShoot]);
                    listCurrEnemy.Add(enemy);
                }
                else if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.SHOOT_GRENADE)
                {
                    prefab = PoolPrefabLookupManager.LookPrefab("AttackShootGrenade" + dt.idEnemy);
                }
                else if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.KNIFE)
                {
                    prefab = PoolPrefabLookupManager.LookPrefab("Melee" + dt.idEnemy);
                }

            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
            {
                DataMoveRandShoot dt = (DataMoveRandShoot)listEnemyGen[i];
                GameObject prefab = null;
                for (int j = 0; j < dt.noSpawn; j++)
                {
                    if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.SHOOT)
                    {
                        prefab = PoolPrefabLookupManager.LookPrefab("AttackShoot" + dt.idEnemy);
                        EnemyMoveShootBullet enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyMoveShootBullet>();
                        int idLineMoving = UnityEngine.Random.Range(0, dataMap.listLineMoveShooting.Length);
                        enemy.transform.position = dataMap.listLineMoveShooting[idLineMoving].startP;
                        enemy.transform.SetParent(rootEnemy);
                        enemy.Setup(this, dt, dataMap.listLineMoveShooting[idLineMoving]);
                        listCurrEnemy.Add(enemy);
                    }
                    else if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.SHOOT_GRENADE)
                    {
                        prefab = PoolPrefabLookupManager.LookPrefab("AttackShootGrenade" + dt.idEnemy);
                    }
                    else if (dt.typeEnemyAtk == TYPE_ENEMY_ATTACK.KNIFE)
                    {
                        prefab = PoolPrefabLookupManager.LookPrefab("AttackKnife" + dt.idEnemy);
                    }
                }
            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.MOVING)
            {
                DataMoveEnemy dt = (DataMoveEnemy)listEnemyGen[i];
                GameObject prefab = PoolPrefabLookupManager.LookPrefab("EnemyMove" + dt.idEnemy);
                EnemyMovingItem enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyMovingItem>();
                enemy.transform.position = dataMap.listLineMoveShooting[dt.idLineMove].startP;
                enemy.transform.SetParent(rootEnemy);
                enemy.Setup(this, dt, dataMap.listLineMoveShooting[dt.idLineMove]);

            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.STATIC_BOMB)
            {
                DataBomb dt = (DataBomb)listEnemyGen[i];
                GameObject prefab = PoolPrefabLookupManager.LookPrefab("StaticBomb" + dt.idEnemy);
                EnemyBombItem enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyBombItem>();
                enemy.transform.position = dt.pos;
                enemy.transform.SetParent(rootEnemy);
                enemy.Setup(this, dt);
            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.STATIC_DEF)
            {
                DataDefObj dt = (DataDefObj)listEnemyGen[i];
                GameObject prefab = PoolPrefabLookupManager.LookPrefab("StaticBomb" + dt.idEnemy);
                EnemyDefItem enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyDefItem>();
                enemy.transform.position = dt.pos;
                enemy.transform.SetParent(rootEnemy);
                enemy.Setup(this, dt);
            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.STATIC_GOLD)
            {
                DataCoinObj dt = (DataCoinObj)listEnemyGen[i];
                GameObject prefab = PoolPrefabLookupManager.LookPrefab("StaticBomb" + dt.idEnemy);
                EnemyCoinItem enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyCoinItem>();
                enemy.transform.position = dt.pos;
                enemy.transform.SetParent(rootEnemy);
                enemy.Setup(this, dt);
            }
            else if (listEnemyGen[i].typeEnemy == TYPE_ENEMY.STATIC_HP)
            {
                DataHpObj dt = (DataHpObj)listEnemyGen[i];
                GameObject prefab = PoolPrefabLookupManager.LookPrefab("StaticBomb" + dt.idEnemy);
                EnemyHpItem enemy = PoolManager.Instance.spawnObject(prefab).GetComponent<EnemyHpItem>();
                enemy.transform.position = dt.pos;
                enemy.transform.SetParent(rootEnemy);
                enemy.Setup(this, dt);
            }
        }


        currGameState = GAME_STATE.PLAY;
    }


    public void CreateGoldItemAt(Vector3 pos)
    {

    }

    public void CreateHpItemAt(Vector3 pos)
    {

    }

    public void WinGame()
    {
        currGameState = GAME_STATE.END;
        SetupPopupEndGame(true);
    }

    public void LoseGame()
    {
        currGameState = GAME_STATE.END;
        SetupPopupEndGame(false);
    }

    public void SetupPopupEndGame(bool isSuccess)
    {
        popupEndGame.gameObject.SetActive(true);
    }

    public void RemoveEnemy(AbstractEnemy enemy)
    {
        if (listCurrEnemy.Contains(enemy)) ;
        listCurrEnemy.Remove(enemy);
        PoolManager.Instance.releaseObject(enemy.gameObject);
    }

    public void AddHp(int hp)
    {
        player.hp += hp;
        player.hp = Mathf.Clamp(0, player.hp, 100);
        txtHp.text = player.hp.ToString();
    }

    public void AddCoin(int coin)
    {

        infoGame.coin += coin;

    }

    public void AddDamagePlayerTake(int damage)
    {
        infoGame.damageTaken += damage;
    }

    public void ClickShooting()
    {
        player.Shooting();
    }

    public void ClickChangeGun()
    {
        player.ChangeGun();
    }

    public void UpdateUiChangeGun()
    {
        txtBullet.text = player.currGun.noBulletActive + "//" + player.currGun.noBullet;
    }

    public void UpdateUIGrenade()
    {
        txtNoGrenade.text = player.noGrenade.ToString();
    }

    public void UpdateUIHp()
    {

        txtHp.text = player.hp.ToString();
    }

    public void UpdateUINoEnemy()
    {
        txtNoEnemy.text = noEnemy.ToString();
    }

    public void AttackPlayer(int damage)
    {
        player.BeAttack(damage);
    }


    public void ClickUseGrenade()
    {
        player.ShootGrenade();
    }

    public void ClickChargeGun()
    {
        player.ChangeGun();
    }

    public void ClickPause()
    {
        if (currGameState != GAME_STATE.PAUSE)
        {
            oldGameState = currGameState;
            currGameState = GAME_STATE.PAUSE;
            popupPauseGame.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            currGameState = oldGameState;
            Time.timeScale = 1;
            popupPauseGame.gameObject.SetActive(false);
        }
    }
}

public class InfoGame
{
    public int damageTaken;

    public int coin;
    public int countShooting;
    public int countShootingSuccess;
    public int countEnemyKill;
    public int countEnemy;

    public InfoGame(int countEnemy)
    {
        this.damageTaken = 0;

        this.coin = 0;
        this.countShooting = 0;
        this.countShootingSuccess = 0;
        this.countEnemyKill = 0;
        this.countEnemy = countEnemy;
    }



}
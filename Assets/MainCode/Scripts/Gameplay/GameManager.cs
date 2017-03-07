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
    private int turnPhaze;
    private InfoGame infoGame;
    public GAME_STATE currGameState;
    public GAME_STATE oldGameState;

    private List<EnemyBase> listCurrEnemy;

    [SerializeField]
    private EndGamePopup popupEndGame;

    void Start()
    {
        currGameState = GAME_STATE.SETUP;
        SetupInfo();
    }

    void Update()
    {
        if (currGameState == GAME_STATE.START)
        {

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

        currGameState = GAME_STATE.START;
    }

    public void SetupPhaze(int phaze)
    {
        currGameState = GAME_STATE.SETUP;
    }

    public void WinGame()
    {
        currGameState = GAME_STATE.END;
    }

    public void LoseGame()
    {
        currGameState = GAME_STATE.END;
    }

    public void SetupPopupEndGame()
    {

    }

    public void RemoveEnemy(EnemyBase enemy)
    {

    }

    public void AddHp()
    {

    }

    public void AddCoin()
    {

    }

    public void ClickShooting()
    {

    }

    public void ClickChangeGun()
    {

    }

    public void ClickUseGrenade()
    {

    }

    public void ClickChargeGun()
    {

    }

    public void ClickPause()
    {

    }
}

public class InfoGame
{
    public int hp;
    public int countBomb;
    public int countBulletPrimaryGun;
    public int countTotalBulletPrimaryGun;
    public int coin;
    public int countShooting;
    public int countShootingSuccess;
    public int countEnemyKill;
    public int countEnemy;

    public InfoGame(int countBomb, int countBulletPrimaryGun, int countTotalBulletPrimaryGun, int countEnemy)
    {
        this.hp = 100;
        this.countBomb = countBomb;
        this.countBulletPrimaryGun = countBulletPrimaryGun;
        this.countTotalBulletPrimaryGun = countTotalBulletPrimaryGun;
        this.coin = 0;
        this.countShooting = 0;
        this.countShootingSuccess = 0;
        this.countEnemyKill = 0;
        this.countEnemy = countEnemy;
    }



}
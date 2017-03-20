﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyCoinItem : AbstractEnemy
{
    [HideInInspector]
    public DataCoinObj mDataAttack;




    public void Setup(GameManager gameManager, DataCoinObj mDataAttack)
    {
        base.Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataCoinObj)dataPeople;

        phaze = ENEMY_PHAZE.PLAY;
    }




    public override void Dying()
    {
        phaze = ENEMY_PHAZE.FINISH;
        gameManager.AddCoin((int)mDataAttack.moneyAddition);
        gameManager.RemoveEnemy(this);

    }


    public override void GetHit(int damage, Vector3 hitPoint, bool isGrenade)
    {
        if (phaze == ENEMY_PHAZE.PLAY)
        {
            dataPeople.hp -= damage;
            isFullHp = false;

            ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("hit")).GetComponent<ParticleSystem>();
            ps.transform.position = hitPoint;
            ps.Play();


            AutoPool.AttackPool(ps.gameObject, ps.duration);

            Dying();
        }



    }
}


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyCoinItem : AbstractEnemy
{

    public DataCoinObj mDataAttack;




    public void Setup(GameManager gameManager, DataCoinObj mDataAttack)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataCoinObj)dataPeople;

        phaze = ENEMY_PHAZE.WAIT;
    }




    public override void Dying()
    {


    }
}


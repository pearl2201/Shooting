using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyHpItem : AbstractEnemy
{

    public DataHpObj mDataAttack;




    public void Setup(GameManager gameManager, DataHpObj mDataAttack)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataHpObj)dataPeople;

        phaze = ENEMY_PHAZE.WAIT;
    }




    public override void Dying()
    {


    }
}


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyDefItem : AbstractEnemy
{
    [HideInInspector]
    public DataDefObj mDataAttack;




    public void Setup(GameManager gameManager, DataDefObj mDataAttack)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataDefObj)dataPeople;

        phaze = ENEMY_PHAZE.WAIT;
    }




    public override void Dying()
    {


    }
}


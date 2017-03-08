using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyBombItem : AbstractEnemy
{

    public DataBomb mDataAttack;
    

  

    public void Setup(GameManager gameManager, DataBomb mDataAttack)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataBomb)dataPeople;
       
        phaze = ENEMY_PHAZE.WAIT;
    }


   

    public override void Dying()
    {


    }
}


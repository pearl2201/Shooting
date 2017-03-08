using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyMovingItem : AbstractEnemy
{

    public DataMoveEnemy mDataAttack;

    public LineMoveShoot lineMoveShoot;

    public Vector3 realCoverPoint;

    public void Setup(GameManager gameManager, DataMoveEnemy mDataAttack, LineMoveShoot lineMoveShoot)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataMoveEnemy)dataPeople;
        this.lineMoveShoot = lineMoveShoot;
        phaze = ENEMY_PHAZE.WAIT;
    }

    IEnumerator IEAction()
    {
        yield return null;
     
    }

    
    public override void Dying()
    {


    }
}


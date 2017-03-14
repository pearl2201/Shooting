using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyMovingItem : AbstractEnemy
{
    [HideInInspector]
    public DataMoveEnemy mDataAttack;
    [HideInInspector]
    public LineMoveShoot lineMoveShoot;
    [HideInInspector]
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
        List<Vector3> path = new List<Vector3>();


        float timeMove = Vector3.Distance(lineMoveShoot.endP, lineMoveShoot.startP) / mDataAttack.speedX;

        for (int i = 0; i < 7; i++)
        {
            Vector3 point = new Vector3(lineMoveShoot.startP.x * i + lineMoveShoot.endP.x * (7 - i), lineMoveShoot.startP.y * i + lineMoveShoot.endP.y * (7 - i) + UnityEngine.Random.Range(-7f, 7f), lineMoveShoot.startP.z * i + lineMoveShoot.endP.z * (7 - i));
            path.Add(point / 7);
        }

        phaze = ENEMY_PHAZE.PLAY;

        iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", timeMove, "easetype", iTween.EaseType.linear));

        yield return timeMove;
        if (phaze == ENEMY_PHAZE.PLAY)
        {
            phaze = ENEMY_PHAZE.FINISH;
            Dying();
        }
                


    }


    public override void Dying()
    {

        if (phaze == ENEMY_PHAZE.PLAY)
        {
            //add item
        }

        phaze = ENEMY_PHAZE.FINISH;
        gameManager.RemoveEnemy(this);
    }
}


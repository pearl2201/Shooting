using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyMoveShootBullet : AbstractEnemy
{
    [SerializeField]
    private ParticleSystem parShoot;
    [HideInInspector]
    public DataAttackEnemy mDataAttack;
    [HideInInspector]
    public LineMoveShoot lineMoveShoot;
    [HideInInspector]
    public Vector3 realCoverPoint;

    public void Setup(GameManager gameManager, DataAttackEnemy mDataAttack, LineMoveShoot lineMoveShoot)
    {
        Setup(gameManager, mDataAttack);
        this.mDataAttack = (DataAttackEnemy)dataPeople;
        this.lineMoveShoot = lineMoveShoot;
        realCoverPoint = lineMoveShoot.coverP;
        phaze = ENEMY_PHAZE.WAIT;
    }

    IEnumerator IEAction()
    {

        yield return StartCoroutine(MoveIn());
        yield return StartCoroutine(Attack());
        yield return StartCoroutine(MoveOut());
    }

    IEnumerator MoveIn()
    {
        // set animation
        float timeMove = Vector3.SqrMagnitude(realCoverPoint - lineMoveShoot.startP) / mDataAttack.moveSpeed;
        iTween.MoveTo(gameObject, realCoverPoint, timeMove);
        yield return timeMove;
        // set animation
    }

    IEnumerator MoveOut()
    {
        // set animation
        float timeMove = Vector3.SqrMagnitude(realCoverPoint - lineMoveShoot.endP) / mDataAttack.moveSpeed;
        iTween.MoveTo(gameObject, lineMoveShoot.endP, timeMove);
        yield return timeMove;
    }

    IEnumerator Attack()
    {
        // set animation
        bool isAttack = true;
        while (isAttack)
        {
            // attack

            // set idle

            // yield 

            isAttack = UnityEngine.Random.Range(0, 3) == 0;
        }
        yield return null;
    }

    public override void Dying()
    {
        

    }
}


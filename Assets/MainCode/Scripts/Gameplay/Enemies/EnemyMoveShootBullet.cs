using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyMoveShootBullet : AbstractEnemy
{
    [SerializeField]
    private string parShoot;
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
        StartCoroutine(IEAction());
    }

    IEnumerator IEAction()
    {
        yield return new WaitForSeconds(timeWait);
        yield return StartCoroutine(MoveIn());
        yield return StartCoroutine(Attack());
        // yield return StartCoroutine(MoveOut());
    }

    IEnumerator MoveIn()
    {
        // set animation
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimRun);
            mainAnim.clip = clip;
            mainAnim.Play();
        }


        if (lineMoveShoot.startP.x > realCoverPoint.x)
        {
            Debug.Log("set rotate right");
            transform.localEulerAngles = new Vector3(0, -90, 0);

        }
        else
        {
            Debug.Log("set rotate left");
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        float timeMove = Vector3.Magnitude(realCoverPoint - lineMoveShoot.startP) / mDataAttack.moveSpeed;
        Debug.Log("moveSpeed: " + mDataAttack.moveSpeed);
        iTween.MoveTo(gameObject, iTween.Hash("position", realCoverPoint, "time", timeMove, "easetype", iTween.EaseType.linear));
        yield return new WaitForSeconds(timeMove);
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimIdle);
            mainAnim.clip = clip;
            mainAnim.Play();

        }
        iTween.RotateTo(gameObject, iTween.Hash("y", 0, "time", 0.5f, "easetype", iTween.EaseType.linear));
        yield return new WaitForSeconds(0.5f);
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
            {
                AnimationClip clip = mainAnim.GetClip(nameAnimAttack);
                mainAnim.clip = clip;
                mainAnim.Play();
                yield return new WaitForSeconds(clip.length*0.5f);
                gameManager.AttackPlayer((int)mDataAttack.damageAttack);
                yield return new WaitForSeconds(clip.length * 0.5f);
            }

            bool isReAttack = UnityEngine.Random.Range(0, 3) == 0;
            if (isReAttack)
            {
                {
                    AnimationClip clip = mainAnim.GetClip(nameAnimIdle);
                    mainAnim.clip = clip;
                    mainAnim.Play();
                    yield return new WaitForSeconds(clip.length);
                }
            }
            else
            {
                isAttack = false;
            }

        }
        yield return null;
    }

    public override void Dying()
    {
        if (phaze != ENEMY_PHAZE.DYING)
        {
            StopAllCoroutines();
            StartCoroutine(IEDying());
        }

    }

    IEnumerator IEDying()
    {


        phaze = ENEMY_PHAZE.DYING;
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimDeath);
            mainAnim.clip = clip;
            mainAnim.Play();
            Debug.Log("length death: " + clip.length);
            yield return new WaitForSeconds(clip.length);
        }
        phaze = ENEMY_PHAZE.FINISH;
        gameManager.RemoveEnemy(this);
        

    }
}


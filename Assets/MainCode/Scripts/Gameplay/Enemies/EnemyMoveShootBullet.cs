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

    public void Setup(GameManager gameManager, DataAttackEnemy mDataAttack, LineMoveShoot _lineMoveShoot)
    {
        Setup(gameManager, mDataAttack);
        Debug.Log("setup again");
        this.mDataAttack = (DataAttackEnemy)dataPeople;
        this.lineMoveShoot = _lineMoveShoot;
        realCoverPoint = _lineMoveShoot.coverP;
        phaze = ENEMY_PHAZE.WAIT;
        StartCoroutine(IEAction());
    }

    IEnumerator IEAction()
    {
        yield return new WaitForSeconds(timeWait);
        yield return StartCoroutine(MoveIn());
        yield return StartCoroutine(Attack());
        yield return StartCoroutine(MoveOut());
    }

    IEnumerator MoveIn()
    {
        phaze = ENEMY_PHAZE.RUN;
        // set animation
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimRun);
            mainAnim.clip = clip;
            mainAnim.Play();
        }

        SoundManager.Instance.Play("enemyRoar1");
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
        transform.position = lineMoveShoot.startP;
        float timeMove = Vector3.Magnitude(realCoverPoint - lineMoveShoot.startP) / mDataAttack.moveSpeed;
        Debug.Log("moveSpeed: " + mDataAttack.moveSpeed);
        iTween.MoveTo(gameObject, iTween.Hash("position", realCoverPoint, "time", timeMove, "easetype", iTween.EaseType.linear));
        yield return new WaitForSeconds(timeMove);
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimIdle);
            mainAnim.clip = clip;
            clip.wrapMode = WrapMode.Loop;
            mainAnim.Play();

        }
        iTween.RotateTo(gameObject, iTween.Hash("y", 0, "time", 0.5f, "easetype", iTween.EaseType.linear));
        yield return new WaitForSeconds(0.5f);
        // set animation
    }

    IEnumerator MoveOut()
    {
        phaze = ENEMY_PHAZE.RUN;
        SoundManager.Instance.Play("enemyRoar1");
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimRun);
            mainAnim.clip = clip;
            mainAnim.Play();
        }


        if (lineMoveShoot.endP.x < realCoverPoint.x)
        {
            Debug.Log("set rotate right");
            transform.localEulerAngles = new Vector3(0, -90, 0);

        }
        else
        {
            Debug.Log("set rotate left");
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        // set animation
        float timeMove = Mathf.Abs(Vector3.Magnitude(realCoverPoint - lineMoveShoot.endP)) / mDataAttack.moveSpeed;
        iTween.MoveTo(gameObject, iTween.Hash("position", lineMoveShoot.endP, "time", timeMove, "easetype", iTween.EaseType.linear));
        yield return new WaitForSeconds(timeMove);
        phaze = ENEMY_PHAZE.FINISH;
        gameManager.RemoveEnemy(this);
    }

    IEnumerator Attack()
    {
        // set animation
        phaze = ENEMY_PHAZE.PLAY;
        bool isAttack = true;
        while (isAttack)
        {
            // attack

            // set idle

            // yield 
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2f));

            {
                SoundManager.Instance.Play("enemyAttack1");
                SoundManager.Instance.Play("secondaryShot");
                AnimationClip clip = mainAnim.GetClip(nameAnimAttack);
                mainAnim.clip = clip;
                mainAnim.Play();
                yield return new WaitForSeconds(clip.length * 0.5f);
                gameManager.AttackPlayer((int)mDataAttack.damageAttack);
                yield return new WaitForSeconds(clip.length * 0.5f);
            }

            bool isReAttack = UnityEngine.Random.Range(0, 10) != 0;
            if (isReAttack)
            {
                {
                    AnimationClip clip = mainAnim.GetClip(nameAnimIdle);
                    clip.wrapMode = WrapMode.Loop;
                    mainAnim.clip = clip;
                    mainAnim.Play();
                    yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 2f));
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
            SoundManager.Instance.Play("enemyDeath1");
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


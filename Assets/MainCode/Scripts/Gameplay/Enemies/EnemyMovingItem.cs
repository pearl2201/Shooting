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
        transform.position = lineMoveShoot.startP;
        phaze = ENEMY_PHAZE.WAIT;
        StartCoroutine(IEAction());
    }

    IEnumerator IEAction()
    {
        List<Vector3> path = new List<Vector3>();

        if (lineMoveShoot.endP.x < lineMoveShoot.startP.x)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else if (lineMoveShoot.endP.x > lineMoveShoot.startP.x)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        float timeMove = Vector3.Distance(lineMoveShoot.endP, lineMoveShoot.startP) / mDataAttack.speedX;

        for (int i = 0; i < 7; i++)
        {
            Vector3 point = new Vector3(lineMoveShoot.startP.x * (7 - i) + lineMoveShoot.endP.x * i, lineMoveShoot.startP.y * (7 - i) + lineMoveShoot.endP.y * i + UnityEngine.Random.Range(-7f, 7f), lineMoveShoot.startP.z * (7 - i) + lineMoveShoot.endP.z * i);
            Debug.Log(point.ToString());
            path.Add(point / 7);
        }

        phaze = ENEMY_PHAZE.PLAY;

        iTween.MoveTo(gameObject, iTween.Hash("path", path.ToArray(), "time", timeMove, "easetype", iTween.EaseType.linear));

        yield return new WaitForSeconds(timeMove);
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
            bool isAddItem = UnityEngine.Random.Range(0, 2) == 0;
            if (true)
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    gameManager.CreateGoldItemAt(transform.position);
                }
                else
                {
                    gameManager.CreateHpItemAt(transform.position);
                }
            }
        }

        phaze = ENEMY_PHAZE.FINISH;
        StopAllCoroutines();
        {
            iTween itScript = GetComponent<iTween>();
            if (itScript != null)
            {
                Destroy(itScript);
            }
        }
        gameManager.RemoveEnemy(this);

    }


    public override void GetHit(int damage, Vector3 hitPoint, bool isGrenade)
    {
        Debug.Log("Enemy: " + gameObject.name + " take damge: " + hitPoint);
        dataPeople.hp -= damage;
        isFullHp = false;
        if (dataPeople.hp <= 0)
        {
            SoundManager.Instance.Play("enemyPain1");
            ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("Explosion")).GetComponent<ParticleSystem>();
            ps.transform.position = hitPoint;
            ps.Play();


            AutoPool.AttackPool(ps.gameObject, ps.duration);

            Dying();
        }
        else
        {
            SoundManager.Instance.Play("enemyPain1");
            ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("SmallExplo")).GetComponent<ParticleSystem>();
            ps.transform.position = hitPoint;
            ps.transform.SetParent(transform);
            ps.Play();
            AutoPool.AttackPool(ps.gameObject, ps.duration);

        }
    }


}


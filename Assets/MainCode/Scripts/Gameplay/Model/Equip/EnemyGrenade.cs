using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour, IPoolObj
{
    private int damage;
       
    private bool isExplo;
    private GameManager gameManager;
    public void Setup(GameManager gameManager, Vector3 pos, Vector3 posDest, int damage)
    {
        this.gameManager = gameManager;
        this.damage = damage;
        transform.position = pos;
        isExplo = false;

        float timeMoving = Vector3.Distance(posDest, pos) / 20;
        iTween.MoveTo(gameObject, iTween.Hash("position", posDest, "time", timeMoving, "easetype", iTween.EaseType.easeInOutCirc, "oncompletetarget", gameObject, "oncomplete", "Explo"));
    }



    private void Explo()
    {
        isExplo = true;
        SoundManager.Instance.Play("explo");
        List<AbstractEnemy> listAbstractEnemyExplo = new List<AbstractEnemy>();
        for (int i = 0; i < gameManager.listFullObj.Count; i++)
        {
            if (Vector3.Distance(transform.position, gameManager.listFullObj[i].transform.position) < 10)
            {
                gameManager.listFullObj[i].GetHit(damage, true);
            }
        }
        {
            GameObject explo = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("Explosion"));
            explo.transform.position = transform.position;
            AutoPool.AttackPool(explo, 3);
        }
        PoolManager.ReleaseObject(gameObject);
    }

    public void Reset()
    {
        isExplo = false;
    }
}


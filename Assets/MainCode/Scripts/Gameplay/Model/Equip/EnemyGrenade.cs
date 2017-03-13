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
    public void Setup(GameManager gameManager, Vector3 pos, Vector3 posDest, int damage, float timeShoot)
    {
        this.gameManager = gameManager;
        this.damage = damage;
        transform.position = pos;
        isExplo = false;
        posDest.x = 0;
        Vector3 middle = (pos + posDest) * 0.5f;
        middle.y += Vector3.Distance(posDest, pos) / Mathf.Sqrt(3);
        float timeMoving = Vector3.Distance(posDest, pos) / 8;
        iTween.MoveTo(gameObject, iTween.Hash("path", new Vector3[] { pos,middle, posDest }, "time", timeShoot, "easetype", iTween.EaseType.linear, "oncompletetarget", gameObject, "oncomplete", "Explo"));
    }



    private void Explo()
    {
        isExplo = true;
        SoundManager.Instance.Play("explo");

        gameManager.AttackPlayer((int)damage);
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


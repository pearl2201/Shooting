using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerGrenade : MonoBehaviour, IPoolObj
{
    public DataGrenade dataGrenade;
    public Rigidbody mRigid;

    private bool isExplo;
    private GameManager gameManager;
    private float valueExplo;
    public void Setup(GameManager gameManager, Vector3 velocity, Vector3 pos)
    {
        this.gameManager = gameManager;
        mRigid.velocity = velocity;
        transform.position = pos;
        isExplo = false;
        valueExplo = velocity.magnitude / 10;
    }

    void Update()
    {
        if (!isExplo && Vector3.Magnitude(mRigid.velocity) < valueExplo)
        {
            Explo();
        }
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
                gameManager.listFullObj[i].GetHit(dataGrenade.damage,true);
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


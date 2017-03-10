using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public abstract class AbstractEnemy : MonoBehaviour, IPoolObj
{
    [HideInInspector]
    public EnemyBase dataPeople;

    public Animation mainAnim;
    [SerializeField]
    protected EnemyComponents[] arrEnemyComponents;
    [SerializeField]
    protected string nameAnimRun;
    [SerializeField]
    protected string nameAnimAttack;
    [SerializeField]
    protected string nameAnimTakeDown;
    [SerializeField]
    protected string nameAnimDeath;
    [SerializeField]
    protected string nameAnimIdle;
    protected GameManager gameManager;

    protected float timeWait;
    [HideInInspector]
    public ENEMY_PHAZE phaze;
    [SerializeField]
    protected string parTakeDamage;
    [SerializeField]
    protected string parDeath;

    void Start()
    {

    }

    protected virtual void Setup(GameManager gameManager, EnemyBase data)
    {
        this.gameManager = gameManager;
        this.dataPeople = data.Clone();
        timeWait = UnityEngine.Random.Range(0, 2f);
    }

    public void GetHit(EnemyComponents component, int damage, Vector3 hitPoint)
    {

        if (component.typeComponent == TYPE_COMPONENT_ENEMY.HEADER)
        {
            dataPeople.hp -= damage * 2;
            Debug.Log("get hit: head: " + dataPeople.hp);
        }
        else if (component.typeComponent == TYPE_COMPONENT_ENEMY.BODY)
        {
            dataPeople.hp -= damage;
            Debug.Log("get hit: body: " + dataPeople.hp);
            {

            }
        }


        if (dataPeople.hp <= 0)
        {
            ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("BigBlood")).GetComponent<ParticleSystem>();
            ps.transform.position = hitPoint;
            ps.Play();
            AutoPool.AttackPool(ps.gameObject, ps.duration);
            Dying();
        }
        else
        {
            ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("SmallBlood")).GetComponent<ParticleSystem>();
            ps.transform.position = hitPoint;
            ps.Play();
            AutoPool.AttackPool(ps.gameObject, ps.duration);
        }
    }

    public abstract void Dying();

    public virtual void Reset()
    {

    }
}


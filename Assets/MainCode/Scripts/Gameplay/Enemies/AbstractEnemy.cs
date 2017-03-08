using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public abstract class AbstractEnemy : MonoBehaviour, IPoolObj
{
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

    protected GameManager gameManager;

    protected float timeWait;
    public ENEMY_PHAZE phaze;
    [SerializeField]
    protected ParticleSystem parTakeDamage;
    [SerializeField]
    protected ParticleSystem parDeath;
    
    void Start()
    {

    }

    protected virtual void Setup(GameManager gameManager, EnemyBase data)
    {
        this.gameManager = gameManager;
        this.dataPeople = data.Clone();
        timeWait = UnityEngine.Random.Range(0, 2f);
    }

    public void GetHit(EnemyComponents component, int damage)
    {
        if (component.typeComponent == TYPE_COMPONENT_ENEMY.HEADER)
        {
            dataPeople.hp -= damage * 2;
        }
        else if (component.typeComponent == TYPE_COMPONENT_ENEMY.BODY)
        {
            dataPeople.hp -= damage;
        }

        if (dataPeople.hp <= 0)
        {
            Dying();
        }
    }

    public abstract void Dying();

    public virtual void Reset()
    {

    }
}


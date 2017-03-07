using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public abstract class AbstractEnemy : MonoBehaviour, IPoolObj
{
    public EnemyBase dataPeople;

    public Animation mainAnim;

    public EnemyComponents[] arrEnemyComponents;

    public string nameAnimRunLeft;
    public string nameAnimRunRight;
    public string nameAnimTakeDown;

    private GameManager gameManager;

    public ENEMY_PHAZE phaze;

    void Start()
    {

    }

    public virtual void Setup(GameManager gameManager, EnemyBase data)
    {
        this.gameManager = gameManager;
        this.dataPeople = data.Clone();
    }

    public void GetHit(EnemyComponents component, int damage)
    {
        if (component.typeComponent == TYPE_COMPONENT_ENEMY.HEADER)
        {

        }
        else if (component.typeComponent == TYPE_COMPONENT_ENEMY.BODY)
        {

        }
    }

    public virtual void Reset()
    {

    }
}


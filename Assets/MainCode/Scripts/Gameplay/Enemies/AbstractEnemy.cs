using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public class AbstractEnemy : MonoBehaviour
{
    public EnemyBase dataPeople;

    public Animation mainAnim;

    public EnemyComponents[] arrEnemyComponents;

    public string nameAnimRunLeft;
    public string nameAnimRunRight;
    public string nameAnimShooting;
    public string nameAnimTakeDown;


    void Start()
    {

    }

    public void RegisGameManager()
    {

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

    public void Shooting()
    {

    }

}


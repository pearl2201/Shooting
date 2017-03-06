using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyComponents : MonoBehaviour
{
    public AbstractEnemy abstractEnemy;

    public TYPE_COMPONENT_ENEMY typeComponent;

    public void GetHit(int damage)
    {
        abstractEnemy.GetHit(this, damage);
    }

}


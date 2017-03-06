using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class EnemyBase
{
    public int idEnemy;
    public TYPE_ENEMY typeEnemy;
    public int hp;

    public EnemyBase()
    {
        /*
        this.idEnemy = 0;
        this.typeEnemy = TYPE_ENEMY.STATIC_DEF;
        this.hp = 0;
        */
    }

}

[Serializable]
public class DataMoveEnemy : EnemyBase
{
    public float speedX;
    public int idLineMove;

    public DataMoveEnemy() : base()
    {
        /*
        this.speedX = 0;
        this.idLineMove = 0;
        */
    }
}
[Serializable]
public class DataStaticEnemy : EnemyBase
{
    public Vector3 pos;
    public DataStaticEnemy() : base()
    {
        this.pos = Vector3.zero;
    }
}
[Serializable]
public class DataBomb : DataStaticEnemy
{
    public float damageExplosion;
    public float radiusExplosion;

    public DataBomb() : base()
    {
        this.damageExplosion = 0;
        this.radiusExplosion = 0;
    }
}
[Serializable]
public class DataHpObj : DataStaticEnemy
{
    public float hpAddition;

    public DataHpObj() : base()
    {
        this.hpAddition = 0;
    }
}
[Serializable]
public class DataCoinObj : DataStaticEnemy
{
    public float moneyAddition;


    public DataCoinObj() : base()
    {
        this.moneyAddition = 0;
    }
}
[Serializable]
public class DataDefObj : DataStaticEnemy
{
    public DataDefObj() : base()
    {

    }
}
[Serializable]
public class DataMoveFixedShoot : EnemyBase
{
    public float speedAttack;
    public float damageAttack;
    public int idLineMoveShoot;

    public DataMoveFixedShoot() : base()
    {
        this.speedAttack = 0;
        this.damageAttack = 0;
        this.idLineMoveShoot = 0;

    }
}
[Serializable]
public class DataMoveRandShoot : EnemyBase
{
    public float speedAttack;
    public float damageAttack;
    public int minSpawn;
    public int maxSpawn;


    public DataMoveRandShoot() : base()
    {
        this.speedAttack = 0;
        this.damageAttack = 0;
        this.minSpawn = 1;
        this.maxSpawn = 1;

    }
}

[Serializable]
public class DataFakeInfoTurnSpawn
{


    public FullEnemyBase[] listEnemyBase;


}

[Serializable]
public class DataInfoTurnSpawn
{


    public EnemyBase[] listEnemyBase;


}

[Serializable]
public class FullEnemyBase
{
    public int idEnemy;
    public TYPE_ENEMY typeEnemy;
    public int hp;
    public float speedX;
    public int idLineMove;
    public Vector3 pos;
    public float speedAttack;
    public float damageAttack;
    public int minSpawn;
    public int maxSpawn;
    public int idLineMoveShoot;
    public float moneyAddition;
    public float hpAddition;
    public float damageExplosion;
    public float radiusExplosion;
}

[Serializable]
public class LineMoveShoot
{
    public Vector3 startP;
    public Vector3 endP;
    public Vector3 coverP;
    public float radius;

    public LineMoveShoot()
    {
        startP = Vector3.zero;
        endP = Vector3.zero;
        coverP = Vector3.zero;
        radius = 0;
    }
}
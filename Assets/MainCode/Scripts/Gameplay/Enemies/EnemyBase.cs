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

    public EnemyBase(int idEnemy, TYPE_ENEMY typeEnemy, int hp)
    {
        this.idEnemy = idEnemy;
        this.typeEnemy = typeEnemy;
        this.hp = hp;
    }

    public virtual EnemyBase Clone()
    {
        return new EnemyBase(idEnemy, typeEnemy, hp);
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

    public DataMoveEnemy(int idEnemy, TYPE_ENEMY typeEnemy, int hp, float speedX, int idLineMove) : base(idEnemy, typeEnemy, hp)
    {
        this.speedX = speedX;
        this.idLineMove = idLineMove;
    }

    public override EnemyBase Clone()
    {
        return new DataMoveEnemy(idEnemy, typeEnemy, hp, speedX, idLineMove);
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

    public DataStaticEnemy(int idEnemy, TYPE_ENEMY typeEnemy, int hp, Vector3 pos) : base(idEnemy, typeEnemy, hp)
    {

        this.pos = pos;
    }

    public override EnemyBase Clone()
    {
        return new DataStaticEnemy(idEnemy, typeEnemy, hp, pos);
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

    public DataBomb(int idEnemy, TYPE_ENEMY typeEnemy, int hp, Vector3 pos, float damageExplosion, float radiusExplosion) : base(idEnemy, typeEnemy, hp, pos)
    {

        this.damageExplosion = damageExplosion;
        this.radiusExplosion = radiusExplosion;
    }

    public override EnemyBase Clone()
    {
        return new DataBomb(idEnemy, typeEnemy, hp, pos, damageExplosion, radiusExplosion);
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

    public DataHpObj(int idEnemy, TYPE_ENEMY typeEnemy, int hp, Vector3 pos, float hpAddition) : base(idEnemy, typeEnemy, hp, pos)
    {

        this.hpAddition = hpAddition;
    }

    public override EnemyBase Clone()
    {
        return new DataHpObj(idEnemy, typeEnemy, hp, pos, hpAddition);
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

    public DataCoinObj(int idEnemy, TYPE_ENEMY typeEnemy, int hp, Vector3 pos, float moneyAddition) : base(idEnemy, typeEnemy, hp, pos)
    {

        this.moneyAddition = moneyAddition;
    }

    public override EnemyBase Clone()
    {
        return new DataCoinObj(idEnemy, typeEnemy, hp, pos, moneyAddition);
    }
}
[Serializable]
public class DataDefObj : DataStaticEnemy
{
    public DataDefObj() : base()
    {

    }

    public DataDefObj(int idEnemy, TYPE_ENEMY typeEnemy, int hp, Vector3 pos) : base(idEnemy, typeEnemy, hp, pos)
    {


    }

    public override EnemyBase Clone()
    {
        return new DataDefObj(idEnemy, typeEnemy, hp, pos);
    }
}

[Serializable]
public class DataAttackEnemy : EnemyBase
{
    public float moveSpeed;
    public float speedAttack;
    public float damageAttack;
    public TYPE_ENEMY_ATTACK typeEnemyAtk;
    public DataAttackEnemy() : base()
    {
        this.speedAttack = 0;
        this.damageAttack = 0;
        this.moveSpeed = 0;
        typeEnemyAtk = TYPE_ENEMY_ATTACK.SHOOT;

    }

    public DataAttackEnemy(int idEnemy, TYPE_ENEMY typeEnemy, int hp, float moveSpeed, float speedAttack, float damageAttack, TYPE_ENEMY_ATTACK typeAtk) : base(idEnemy, typeEnemy, hp)
    {
        this.moveSpeed = moveSpeed;
        this.speedAttack = speedAttack;
        this.damageAttack = damageAttack;

        this.typeEnemyAtk = typeAtk;
    }

    public override EnemyBase Clone()
    {
        return new DataAttackEnemy(idEnemy, typeEnemy, hp, moveSpeed, speedAttack, damageAttack, typeEnemyAtk);
    }
}

[Serializable]
public class DataMoveFixedShoot : DataAttackEnemy
{

    public int idLineMoveShoot;
    public DataMoveFixedShoot() : base()
    {

        this.idLineMoveShoot = 0;

    }

    public DataMoveFixedShoot(int idEnemy, TYPE_ENEMY typeEnemy, int hp, float moveSpeed, float speedAttack, float damageAttack, int idLineMoveShoot, TYPE_ENEMY_ATTACK typeAtk) : base(idEnemy, typeEnemy, hp, moveSpeed, speedAttack, damageAttack, typeAtk)
    {


        this.idLineMoveShoot = idLineMoveShoot;

    }

    public override EnemyBase Clone()
    {
        return new DataMoveFixedShoot(idEnemy, typeEnemy, hp, moveSpeed, speedAttack, damageAttack, idLineMoveShoot, typeEnemyAtk);
    }
}
[Serializable]
public class DataMoveRandShoot : DataAttackEnemy
{

    public int noSpawn;


    public DataMoveRandShoot() : base()
    {

        this.noSpawn = 1;

    }
    public DataMoveRandShoot(int idEnemy, TYPE_ENEMY typeEnemy, int hp, float moveSpeed, float speedAttack, float damageAttack, int noSpawn, TYPE_ENEMY_ATTACK typeAtk) : base(idEnemy, typeEnemy, hp, moveSpeed, speedAttack, damageAttack, typeAtk)
    {


        this.noSpawn = noSpawn;
    }

    public override EnemyBase Clone()
    {
        return new DataMoveRandShoot(idEnemy, typeEnemy, hp, moveSpeed, speedAttack, damageAttack, noSpawn, typeEnemyAtk);
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
    public float moveSpeed;
    public int idLineMove;
    public Vector3 pos;
    public float speedAttack;
    public float damageAttack;
    public int noSpawn;
    public int idLineMoveShoot;
    public float moneyAddition;
    public float hpAddition;
    public float damageExplosion;
    public float radiusExplosion;
    public TYPE_ENEMY_ATTACK typeAtk;
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
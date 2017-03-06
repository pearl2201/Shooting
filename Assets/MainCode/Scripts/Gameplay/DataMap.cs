using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class DataMap : MonoBehaviour
{
    public int idMap;

    public LineMoveShoot[] listLineMoveShooting;
    public DataFakeInfoTurnSpawn[] listFakeTurnSpawn;


    private DataInfoTurnSpawn[] listTurnSpawn;

    public DataInfoTurnSpawn[] GetDataSpawn()
    {
        if (listTurnSpawn != null)
        {
            return listTurnSpawn;
        }
        else
        {
            listTurnSpawn = new DataInfoTurnSpawn[listFakeTurnSpawn.Length];
            for (int i = 0; i < listTurnSpawn.Length; i++)
            {
                DataInfoTurnSpawn dataTurn = new DataInfoTurnSpawn();
                dataTurn.listEnemyBase = new EnemyBase[listFakeTurnSpawn[i].listEnemyBase.Length];
                for (int j = 0; j < dataTurn.listEnemyBase.Length; j++)
                {
                    FullEnemyBase fE = listFakeTurnSpawn[i].listEnemyBase[j];
                    if (fE.typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
                    {
                        DataMoveFixedShoot enemy = new DataMoveFixedShoot(fE.idEnemy, fE.typeEnemy, fE.hp, fE.speedAttack, fE.damageAttack, fE.idLineMoveShoot);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
                    {
                        DataMoveRandShoot enemy = new DataMoveRandShoot(fE.idEnemy, fE.typeEnemy, fE.hp, fE.speedAttack, fE.damageAttack, fE.minSpawn, fE.maxSpawn);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.MOVING)
                    {
                        DataMoveEnemy enemy = new DataMoveEnemy(fE.idEnemy, fE.typeEnemy, fE.hp, fE.speedX, fE.idLineMove);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_BOMB)
                    {
                        DataBomb enemy = new DataBomb(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.damageExplosion, fE.radiusExplosion);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_DEF)
                    {
                        DataDefObj enemy = new DataDefObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_GOLD)
                    {
                        DataCoinObj enemy = new DataCoinObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.moneyAddition);
                        dataTurn.listEnemyBase[i] = enemy;
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_HP)
                    {
                        DataCoinObj enemy = new DataCoinObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.hpAddition);
                        dataTurn.listEnemyBase[i] = enemy;
                    }

                }
                listTurnSpawn[i] = dataTurn;

            }
            return listTurnSpawn;
        }
    }


    void OnEnable()
    {

    }

}


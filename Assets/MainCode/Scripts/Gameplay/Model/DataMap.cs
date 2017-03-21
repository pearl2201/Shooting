using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class DataMap : MonoBehaviour
{
    public int idMap;
    public string titleMap;
    public MissionMini[] arrMission;
    public string hint;

    public LineMoveShoot lineFlying;
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
                
                List<EnemyBase> listEB = new List<EnemyBase>();
                for (int j = 0; j < listFakeTurnSpawn[i].listEnemyBase.Length; j++)
                {
                    FullEnemyBase fE = listFakeTurnSpawn[i].listEnemyBase[j];
                    if (fE.typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
                    {
                        DataMoveFixedShoot enemy = new DataMoveFixedShoot(fE.idEnemy, fE.typeEnemy, fE.hp, fE.moveSpeed,fE.speedAttack, fE.damageAttack, fE.idLineMoveShoot, fE.typeAtk);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
                    {
                        DataMoveRandShoot enemy = new DataMoveRandShoot(fE.idEnemy, fE.typeEnemy, fE.hp, fE.moveSpeed, fE.speedAttack, fE.damageAttack, fE.noSpawn, fE.typeAtk);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.MOVING)
                    {
                        DataMoveEnemy enemy = new DataMoveEnemy(fE.idEnemy, fE.typeEnemy, fE.hp, fE.moveSpeed);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_BOMB)
                    {
                        DataBomb enemy = new DataBomb(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.damageExplosion, fE.radiusExplosion);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_DEF)
                    {
                        DataDefObj enemy = new DataDefObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_GOLD)
                    {
                        DataCoinObj enemy = new DataCoinObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.moneyAddition);
                        listEB.Add(enemy);
                    }
                    else if (fE.typeEnemy == TYPE_ENEMY.STATIC_HP)
                    {
                        DataCoinObj enemy = new DataCoinObj(fE.idEnemy, fE.typeEnemy, fE.hp, fE.pos, fE.hpAddition);
                        listEB.Add(enemy);
                    }

                }
                dataTurn.listEnemyBase = listEB.ToArray();
                listTurnSpawn[i] = dataTurn;

            }
            return listTurnSpawn;
        }
    }


    void OnEnable()
    {

    }

}


[Serializable]
public class MissionMini
{
    public TYPE_MAP_MISSION typeMission;
    public int valueMission;
}
using UnityEngine;
using UnityEditor;
using NUnit.Framework;


[CustomEditor(typeof(DataMap))]
public class MapEditor : Editor
{
    private int noLine = 0;
    private int noTurn = 0;
    private SerializedObject dataSO;
    private DataMap dataMap;
    private int[] arrCountEnemyInTurn;
    void OnEnable()
    {

        dataSO = serializedObject;

        dataMap = (DataMap)target;
        if (dataMap == null)
        {
            Debug.Log("null, ngu xuan ???....");
        }
        noLine = dataMap.listLineMoveShooting.Length;
        noTurn = dataMap.listFakeTurnSpawn.Length;
        arrCountEnemyInTurn = new int[noTurn];
        for (int i = 0; i < noTurn; i++)
        {
            arrCountEnemyInTurn[i] = dataMap.listFakeTurnSpawn[i].listEnemyBase.Length;
        }
        Debug.Log("on enbla");

    }

    public override void OnInspectorGUI()
    {

        dataSO.Update();

        dataMap.idMap = EditorGUILayout.IntField("ID Map", dataMap.idMap);

        EditorGUILayout.Separator();

        noLine = EditorGUILayout.IntField("No Line", noLine);
        if (noLine > 0)
        {

            if (dataMap.listLineMoveShooting == null)
            {
                dataMap.listLineMoveShooting = new LineMoveShoot[noLine];
                for (int i = 0; i < Mathf.Min(noLine, dataMap.listLineMoveShooting.Length); i++)
                {
                    dataMap.listLineMoveShooting[i] = new LineMoveShoot();
                }

            }
            else if (noLine != dataMap.listLineMoveShooting.Length)
            {
                LineMoveShoot[] tmpData = new LineMoveShoot[noLine];
                for (int i = 0; i < noLine; i++)
                {
                    if (i < dataMap.listLineMoveShooting.Length)
                    {
                        tmpData[i] = dataMap.listLineMoveShooting[i];
                    }
                    else
                    {
                        tmpData[i] = new LineMoveShoot();
                    }

                }
                dataMap.listLineMoveShooting = tmpData;
            }

            for (int i = 0; i < dataMap.listLineMoveShooting.Length; i++)
            {
                if (dataMap.listLineMoveShooting[i] == null)
                {
                    dataMap.listLineMoveShooting[i] = new LineMoveShoot();

                }
                else
                {

                }

                EditorGUI.indentLevel = 1;

                EditorGUILayout.LabelField("Line " + i);

                EditorGUI.indentLevel = 2;

                dataMap.listLineMoveShooting[i].startP = EditorGUILayout.Vector3Field("Start Point", dataMap.listLineMoveShooting[i].startP);
                dataMap.listLineMoveShooting[i].endP = EditorGUILayout.Vector3Field("Start Point", dataMap.listLineMoveShooting[i].endP);
                dataMap.listLineMoveShooting[i].coverP = EditorGUILayout.Vector3Field("Start Point", dataMap.listLineMoveShooting[i].coverP);
                dataMap.listLineMoveShooting[i].radius = EditorGUILayout.FloatField("Radius", dataMap.listLineMoveShooting[i].radius);
            }


        }
        EditorGUILayout.Separator();
        EditorGUI.indentLevel = 0;
        noTurn = EditorGUILayout.IntField("No Turn Spawn", noTurn);
        if (noTurn > 0)
        {
            if (dataMap.listFakeTurnSpawn == null)
            {
                dataMap.listFakeTurnSpawn = new DataFakeInfoTurnSpawn[noTurn];
                arrCountEnemyInTurn = new int[noTurn];
                for (int i = 0; i < Mathf.Min(noLine, dataMap.listFakeTurnSpawn.Length); i++)
                {
                    dataMap.listFakeTurnSpawn[i] = new DataFakeInfoTurnSpawn();
                    arrCountEnemyInTurn[i] = 0;
                }

            }
            else if (noTurn != dataMap.listFakeTurnSpawn.Length)
            {

                DataFakeInfoTurnSpawn[] tmpDataTurn = new DataFakeInfoTurnSpawn[noTurn];
                arrCountEnemyInTurn = new int[noTurn];
                for (int i = 0; i < noTurn; i++)
                {
                    if (i < dataMap.listFakeTurnSpawn.Length)
                    {
                        tmpDataTurn[i] = dataMap.listFakeTurnSpawn[i];
                        arrCountEnemyInTurn[i] = tmpDataTurn[i].listEnemyBase.Length;
                    }
                    else
                    {
                        tmpDataTurn[i] = new DataFakeInfoTurnSpawn();
                        arrCountEnemyInTurn[i] = 0;
                    }

                }

                dataMap.listFakeTurnSpawn = tmpDataTurn;


            }

            for (int i = 0; i < dataMap.listFakeTurnSpawn.Length; i++)
            {
                EditorGUILayout.Separator();
                EditorGUI.indentLevel = 1;
                EditorGUILayout.LabelField("Turn " + i);

                arrCountEnemyInTurn[i] = EditorGUILayout.IntField("No Enemy Spawn", arrCountEnemyInTurn[i]);

                if (dataMap.listFakeTurnSpawn[i].listEnemyBase == null)
                {
                    dataMap.listFakeTurnSpawn[i].listEnemyBase = new FullEnemyBase[arrCountEnemyInTurn[i]];
                    for (int j = 0; j < dataMap.listFakeTurnSpawn[i].listEnemyBase.Length; j++)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j] = new FullEnemyBase();
                    }

                }
                else if (arrCountEnemyInTurn[i] != dataMap.listFakeTurnSpawn[i].listEnemyBase.Length)
                {
                    Debug.Log("re cast");
                    FullEnemyBase[] tmpDataTurn = new FullEnemyBase[arrCountEnemyInTurn[i]];
                    for (int j = 0; j < arrCountEnemyInTurn[i]; j++)
                    {
                        if (j< dataMap.listFakeTurnSpawn[i].listEnemyBase.Length)
                        {
                            tmpDataTurn[i] = dataMap.listFakeTurnSpawn[i].listEnemyBase[j];
                        }
                        else
                        {
                            tmpDataTurn[i] = new FullEnemyBase();
                        }
                        
                    }

                    dataMap.listFakeTurnSpawn[i].listEnemyBase = tmpDataTurn;
                    arrCountEnemyInTurn[i] = Mathf.Min(dataMap.listFakeTurnSpawn[i].listEnemyBase.Length, arrCountEnemyInTurn[i]);
                }

                for (int j = 0; j < dataMap.listFakeTurnSpawn[i].listEnemyBase.Length; j++)
                {
                    EditorGUI.indentLevel = 2;
                    EditorGUILayout.LabelField("Enemy " + j);
                    EditorGUI.indentLevel = 3;
                    dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idEnemy = EditorGUILayout.IntField("ID Prefab", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idEnemy);
                    dataMap.listFakeTurnSpawn[i].listEnemyBase[j].hp = EditorGUILayout.IntField("Hp", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].hp);
                    dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy = (TYPE_ENEMY)EditorGUILayout.EnumPopup("Type Enemy", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy);
                    if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVING)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed = EditorGUILayout.FloatField("Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMove = EditorGUILayout.IntField("Line Move", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMove);

                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_BOMB)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos = EditorGUILayout.Vector3Field("Pos", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageExplosion = EditorGUILayout.FloatField("Damage", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageExplosion);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].radiusExplosion = EditorGUILayout.FloatField("Radius Explo", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].radiusExplosion);

                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_GOLD)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos = EditorGUILayout.Vector3Field("Pos", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moneyAddition = EditorGUILayout.FloatField("Money ", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moneyAddition);


                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_DEF)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos = EditorGUILayout.Vector3Field("Pos", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos);


                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_HP)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos = EditorGUILayout.Vector3Field("Pos", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].pos);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].hpAddition = EditorGUILayout.FloatField("Hp ", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].hpAddition);

                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeAtk = (TYPE_ENEMY_ATTACK)EditorGUILayout.EnumPopup("Type Enemy Atk", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeAtk);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed = EditorGUILayout.FloatField("Move Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].speedAttack = EditorGUILayout.FloatField("Atk Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].speedAttack);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageAttack = EditorGUILayout.FloatField("Damage", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageAttack);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].noSpawn = EditorGUILayout.IntField("Spawn", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].noSpawn);

                    }
                    else if (dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
                    {
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeAtk = (TYPE_ENEMY_ATTACK)EditorGUILayout.EnumPopup("Type Enemy Atk", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].typeAtk);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed = EditorGUILayout.FloatField("Move Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].moveSpeed);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].speedAttack = EditorGUILayout.FloatField("Atk Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].speedAttack);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageAttack = EditorGUILayout.FloatField("Damage", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].damageAttack);
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMoveShoot = EditorGUILayout.IntField("Speed", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMoveShoot);

                    }
                }
            }


        }


        dataSO.ApplyModifiedProperties();
    }
}
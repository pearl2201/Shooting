using UnityEngine;
using UnityEditor;
using NUnit.Framework;


[CustomEditor(typeof(DataMap))]
public class MapEditor : Editor
{
    private int noLine = 0;
    private int noTurn = 0;
    private SerializedObject dataSO;
    private int noMission = 0;
    private DataMap dataMap;
    private int[] arrCountEnemyInTurn;
    private bool foldMission;
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
        noMission = dataMap.arrMission.Length;
    }

    public override void OnInspectorGUI()
    {

        dataSO.Update();

        dataMap.idMap = EditorGUILayout.IntField("ID Map", dataMap.idMap);
        dataMap.titleMap = EditorGUILayout.TextField("Title Map", dataMap.titleMap);
        dataMap.hint = EditorGUILayout.TextField("Hint", dataMap.hint);
        
        EditorGUILayout.Separator();

        noMission = EditorGUILayout.IntField("No Mission", noMission);
        if (noMission > 0)
        {

            if (dataMap.arrMission == null)
            {
                dataMap.arrMission = new MissionMini[noMission];
                for (int i = 0; i < Mathf.Min(noMission, dataMap.arrMission.Length); i++)
                {
                    dataMap.arrMission[i] = new MissionMini();
                }

            }
            else if (noMission != dataMap.arrMission.Length)
            {
                MissionMini[] tmpData = new MissionMini[noMission];
                for (int i = 0; i < noMission; i++)
                {
                    if (i < dataMap.arrMission.Length)
                    {
                        tmpData[i] = dataMap.arrMission[i];
                    }
                    else
                    {
                        tmpData[i] = new MissionMini();
                    }

                }
                dataMap.arrMission = tmpData;
            }

            for (int i = 0; i < dataMap.arrMission.Length; i++)
            {
                if (dataMap.arrMission[i] == null)
                {
                    dataMap.arrMission[i] = new MissionMini();

                }
                else
                {

                }

                EditorGUI.indentLevel = 1;

                EditorGUILayout.LabelField("Line " + i);

                EditorGUI.indentLevel = 2;

                dataMap.arrMission[i].typeMission = (TYPE_MAP_MISSION) EditorGUILayout.EnumPopup("TYPE_MISSION", dataMap.arrMission[i].typeMission);
                dataMap.arrMission[i].valueMission = EditorGUILayout.IntField("Value", dataMap.arrMission[i].valueMission);
                
            }


        }

        EditorGUILayout.Separator();
        if (dataMap.lineFlying == null)
        {
            dataMap.lineFlying = new LineMoveShoot();
        }
        {
            EditorGUILayout.LabelField("Line Flying");

            EditorGUI.indentLevel = 1;

            dataMap.lineFlying.startP = EditorGUILayout.Vector3Field("Start Point", dataMap.lineFlying.startP);
            dataMap.lineFlying.endP = EditorGUILayout.Vector3Field("End Point", dataMap.lineFlying.endP);
            dataMap.lineFlying.coverP = EditorGUILayout.Vector3Field("Cover Point", dataMap.lineFlying.coverP);
            dataMap.lineFlying.radius = EditorGUILayout.FloatField("Radius", dataMap.lineFlying.radius);
        }
        EditorGUILayout.Separator();
        EditorGUI.indentLevel = 0;
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
                dataMap.listLineMoveShooting[i].endP = EditorGUILayout.Vector3Field("End Point", dataMap.listLineMoveShooting[i].endP);
                dataMap.listLineMoveShooting[i].coverP = EditorGUILayout.Vector3Field("Cover Point", dataMap.listLineMoveShooting[i].coverP);
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
                        if (j < dataMap.listFakeTurnSpawn[i].listEnemyBase.Length)
                        {
                            tmpDataTurn[j] = dataMap.listFakeTurnSpawn[i].listEnemyBase[j];
                        }
                        else
                        {
                            tmpDataTurn[j] = new FullEnemyBase();
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
                        dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMoveShoot = EditorGUILayout.IntField("Id Line", dataMap.listFakeTurnSpawn[i].listEnemyBase[j].idLineMoveShoot);

                    }
                }
            }


        }


        dataSO.ApplyModifiedProperties();
    }
}
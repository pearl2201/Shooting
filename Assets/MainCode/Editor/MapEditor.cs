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

    void OnEnable()
    {

        dataSO = serializedObject;

        dataMap = (DataMap)target;
        if (dataMap == null)
        {
            Debug.Log("null, ngu xuan ???");
        }
        noLine = dataMap.listLineMoveShooting.Length;
        noTurn = dataMap.listTurnSpawn.Length;

    }

    public override void OnInspectorGUI()
    {

        dataSO.Update();

        dataMap.idMap = EditorGUILayout.IntField("ID Map", dataMap.idMap);

        EditorGUILayout.Separator();

        noLine = EditorGUILayout.IntField("No Line", noLine);
        if (noLine > 0)
        {
            /*
            if (dataMap.listLineMoveShooting == null)
            {
                dataMap.listLineMoveShooting = new LineMoveShoot[noLine];
                for (int i = 0; i < Mathf.Min(noLine, dataMap.listLineMoveShooting.Length); i++)
                {
                    dataMap.listLineMoveShooting[i] = new LineMoveShoot();
                }
                
            }
            else
            */
            if (noLine != dataMap.listLineMoveShooting.Length)
            {
                LineMoveShoot[] tmpData = new LineMoveShoot[noLine];
                for (int i = 0; i < Mathf.Min(noLine, dataMap.listLineMoveShooting.Length); i++)
                {
                    tmpData[i] = dataMap.listLineMoveShooting[i];
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
            if (noTurn != dataMap.listTurnSpawn.Length)
            {
                Debug.Log("create 1");
                DataInfoTurnSpawn[] tmpDataTurn = new DataInfoTurnSpawn[noTurn];
                for (int i = 0; i < Mathf.Min(dataMap.listTurnSpawn.Length, noTurn); i++)
                {
                    tmpDataTurn[i] = dataMap.listTurnSpawn[i];
                }

                dataMap.listTurnSpawn = tmpDataTurn;

            }

            for (int i = 0; i < dataMap.listTurnSpawn.Length; i++)
            {
                EditorGUILayout.Separator();
                EditorGUI.indentLevel = 1;
                EditorGUILayout.LabelField("Turn " + i);

                int noSpawn = EditorGUILayout.IntField("No Enemy Spawn", dataMap.listTurnSpawn[i].listEnemyBase.Length);
                if (noSpawn != dataMap.listTurnSpawn[i].listEnemyBase.Length)
                {
                    Debug.Log("re cast");
                    FullEnemyBase[] tmpDataTurn = new FullEnemyBase[noSpawn];
                    for (int j = 0; j < Mathf.Min(dataMap.listTurnSpawn[i].listEnemyBase.Length, noSpawn); j++)
                    {

                        tmpDataTurn[i] = dataMap.listTurnSpawn[i].listEnemyBase[j];
                    }

                    dataMap.listTurnSpawn[i].listEnemyBase = tmpDataTurn;
                }

                for (int j = 0; j < dataMap.listTurnSpawn[i].listEnemyBase.Length; j++)
                {
                    EditorGUI.indentLevel = 2;
                    EditorGUILayout.LabelField("Enemy " + j);
                    EditorGUI.indentLevel = 3;
                    dataMap.listTurnSpawn[i].listEnemyBase[j].idEnemy = EditorGUILayout.IntField("ID Prefab", dataMap.listTurnSpawn[i].listEnemyBase[j].idEnemy);
                    dataMap.listTurnSpawn[i].listEnemyBase[j].hp = EditorGUILayout.IntField("Hp", dataMap.listTurnSpawn[i].listEnemyBase[j].hp);
                    dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy = (TYPE_ENEMY)EditorGUILayout.EnumPopup("Type Enemy", dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy);

                    if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVING)
                    {
                        dataMap.listTurnSpawn[i].listEnemyBase[j].speedX = EditorGUILayout.FloatField("Speed", dataMap.listTurnSpawn[i].listEnemyBase[j].speedX);
                        dataMap.listTurnSpawn[i].listEnemyBase[j].idLineMove = EditorGUILayout.IntField("Line Move", dataMap.listTurnSpawn[i].listEnemyBase[j].idLineMove);

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_BOMB)
                    {

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_GOLD)
                    {

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_DEF)
                    {

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.STATIC_HP)
                    {

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_RAND_LINE)
                    {

                    }
                    else if (dataMap.listTurnSpawn[i].listEnemyBase[j].typeEnemy == TYPE_ENEMY.MOVE_SHOOT_FIXED_LINE)
                    {

                    }
                }
            }


        }


        dataSO.ApplyModifiedProperties();
    }
}
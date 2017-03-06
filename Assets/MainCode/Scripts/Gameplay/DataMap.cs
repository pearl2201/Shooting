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

    /*
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

                listTurnSpawn[i] = dataTurn;

            }
            return listTurnSpawn;
        }
    }
    */

    void OnEnable()
    {

    }

}


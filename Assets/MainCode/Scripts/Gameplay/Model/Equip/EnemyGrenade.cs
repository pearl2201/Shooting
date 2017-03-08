using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour, IPoolObj
{
    public DataGrenade dataGrenade;
    public Rigidbody rigidbody;

    private bool isExplo;
    private GameManager gameManager;

    public void Setup(GameManager gameManager, Vector3 velocity)
    {
        this.gameManager = gameManager;
    }

    void Update()
    {
        if (!isExplo && Vector3.Magnitude(rigidbody.velocity) < 1f)
        {
            Explo();
        }
    }

    private void Explo()
    {
        isExplo = true;
    }

    public void Reset()
    {
        isExplo = false;
    }
}


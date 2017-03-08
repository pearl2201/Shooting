using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AbstractGun : MonoBehaviour
{
    public GameObject tieucu;
    [HideInInspector]
    public int noBullet;
    [HideInInspector]
    public int noBulletActive;
    public DataGun dataGun;

    public void SetPosByPosTieuCu(Vector3 posTieuCu)
    {
        Vector3 currDistance = transform.position - tieucu.transform.position;
        transform.position = posTieuCu + currDistance;

    }
}


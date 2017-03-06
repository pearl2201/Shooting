using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public abstract class AbstractStrategyAimGun : MonoBehaviour
{

    private bool isUpdateGun;
    [SerializeField]
    protected Player player;
    [SerializeField]
    protected tk2dCamera mCam;
    [SerializeField]
    protected Camera pCam;
    [SerializeField]
    protected GameObject cube;
    [SerializeField]
    protected GameObject tieucu;
    void Update()
    {
        if (isUpdateGun)
        {
            UpdatePosition();
        }
        
    }

    public abstract void UpdatePosition();

    public virtual void TouchDown()
    {
        Debug.Log("touch don");
        isUpdateGun = true;
    }

    public void TouchUp()
    {
        Debug.Log("touch up");
        isUpdateGun = false;
    }

}


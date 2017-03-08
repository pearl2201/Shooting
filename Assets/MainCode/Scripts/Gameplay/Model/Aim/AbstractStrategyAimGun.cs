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
    public Camera pCam;
  
    [SerializeField]
    protected GameManager gameManager;
    void Update()
    {
        if (isUpdateGun && gameManager.currGameState == GAME_STATE.PLAY)
        {
            UpdatePosition();
        }

    }

    public abstract void UpdatePosition();

    public virtual void TouchDown()
    {
        Debug.Log("touch don");
        if (gameManager.currGameState == GAME_STATE.PLAY)
            isUpdateGun = true;
    }

    public void TouchUp()
    {
        Debug.Log("touch up");
        isUpdateGun = false;
    }

}


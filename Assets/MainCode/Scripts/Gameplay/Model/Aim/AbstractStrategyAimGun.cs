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
    private bool isUpdatePos = false;
    private Vector3 posTouch;
    protected Vector3 oldPosition;
    void Update()
    {
        isUpdateGun = false;

        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch t = Input.GetTouch(i);

                    RaycastHit hit;
                    posTouch = mCam.ScreenCamera.ScreenToWorldPoint(t.position);
                    posTouch.z = 100;

                    if (Physics.Raycast(posTouch, new Vector3(0, 0, 1), out hit))
                    {
                        if (hit.collider.tag == "Aim")
                        {
                            //Debug.Log("posTouch: " + posTouch);
                            if (t.phase == TouchPhase.Began)
                            {
                                oldPosition = posTouch;
                               // Debug.Log("ne oldPos");
                            }
                            else if (t.phase == TouchPhase.Moved)
                            {
                                isUpdateGun = true;
                              //  Debug.Log("update");
                            }
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                posTouch = mCam.ScreenCamera.ScreenToWorldPoint(Input.mousePosition);
                posTouch.z = 100;

                if (Physics.Raycast(posTouch, new Vector3(0, 0, 1), out hit))
                {
                    if (hit.collider.tag == "Aim")
                    {
                        //Debug.Log("posTouch: " + posTouch);
                        if (Input.GetMouseButtonDown(0))
                        {

                            oldPosition = posTouch;
                            //Debug.Log("ne oldPos");
                        }
                        else if (Input.GetMouseButton(0))
                        {
                            isUpdateGun = true;
                          //  Debug.Log("update");
                        }


                    }
                }
            }
        }

        if (isUpdateGun && (gameManager.currGameState == GAME_STATE.PLAY || gameManager.currGameState == GAME_STATE.TRANSFER || gameManager.currGameState == GAME_STATE.SETUP))
        {

            UpdatePosition(posTouch);
        }

    }

    public abstract void UpdatePosition(Vector3 posTouch);

    public virtual void TouchDown()
    {
        /*
        Debug.Log("touch don");
        if (gameManager.currGameState == GAME_STATE.PLAY || gameManager.currGameState == GAME_STATE.TRANSFER || gameManager.currGameState == GAME_STATE.SETUP)
            isUpdateGun = true;
            */
    }

    public void TouchUp()
    {
        /*
        Debug.Log("touch up");
        isUpdateGun = false;
        */
    }

}


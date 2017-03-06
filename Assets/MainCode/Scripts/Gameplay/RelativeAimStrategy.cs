﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RelativeAimStrategy : AbstractStrategyAimGun
{

    private Vector3 oldPosition;
    private Vector3 currPosition;
    private Vector3 posGun;

    public override void UpdatePosition()
    {
        if (Application.isMobilePlatform)
        {
            currPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            currPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (currPosition.x != oldPosition.x || currPosition.y != oldPosition.y)
        {
            float deltaX = (-oldPosition.x + currPosition.x) * Constants.DEFAULT_RELATIVE_AIM;
            float deltaY = (-oldPosition.y + currPosition.y) * Constants.DEFAULT_RELATIVE_AIM;

            posGun = player.gun.transform.position;
            posGun.x += deltaX;
            posGun.y += deltaY;
            posGun.x = Mathf.Clamp(posGun.x, -Constants.MARGIN_GUN_X, Constants.MARGIN_GUN_X);
            posGun.y = Mathf.Clamp(posGun.y, -Constants.MARGIN_GUN_Y, Constants.MARGIN_GUN_Y);
            player.gun.transform.position = posGun;
            oldPosition = currPosition;
        }

        RaycastHit hit;

        if (Physics.Raycast(tieucu.transform.position, (tieucu.transform.position - pCam.transform.position) * 10, out hit))

        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("hit enemy");
                hit.collider.tag = "Finish";
            }
        }


        Debug.DrawRay(tieucu.transform.position, (tieucu.transform.position - pCam.transform.position) * 10, Color.green);


    }

    public override void TouchDown()
    {
        base.TouchDown();
        if (Application.isMobilePlatform)
        {
            oldPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            oldPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}

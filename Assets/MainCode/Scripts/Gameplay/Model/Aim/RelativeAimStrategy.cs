using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RelativeAimStrategy : AbstractStrategyAimGun
{

   
    private Vector3 currPosition;
    private Vector3 posGun;

    public override void UpdatePosition(Vector3 posTouch)
    {
        currPosition = posTouch;

        if (currPosition.x != oldPosition.x || currPosition.y != oldPosition.y)
        {
            float deltaX = (-oldPosition.x + currPosition.x) * Constants.DEFAULT_RELATIVE_AIM;
            float deltaY = (-oldPosition.y + currPosition.y) * Constants.DEFAULT_RELATIVE_AIM;

            posGun = player.currGun.transform.position;
            posGun.x -= deltaX;
            posGun.y += deltaY;
            posGun.x = Mathf.Clamp(posGun.x, -Constants.MARGIN_GUN_TOP_X, Constants.MARGIN_GUN_TOP_X);
            posGun.y = Mathf.Clamp(posGun.y, Constants.MARGIN_GUN_BOT_Y, Constants.MARGIN_GUN_TOP_Y);
            player.currGun.transform.position = posGun;
            oldPosition = currPosition;
        }



        // Debug.DrawRay(player.currGun.tieucu.transform.position, (player.currGun.tieucu.transform.position - pCam.transform.position) * 10, Color.green);


    }

    public override void TouchDown()
    {
        /*
        base.TouchDown();
        if (Application.isMobilePlatform)
        {
            oldPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            oldPosition = mCam.ScreenCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        */
    }
}

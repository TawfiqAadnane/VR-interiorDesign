using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Gazeableobject
{
    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        if (Player.instance.activeMode == InputMode.TELEPORT)
        {
            Vector3 destlocation = hitInfo.point;

            destlocation.y = Player.instance.transform.position.y;

            Player.instance.transform.position = destlocation;
        }
    }
}

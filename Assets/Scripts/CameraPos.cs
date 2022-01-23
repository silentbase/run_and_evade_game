using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{

    public Transform target;

    public Vector3 offsetPosition;

    private Space offsetPositionSpace = Space.Self;

    private bool lookAt = true;

    private void LateUpdate()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (target == null)
        {
            

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;

        }
    }
}


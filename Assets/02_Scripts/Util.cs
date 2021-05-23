using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Vector3 GetDirection(Vector2 _input, Camera _cam) {
        var forward = _cam.transform.forward;
        var right = _cam.transform.right;
 
        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
 
        //this is the direction in the world space we want to move:
        return forward * _input.y + right * _input.x;
    }
}

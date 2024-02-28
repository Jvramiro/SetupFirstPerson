using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class VectorUtils
{
    public static Vector3 IgnoreVertical(this Vector3 vector) => new Vector3(vector.x,0,vector.z);
    public static float DistanceXZ(Vector3 positionA, Vector3 positionB){
        positionA.y = 0;
        positionB.y = 0;
        return Vector3.Distance(positionA, positionB);
    }
}

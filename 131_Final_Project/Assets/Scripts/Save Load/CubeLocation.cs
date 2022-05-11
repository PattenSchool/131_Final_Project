using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used from video https://www.youtube.com/watch?v=XOjd_qU2Ido
[System.Serializable]
public class CubeLocation
{
    public float[] Cube;

    public CubeLocation(Vector3 cubeLocation)
    {
        Cube = new float[3];
        Cube[0] = cubeLocation.x;
        Cube[1] = cubeLocation.y;
        Cube[2] = cubeLocation.z;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used from video https://www.youtube.com/watch?v=XOjd_qU2Ido
[System.Serializable]
public class CubeColorData
{
    public float[] CubeColor;

    public CubeColorData(Color cubeColor)
    {
        CubeColor = new float[4];
        CubeColor[0] = cubeColor.r;
        CubeColor[1] = cubeColor.g;
        CubeColor[2] = cubeColor.b;
        CubeColor[3] = cubeColor.a;
    }
}

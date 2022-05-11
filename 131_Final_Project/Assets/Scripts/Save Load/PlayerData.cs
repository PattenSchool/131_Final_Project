using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used from video https://www.youtube.com/watch?v=XOjd_qU2Ido
[System.Serializable]
public class PlayerData
{
    public float[] PlayerLocation;

    public PlayerData (Vector3 playerLocation)
    {
        PlayerLocation = new float[3];
        PlayerLocation[0] = playerLocation.x;
        PlayerLocation[1] = playerLocation.y;
        PlayerLocation[2] = playerLocation.z;
    }
}

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Used from video https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveData
{
    public static void SavePlayer(Vector3 playerLocation)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerLocation);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveCubeLocation(Vector3 cubeLocation)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cube.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        CubeLocation data = new CubeLocation(cubeLocation);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CubeLocation LoadCubeLocation()
    {
        string path = Application.persistentDataPath + "/cube.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CubeLocation data = formatter.Deserialize(stream) as CubeLocation;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveCubeColor(Color cubeColor)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cubeColor.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        CubeColorData data = new CubeColorData(cubeColor);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CubeColorData LoadCubeColor()
    {
        string path = Application.persistentDataPath + "/cubeColor.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CubeColorData data = formatter.Deserialize(stream) as CubeColorData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

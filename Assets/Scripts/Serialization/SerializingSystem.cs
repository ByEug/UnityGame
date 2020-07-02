using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SerializingSystem
{
    public static void SavePlayer(GameObject player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/PlayerSettings.bin";
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerDataToSave buffer = new PlayerDataToSave(player);

        PlayerController.observers.Clear();

        formatter.Serialize(file, buffer);
        file.Close();

    }

    public static PlayerDataToSave LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerSettings.bin";
        BinaryFormatter formatter = new BinaryFormatter();
        PlayerDataToSave buffer;
        try
        {
            FileStream file = new FileStream(path, FileMode.Open);
            buffer = formatter.Deserialize(file) as PlayerDataToSave;
            file.Close();
        }
        catch
        {
            buffer = null;
        }
        return buffer;
    }
}

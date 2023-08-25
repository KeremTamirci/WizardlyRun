using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SystemSaver : MonoBehaviour
{
    public static void SaveManager(Manager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/manager.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataManager data = new DataManager(manager);

        formatter.Serialize(stream, data);
        stream.Close();

        
    }

    public static DataManager LoadManager()
    {
        string path = Application.persistentDataPath + "/manager.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataManager data = formatter.Deserialize(stream) as DataManager;
            stream.Close();
            return data;
        }

        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }

    }
}

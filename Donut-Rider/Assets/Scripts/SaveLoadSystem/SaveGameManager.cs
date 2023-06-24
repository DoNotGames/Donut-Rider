using System.IO;
using UnityEngine;

public static class SaveGameManager 
{
    public static LevelsData levelsData = new LevelsData();
    public const string directory = "/SaveData/";
    public const string fileName = "SaveGame.sav";
    
    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(levelsData, true);
        File.WriteAllText(dir + fileName, json);

        GUIUtility.systemCopyBuffer = dir;
        return true;
    }

    public static void LoadGame()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;

        LevelsData tempData = new LevelsData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<LevelsData>(json);
        }
        else
        {
            Debug.LogError("Save file does not exist!");
        }

        levelsData = tempData;
    }
}

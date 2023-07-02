using System.IO;
using UnityEngine;

public static class SaveGameManager 
{
    public const string directory = "/SaveData/";

    public static LevelData levelData = new LevelData();
    public static bool SaveGame(string levelName, bool isUnlocked, float time, int health)
    {
        var dir = Application.persistentDataPath + directory + levelName + ".sav";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        levelData.levelName = levelName;
        levelData.isUnlocked = isUnlocked;
        levelData.time = time;
        levelData.health = health;

        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(dir + levelName + ".sav", json);

        GUIUtility.systemCopyBuffer = dir;
        return true;
    }

    public static void LoadGame(string levelName)
    {
        string fullPath = Application.persistentDataPath + directory + levelName + ".sav";

        LevelData tempData = new LevelData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<LevelData>(json);
        }
        else
        {
            Debug.LogError("Save file does not exist!");
        }

        levelData = tempData;
    }
}

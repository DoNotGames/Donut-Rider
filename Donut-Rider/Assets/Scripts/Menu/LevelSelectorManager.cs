using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{
    public List<LevelData> LevelList = new List<LevelData>();
    public Sprite LevelCompleteSprite;
    public Sprite LevelUnCompleteSprite;

    public GameObject LevelPrefab;
    public GameObject LevelContent;

    private void Start()
    {
        GenerateAllPrefs();
        for (int i = 0; i < LevelList.Count; i++)
        {
            var LevelInst = Instantiate(LevelPrefab, LevelContent.transform);
            var LevelIndex = i;
            LevelInst.transform.Find("LevelPreview").GetComponent<Image>().sprite = LevelList[i].LevelPreview;
            LevelInst.transform.Find("LevelName").GetComponent<TextMeshProUGUI>().text = LevelList[i].LevelName;
            LevelInst.transform.Find("DebugLevelID").GetComponent<TextMeshProUGUI>().text = LevelList[i].LevelID;
            LevelInst.transform.Find("LevelHighScore").GetComponent<TextMeshProUGUI>().text = CheckLevelHighScore(i).ToString();
            LevelInst.transform.Find("LevelComplete").GetComponent<Image>().sprite = CheckLevelCompleteSprite(i);
            LevelInst.transform.Find("LevelButton").GetComponent<Button>().onClick.AddListener(() => LoadLevel(LevelIndex));
            Debug.Log("CREATE");
        }
    }
    private int CheckLevelHighScore(int LevelID)
    {
        return PlayerPrefs.GetInt("HighScore" + LevelID);
    }
    private Sprite CheckLevelCompleteSprite(int LevelID)
    {
        if(PlayerPrefs.GetInt("NextLevelUnlockIndex") >= LevelID) //CAN
        {
            return LevelCompleteSprite;
        }
        else
        {
            return LevelUnCompleteSprite;
        }
    }
    public void LoadLevel(int LevelID)
    {
        Debug.Log("Try load " + LevelID);
        if (PlayerPrefs.GetInt("NextLevelUnlockIndex") >= LevelID) //LOAD LEVEL
        {
            SceneManager.LoadScene(LevelList[LevelID].SceneID);
        }
        else //CANT LOAD LEVEL
        {
            Debug.Log("MUST PLAY LAST LEVEL!");
        }
    }
    private void GenerateAllPrefs()
    {
        if (!PlayerPrefs.HasKey("NextLevelUnlockIndex"))
        {
            PlayerPrefs.SetInt("NextLevelUnlockIndex", 0);
            Debug.LogWarning("Create NextLevelUnlockIndex"); 
        }
        for (int i = 0; i < LevelList.Count; i++)
        {
            if (!PlayerPrefs.HasKey("HighScore" + i))
            {
                PlayerPrefs.SetInt("HighScore" + i, 0);
                Debug.LogWarning("HighScore" + i);
            }
        }
    }
}
[System.Serializable]
public class LevelData 
{
    public string LevelName;
    public string LevelID;
    public int SceneID;
    public Sprite LevelPreview;
    private int HighScore;
    private bool LevelComplete;
}


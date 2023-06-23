using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectorManager : MonoBehaviour
{
    [SerializeField] SceneLoadMenager sceneLoadMenager;
    [SerializeField] private GameObject levelWindowContent;
    [SerializeField] private GameObject levelCardPrefab;
    [SerializeField] private Sprite levelCompleteSprite;

    private void Start()
    {
        GenerateLevelsCards();
    }

    private void GenerateLevelsCards()
    {
        foreach(string level in sceneLoadMenager.levels)
        {
            GameObject levelInst = Instantiate(levelCardPrefab, levelWindowContent.transform);
            levelInst.transform.Find("Name").GetComponent<TMP_Text>().text = level;
            levelInst.transform.Find("StartButton").GetComponent<Button>().onClick.AddListener(delegate { sceneLoadMenager.LoadLevel(level); });
        }
    }
    private int CheckLevelHighScore(int LevelID)
    {
        return PlayerPrefs.GetInt("HighScore" + LevelID);
    }
    private Sprite CheckLevelCompleteSprite(int LevelID)
    {
        return null;
    }
}


using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelName", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public string LevelName;
    public GameObject Scene;
}

using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    private InputController inputController;
    private bool isGamePaused;
    private float startTimeScale;
    private DonutMenager donutMenager;
    private MetaPrefab metaPrefab;
    private float levelTime;

    private void Awake()
    {
        inputController = GetComponent<InputController>();

        isGamePaused = false;
        startTimeScale = Time.timeScale;
    }

    private void Start()
    {
        donutMenager = GameObject.FindGameObjectWithTag("Player").GetComponent<DonutMenager>();
        donutMenager.donutHealth.PlayerDeath += delegate { EndPanel(); };

        metaPrefab = GameObject.Find("META").GetComponent<MetaPrefab>();
        metaPrefab.EndGameByMetaEvent += delegate { EndPanel(); };

        levelTime = 0f;
    }

    private void Update()
    {
        levelTime += Time.deltaTime;
    }

    public void SwitchPause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            inputController.DisableInput("PlayerControlInput");
            Time.timeScale = 0;
            pauseMenu.ShowMenu();
            return;
        }

        Time.timeScale = startTimeScale;
        inputController.EnableInput("PlayerControlInput");
        pauseMenu.HideMenu();
    }

    public void EndPanel()
    {
        Time.timeScale = 0;
        inputController.DisableInput("PlayerControlInput");
        inputController.DisableInput("InGameGeneralInput");
        pauseMenu.ShowMenu(true, levelTime, donutMenager.donutHealth.currentHP);
    }

    private void OnDisable()
    {
        Time.timeScale = startTimeScale;
    }
}

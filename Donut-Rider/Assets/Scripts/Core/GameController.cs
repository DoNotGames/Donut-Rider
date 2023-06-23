using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    private InputController inputController;
    private bool isGamePaused;
    private float startTimeScale;

    private void Awake()
    {
        inputController = GetComponent<InputController>();

        isGamePaused = false;
        startTimeScale = Time.timeScale;
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

    private void OnDisable()
    {
        Time.timeScale = startTimeScale;
    }
}

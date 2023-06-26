using System;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Action Quit;
    public Action Reset;

    [SerializeField] private TMP_Text windowText;

    [SerializeField] private GameObject confirmWindow;
    [SerializeField] private TMP_Text confirmWindowText;

    private GameObject pauseMenuContainer;
    private string currentSelectedMenuOption;
    private SceneLoadMenager sceneLoadMenager;

    private void Awake()
    {
        pauseMenuContainer = transform.GetChild(0).gameObject;

        if (pauseMenuContainer.activeSelf)
            pauseMenuContainer.SetActive(false);
    }

    private void Start()
    {
        sceneLoadMenager = GameObject.Find("SceneLoadMenager").GetComponent<SceneLoadMenager>();
    }

    public void ShowMenu(bool endPanel = false, float time = 0f, int lifes = 0)
    {
        pauseMenuContainer.SetActive(true);
        if (endPanel)
        {
            windowText.text = $"Time: {time}  Lifes: {lifes}";
            return;
        }

        windowText.text = "Paused";
    }

    public void HideMenu()
    {
        pauseMenuContainer.SetActive(false);
        confirmWindow.SetActive(false);
        windowText.gameObject.SetActive(true);
    }

    public void Selection(string menuOption)
    {
        currentSelectedMenuOption = menuOption;
        confirmWindow.SetActive(true);
        windowText.gameObject.SetActive(false);

        if(currentSelectedMenuOption == "Quit")
        {
            confirmWindowText.text = "Quit To Main Menu?";
            return;
        }

        confirmWindowText.text = "Reset Level?";
    }

    public void ConfirmSelection()
    {
        confirmWindow.SetActive(false);
        pauseMenuContainer.SetActive(false);
        windowText.gameObject.SetActive(true);

        if (currentSelectedMenuOption == "Quit")
        {
            sceneLoadMenager.GoBackToMainMenu();
            Quit?.Invoke();
            return;
        }

        sceneLoadMenager.ResetScene();
        Reset?.Invoke();
    }

    public void CancelSelection()
    {
        confirmWindow.SetActive(false);
        windowText.gameObject.SetActive(true);
    }
}

using System;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Action Quit;
    public Action Reset;

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

#if UNITY_EDITOR
    [ContextMenu("Show")]
#endif
    public void ShowMenu()
    {
        pauseMenuContainer.SetActive(true);
    }

#if UNITY_EDITOR
    [ContextMenu("Hide")]
#endif
    public void HideMenu()
    {
        pauseMenuContainer.SetActive(false);
    }

    public void Selection(string menuOption)
    {
        currentSelectedMenuOption = menuOption;
        confirmWindow.SetActive(true);

        if(currentSelectedMenuOption == "Quit")
        {
            confirmWindowText.text = "Quit To Main Menu?";
            return;
        }

        confirmWindowText.text = "Reset Level?";
    }

    public void ConfirmSelection()
    {
        if(currentSelectedMenuOption == "Quit")
        {
            confirmWindow.SetActive(false);
            pauseMenuContainer.SetActive(false);
            sceneLoadMenager.GoBackToMainMenu();
            Quit?.Invoke();
#if UNITY_EDITOR
            Debug.Log("Quit Level");
#endif
            return;
        }

        confirmWindow.SetActive(false);
        pauseMenuContainer.SetActive(false);
        sceneLoadMenager.ResetScene();
        Reset?.Invoke();
#if UNITY_EDITOR
        Debug.Log("Reset Level");
#endif
    }

    public void CancelSelection()
    {
        confirmWindow.SetActive(false);
    }
}

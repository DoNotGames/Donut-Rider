using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    private GameObject currentMenu;

    private void Awake()
    {
        currentMenu = startMenu;

    }

    public void SwitchMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        newMenu.SetActive(true);
        SoundsController.Play_Sound("menu_click");

        currentMenu = newMenu;
    }

    public void Exit()
    {
        Debug.Log("GameClosed");
    }
}

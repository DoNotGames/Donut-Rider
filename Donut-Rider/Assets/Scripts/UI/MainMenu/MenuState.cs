using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : MonoBehaviour
{
    //[SerializeField] private List<GameObject> menuStatesGameObjects;

    //private Dictionary<string, GameObject> menuStatesGameObjectsNames;
    [SerializeField] private GameObject startMenu;
    private GameObject currentMenu;

    private void Awake()
    {
        //menuStatesGameObjectsNames = new Dictionary<string, GameObject>();
        currentMenu = startMenu;

        //menuStatesGameObjects.ForEach(sgo => menuStatesGameObjectsNames.Add(sgo.name, sgo));
    }

    public void SwitchMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        newMenu.SetActive(true);

        currentMenu = newMenu;
        //menuStatesGameObjectsNames[currentMenu].SetActive(false);
        //menuStatesGameObjectsNames[newMenuName].SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("GameClosed");
    }
}

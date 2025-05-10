using System;
using UnityEngine;

public class _MainMenuManager : MonoBehaviour
{
    static _MainMenuManager instance;
    
    public GameObject mainMenuPrefab;
    public GameObject mainMenu;
    public Transform panelParent;


    private void Awake()
    {
        _MainMenuManager.instance = this;
        this.mainMenu = Instantiate(mainMenuPrefab, panelParent);
        this.mainMenu.SetActive(false);
    }

    public virtual void ShowUI()
    {
        this.mainMenu.SetActive(true);
    }

    public virtual void HideUI()
    {
        this.mainMenu.SetActive(false);
    }
}

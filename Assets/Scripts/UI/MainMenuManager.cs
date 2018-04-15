using System.Collections;
using UnityEngine;
using Rewired;

public class MainMenuManager : MonoBehaviour
{
    private Player playerInput;

    [Header("Main Menu Manager Attributes")]
    public GameObject startUI;

    [Space(10)]
    public GameObject gameSelectUI;

    [Space(10)]
    public int navigatorFirstLevel;
    public int controllerFirstLevel;

    [Space(10)]
    public bool isDisplayingPlayerSelect = false;

    private void Start()
    {
        InputSetup();
    }

    private void Update()
    {
        ManageInput();
    }

    private void InputSetup()
    {
        playerInput = ReInput.players.GetPlayer(0);
    }

    private void ManageInput()
    {
        if (playerInput.GetButtonDown("Start"))
        {
            if (!isDisplayingPlayerSelect)
            {
                DisableStartUI();

                isDisplayingPlayerSelect = true;
            }
        }

        if (playerInput.GetButtonDown("Option1"))
        {
            if (isDisplayingPlayerSelect)
            {
                LoadLevel("Controller");
            }
        }

        if (playerInput.GetButtonDown("Option2"))
        {
            if (isDisplayingPlayerSelect)
            {
                LoadLevel("Navigator");
            }
        }
    }

    public void DisableStartUI()
    {
        startUI.SetActive(false);

        gameSelectUI.SetActive(true);
    }

    public void LoadLevel(string playerType)
    {
        if (playerType == "Controller")
        {
            LevelManager.Instance.LoadLevel(controllerFirstLevel);
        }
        else if (playerType == "Navigator")
        {
            LevelManager.Instance.LoadLevel(navigatorFirstLevel);
        }
    }
}

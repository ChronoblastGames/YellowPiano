using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameUI : MonoBehaviour
{
    private PlayerHealthController2D playerHealthController;

    [Header("Timer UI Attributes")]
    public Text timerText;

    private float currentTime;

    [Header("Lives UI Attributes")]
    public Text livesText;

    private void Start()
    {
        GameUISetup();
    }

    private void Update()
    {
        ManagePlayerUI();
    }

    private void GameUISetup()
    {
        playerHealthController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController2D>();
    }

    private void ManagePlayerUI()
    {
        ManageLiveText();
        //ManagePlayerUI();
    }

    private void ManageLiveText()
    {
        string livesString = "Player Lives : " + playerHealthController.playerCurrentLives.ToString();
        livesText.text = livesString;
    }

    private void ManageUITImer()
    {
        currentTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = niceTime;
    }
}

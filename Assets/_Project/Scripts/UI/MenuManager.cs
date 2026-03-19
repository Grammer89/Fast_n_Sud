using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject shopPanel;
    public GameObject settingsPanel;
    public GameObject leaderboardPanel;

    void Start()
    {
        OpenMain();
    }

    // START GAME
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // DA CAMBIARE DOPO CON IL NOME DELLA SCENA GIUSTA!!!!
    }

    // EXIT
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void OpenMain()
    {
        mainPanel.SetActive(true);
        shopPanel.SetActive(false);
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    // SHOP
    public void OpenShop()
    {
        mainPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // SETTINGS
    public void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // LEADERBOARD
    public void OpenLeaderboard()
    {
        mainPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    public void CloseLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
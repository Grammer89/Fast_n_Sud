using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    #region Singleton Declaration
    private static SaveSystem _instance;
    private static bool _isApplicationQuitting = false;

    public static SaveSystem Instance
    {
        get
        {
            if (_isApplicationQuitting) return null;

            CreateOrGetInstance();
            return _instance;
        }
    }

    private static void CreateOrGetInstance()
    {
        if (_instance == null)
        {
            _instance = FindAnyObjectByType<SaveSystem>(FindObjectsInactive.Include);
            if (_instance == null)
            {
                SaveSystem prefab = Resources.Load<SaveSystem>("Singletons/SaveSystem");
                _instance = Instantiate(prefab);
            }
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void SaveGame()
    {
        try
        {
            SaveData save = new SaveData();
            save.TotalCoins = GameState.Instance.TotalCoins;
            save.TopFiveScores = GameState.Instance.TopFiveScores;
            save.CanDoubleJump = GameState.Instance.CanDoubleJump;
            save.HealthUpgrades = GameState.Instance.HealthUpgrades;
            save.CanUseBerserk = GameState.Instance.CanUseBerserk;
            save.BerserkUpgrades = GameState.Instance.BerserkUpgrades;
            save.CanUseMagnet = GameState.Instance.CanUseMagnet;
            save.MagnetUpgrades = GameState.Instance.MagnetUpgrades;

            string savePath = Application.persistentDataPath + "/SaveFile.json";
            string jsonText = JsonConvert.SerializeObject(save);

            File.WriteAllText(savePath, jsonText);

            Debug.Log("File Saved!");
        }
        catch (Exception e)
        {
            Debug.LogError($"Non e' stato possibile salvare il gioco! " + e);
        }
    }

    public void LoadGame()
    {
        try
        {
            string savePath = Application.persistentDataPath + "/SaveFile.json";
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                var data = JsonConvert.DeserializeObject<SaveData>(json);

                GameState.Instance.TotalCoins = data.TotalCoins;
                GameState.Instance.TopFiveScores = data.TopFiveScores;
                GameState.Instance.CanDoubleJump = data.CanDoubleJump;
                GameState.Instance.HealthUpgrades = data.HealthUpgrades;
                GameState.Instance.CanUseBerserk = data.CanUseBerserk;
                GameState.Instance.BerserkUpgrades = data.BerserkUpgrades;
                GameState.Instance.CanUseMagnet = data.CanUseMagnet;
                GameState.Instance.MagnetUpgrades = data.MagnetUpgrades;

                Debug.Log("File loaded");
            }
            else
            {
                Debug.LogWarning($"Nessun file trovato alla directory {savePath}!");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Non e' stato possibile caricre il gioco! " + e);
        }
    }

    public void ResetProgressi()
    {
        GameState.Instance.TotalCoins = 0;
        GameState.Instance.TopFiveScores = new int[5];
        GameState.Instance.CanDoubleJump = false;
        GameState.Instance.HealthUpgrades = 0;
        GameState.Instance.CanUseBerserk = false;
        GameState.Instance.BerserkUpgrades = 0;
        GameState.Instance.CanUseMagnet = false;
        GameState.Instance.MagnetUpgrades = 0;

        SaveGame();
    }
}

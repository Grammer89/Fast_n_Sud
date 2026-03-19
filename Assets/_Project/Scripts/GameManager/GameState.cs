using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Singleton Declaration
    private static GameState _instance;
    private static bool _isApplicationQuitting = false;

    public static GameState Instance
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
            _instance = FindAnyObjectByType<GameState>(FindObjectsInactive.Include);
            if (_instance == null)
            {
                GameState prefab = Resources.Load<GameState>("Singletons/GameState");
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

    private int _totalCoins;
    public int TotalCoins { get { return _totalCoins; } set { _totalCoins = value; } }

    private bool _canDoubleJump = false;
    public bool CanDoubleJump { get { return _canDoubleJump; } set { _canDoubleJump = value; } }

    private int[] _topFiveScores = new int[5];
    public int[] TopFiveScores { get { return _topFiveScores; } set { _topFiveScores = value; } }

    private int _healthUpgrades = 0;
    public int HealthUpgrades { get { return _healthUpgrades; } set { _healthUpgrades = value; } }

    private bool _canUseBerserk = false;
    public bool CanUseBerserk { get { return _canUseBerserk; } set { _canUseBerserk = value; } }

    private int _berserkUpgrades = 0;
    public int BerserkUpgrades { get { return _berserkUpgrades; } set { _berserkUpgrades = value; } }

    private bool _canUseMagnet = false;
    public bool CanUseMagnet { get { return _canUseMagnet; } set { _canUseMagnet = value; } }

    private int _magnetUpgrades = 0;
    public int MagnetUpgrades { get { return _magnetUpgrades; } set { _magnetUpgrades = value; } }

    private void Start()
    {
        SaveSystem.Instance.LoadGame();
    }

    public void UnlockDoubleJump()
    {
        _canDoubleJump = true;
        Debug.Log("Hai sbloccato l'abilita' Doppio Salto!");
    }

    public void BuyBerserkMode()
    {
        if (!_canUseBerserk)
        {
            _canUseBerserk = true;
            Debug.Log("Hai sbloccato l'abilita' Berserk Mode!");
        }
        else
        {
            if (_berserkUpgrades <= 3)
                _berserkUpgrades++;
            else
                Debug.LogWarning("Impossibile potenziare. Hai gia' 3 potenziamenti!");
        }
    }

    public void BuyCoinMagnet()
    {
        if (!_canUseMagnet)
        {
            _canUseMagnet = true;
            Debug.Log("Hai sbloccato l'abilita' Coin Magnet!");
        }
        else
        {
            if (_magnetUpgrades <= 3)
                _magnetUpgrades++;
            else
                Debug.LogWarning("Impossibile potenziare. Hai gia' 3 potenziamenti!");
        }
    }

    public void AddHealthUpgrade()
    {
        if(_healthUpgrades <= 3)
            _healthUpgrades++;
        else
            Debug.LogWarning("Impossibile potenziare. Hai gia' 3 potenziamenti!");
    }

    public void AddCoinsToTotal(int coins)
    {
        _totalCoins += coins;
        Debug.Log($"Hai raccolto {coins} monete. Adesso hai un totale di {_totalCoins} monete.");
    }

    public void TakeCoinsFromTotal(int coins)
    {
        if(coins > _totalCoins)
        {
            Debug.LogWarning("Non hai abbastanza monete!");
            return;
        }

        _totalCoins -= coins;
        Debug.Log($"Hai speso {coins} monete. Adesso ti restano {_totalCoins} monete.");
    }

    public void CheckScoreTopFive(int newScore)
    {
        for(int i = _topFiveScores.Length - 1; i >= 0; i--)
        {
            if(newScore > _topFiveScores[i])
            {
                for(int j = i; j > 0; j--)
                {
                    _topFiveScores[j - 1] = _topFiveScores[j];
                }
                _topFiveScores[i] = newScore;
                Debug.Log($"Il punteggio {newScore} e' stato aggiunto alla Top 5!");
                return;
            }
        }
    }
}

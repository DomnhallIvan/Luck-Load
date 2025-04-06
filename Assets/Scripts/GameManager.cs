using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerRef;
    public PlayerHealth playerHealthRef;
    public UIInterface UIreference;
    public GameUI gameUI;
    public System.Action onReset;
    public System.Action onStartGame;
    public System.Action onNextRound;

    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            onStartGame += OnStartGame;
            playerHealthRef.OnDeath += Die;
        }
    }

    private void Start()
    {
        _playerHealth.OnDeath += Die;
    }

    public void OnStartGame()
    {
        playerRef.isDead = false;
        playerRef.ResetStats();
        playerHealthRef.SetCurrentHealth();
        playerHealthRef.SetCurrentShiled();
        playerHealthRef.SetCurrentRegen();
        //gameUI.UpdateScores(playerRef.healthPoints);
    }

    private void Die(Vector3 Position)
    {
        Debug.Log("Quack");
        gameUI.OnGameFailure();
        onReset?.Invoke();
        playerRef.isDead = true;
    }

    public void AddScoreEnemyD(int damage)
    {
        
        playerRef.scoreEnemy += damage;
        UIreference.SetScore(playerRef.scoreEnemy, 1);
    }

    public void AddScoreCoins(int damage)
    {
        playerRef.scoreCoins += damage;
        UIreference.SetScore(playerRef.scoreCoins, 0);
    }    

    public void AddWaveCount(int Count)
    {
        playerRef.waveCount += Count;
        UIreference.SetWave(playerRef.waveCount);
    }

    //Gets Called from Shopping
    public void OpenMenu()
    {
        gameUI.OpenShopMenu();
    }

 
    public void ChangeCoinValue()
    {
        UIreference.SetScore(playerRef.scoreCoins, 0);
    }
    /*

    private void CheckDied()
    {
        if (playerRef.healthPoints <= 0)
        {
            playerRef.healthPoints = 0;
            playerRef.isDead = true;
            //playerRef.Dead();
            gameUI.OnGameFailure(); //Se manda el jugador que gano
            onReset?.Invoke();
        }
    }

    public void Win()
    {
        gameUI.OnGameEnds();
        onReset?.Invoke();

    }

    private void OnStartGame()
    {
        //Reinicia vidas, el ScoreUI, y resetea toda la lista de RemainingPlayers
        playerRef.healthPoints = playerRef.maxHealthPoints;
        gameUI.UpdateScores(playerRef.healthPoints);
    }*/
}

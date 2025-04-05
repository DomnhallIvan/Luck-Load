using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerRef;
    public UIInterface UIreference;
    public GameUI gameUI;
    public System.Action onReset;
    public System.Action onStartGame;

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
            //onStartGame += OnStartGame;
        }
    }

    private void Start()
    {
        _playerHealth.OnDeath += Die;
    }

    private void Die(Vector3 Position)
    {
        gameUI.OnGameFailure();
        onReset?.Invoke();
        playerRef.isDead = true;
    }

    public void AddScoreEnemyD(int damage)
    {
        UIreference.SetScore(damage, 1);
    }

    public void AddScoreCoins(int damage)
    {
        UIreference.SetScore(damage, 0);
    }

    public void AddWaveCount(int Count)
    {

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

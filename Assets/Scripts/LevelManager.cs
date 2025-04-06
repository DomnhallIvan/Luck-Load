using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<WaveSO> waves;
    private int _currentWave = 0;
    [SerializeField] private int _enemiesRemaining = 0;
    private float _timer = 0;
    [SerializeField] public float waveSpawnInterval = 45f;

    private bool isSpawning = false;
    [SerializeField] private Spawner _spawnerRef;
    private bool _startGame = false;

    private void Start()
    {
        GameManager.instance.onStartGame += StartGame;
        GameManager.instance.onReset += EndGame;
        GameManager.instance.onNextRound += StartNextWave;
    }

    /*
    private void Update()
    {
        if (_startGame)
            if (!isSpawning && _timer <= 0)
            {
                if (_currentWave >= waves.Count)
                {
                    StopSpawning();
                }
                else
                    StartNextWave();

            }
            else
            {
                _timer -= Time.deltaTime;
            }
    }*/

    public void EnemyDestroyed()
    {
        _enemiesRemaining--;
        if (_enemiesRemaining == 0)
        {
            isSpawning = false;
            //reset the timer
            _timer = waveSpawnInterval;
            //OpenTheShopMenu
            GameManager.instance.OpenMenu();
            
            // Check if all waves are completed and all enemies are dead
            if (_currentWave >= waves.Count)
            {
               // GameManager.instance.Win();
            }
        }
    }

    void StartNextWave()
    {
        GameManager.instance.AddWaveCount(1);

        if (_currentWave < waves.Count)
        {
            WaveSO waveConfig = waves[_currentWave];
            _currentWave++;
            _spawnerRef.StartNextWave(waveConfig);
            _enemiesRemaining = GetTotalEnemies(waveConfig);
            isSpawning = true;
        }
        else
        {
            // Stay on the last wave
            _currentWave = waves.Count - 1;

            WaveSO waveConfig = waves[_currentWave];
            _spawnerRef.StartNextWave(waveConfig);
            _enemiesRemaining = GetTotalEnemies(waveConfig);
            isSpawning = true;
        }
    }


    private int GetTotalEnemies(WaveSO waveConfig)
    {
        int total = 0;
        foreach (var enemyData in waveConfig.enemies)
        {
            total += enemyData.count;
        }
        return total;
    }

    void StopSpawning()
    {
        _spawnerRef.StopSpawning();
        isSpawning = false;
    }

    void StartGame()
    {
        _startGame = true;
        _currentWave = 0;   // Reset wave count
        _enemiesRemaining = 0;  // Reset enemy count
        isSpawning = false;
        StartNextWave();
    }

    void EndGame()
    {
        _currentWave = 0;
        _startGame = false;
        _spawnerRef.NoMoreEnemies();
    }
}

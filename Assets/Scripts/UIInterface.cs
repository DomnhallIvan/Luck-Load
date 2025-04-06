using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _playerText; //CoinText,ScoreText
    [SerializeField] private TextMeshProUGUI _waveCount;
    [SerializeField] private Slider _HealthBar;
    [SerializeField] private Slider _ShieldBar;

    public void SetScore(int value,int textSelected)
    {
        _playerText[textSelected].text = value.ToString();
    }

    public void SetWave(int wave)
    {
        _waveCount.text = $"Current wave: {wave}";
    }

    public void SetCurrentHealthAbsolute(int current, int max)
    {
        _HealthBar.maxValue = max;
        _HealthBar.value = current;
    }

    public void SetCurrentShieldAbsolute(int current, int max)
    {
        _ShieldBar.maxValue = max;
        _ShieldBar.value = current;
    }
}

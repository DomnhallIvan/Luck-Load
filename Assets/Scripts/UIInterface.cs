using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _playerText; //CoinText,ScoreText
    [SerializeField] private TextMeshProUGUI _waveCount;

    public void SetScore(int value,int textSelected)
    {
        _playerText[textSelected].text = value.ToString();
    }

    public void SetWave(int wave)
    {
        _waveCount.text = $"Current wave: {wave}";
    }

}

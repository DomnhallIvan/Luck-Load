using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _playerText; //CoinText,ScoreText


    public void SetScore(int value,int textSelected)
    {
        _playerText[textSelected].text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

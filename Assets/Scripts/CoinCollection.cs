using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;
    //[SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private UIInterface _uiReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;

            _uiReference.SetScore(Coin, 0);
            //_coinText.text="Coin: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
        }
    }
}

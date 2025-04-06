using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    //Remplazar por un int del Player
    [SerializeField]private int coinvalue = 1;
    ////[SerializeField] private TextMeshProUGUI _coinText;
   // [SerializeField] private UIInterface _uiReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
           // Coin++;

            GameManager.instance.AddScoreCoins(coinvalue);
            ReturnToPool();
            //_coinText.text="Coin: " + Coin.ToString();
            //Debug.Log(Coin);
            //estroy(other.gameObject);
        }
    }

    private void ReturnToPool()
    {
        //Can be reused for other variants of Bullets
        ObjectPool pool = FindObjectOfType<ObjectPool>();
        if (pool != null)
        {
            string tag = gameObject.tag; // Use the tag of this GameObject
            pool.ReturnToPool(tag, gameObject);
        }
    }
}

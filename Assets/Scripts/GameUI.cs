using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas shopCanvas;
    //[SerializeField] private Canvas _uiCanvas;

    //SI le da clcik el evento onStartGame se invoca
    public void OnStartGameButtonClicked()
    {
        menuCanvas.enabled = false;
        //_uiCanvas.enabled = true;
       // ResetImage();
        GameManager.instance.onStartGame?.Invoke();
    }


    public void OnGameFailure()
    {
        menuCanvas.enabled = true;
        //_uiCanvas.enabled= false;
        winText.text = " YOU ARE DEAD NOT BIG SURPRISE";
    }

    public void OpenShopMenu()
    {
        shopCanvas.enabled = true;
    }

    public void CloseShopMenu()
    {
        shopCanvas.enabled = false;
        GameManager.instance.onNextRound?.Invoke();
    }
}

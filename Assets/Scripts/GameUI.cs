using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Canvas menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameFailure()
    {
        menuCanvas.enabled = true;
        winText.text = " THE ZOMBIES ATE YOUR BRAINS";
    }
}

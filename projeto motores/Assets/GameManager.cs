using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, MsgVitoria;

    public int restantes;

    // Start is called before the first frame update
    void Start()
    {
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"Reamaining Pins: {restantes}";

    }

    public void SubtrairMoedas(int valor)

    {
        restantes -= valor;
        hud.text = $"Reamaining Pins: {restantes}";
        
        if (restantes <= 0)
        {
            // ganhou o jogo
            MsgVitoria.text = "Strike! You're a true Belieber.";
        }
    }

// Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, MsgVitoria;

    public int restantes;
    public AudioClip clipMoeda, clipVitoria;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"Reamaining Pins: {restantes}";

    }

    public void SubtrairMoedas(int valor)

    {
        restantes -= valor;
        hud.text = $"Reamaining Pins: {restantes}";
        source.PlayOneShot(clipMoeda);
        if (restantes <= 0)
        {
            // ganhou o jogo
            MsgVitoria.text = "Strike! You're a true Belieber.";
            source.PlayOneShot(clipVitoria);
        }
    }

// Update is called once per frame
    void Update()
    {
        
    }
}

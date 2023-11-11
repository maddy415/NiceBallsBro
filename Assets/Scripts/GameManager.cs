using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI HUD, VictoryMessage;
    public int restantes;
    public AudioClip clipCoin, clipVictoryMessage;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Coin>().Length;

        HUD.text = $"Moedas restantes: {restantes}";
    }

    public void SubtrairMoedas(int valor)
    {
        restantes -= valor;
        HUD.text = $"Moedas restantes: {restantes}";
        source.PlayOneShot(clipCoin);

        if (restantes <= 0)
        {
            //ganhou o jogo
            VictoryMessage.text = "Você venceu!";
            source.Stop();
            source.PlayOneShot(clipVictoryMessage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public GameState GameState;
    public Text TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string score = MathF.Floor(GameState.SeccondsPassed * 10).ToString("00000.##");
        TextComponent.text = "Score: " + score;
    }
}
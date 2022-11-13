using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public GameState GameState;
    public Text TextComponent;

    void Start()
    {
        
    }

    void Update()
    {
        string score = MathF.Floor(GameState.SeccondsElapsed * 10).ToString("00000.##");
        TextComponent.text = "Score: " + score;
    }
}
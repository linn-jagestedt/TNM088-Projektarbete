using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    private Text _textComponent;

    void Start()
    {
        _textComponent = GetComponent<Text>();        
    }

    void Update()
    {
        string score = MathF.Floor(GameState.SeccondsElapsed * 10).ToString("00000.##");
        _textComponent.text = "Score: " + score;
    }
}
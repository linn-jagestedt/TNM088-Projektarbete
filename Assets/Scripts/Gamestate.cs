using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestate : MonoBehaviour
{
    // The speed at the start of the game
    public float InitialPlatformSpeed = 10;

    // The current speed
    public float CurrentPlatformSpeed { get => InitialPlatformSpeed * MathF.Round((_frameCounter / 1000.0f) + 1.0f); }
 
    // Counts the number of frames since the game started
    private long _frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        _frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _frameCounter++;
    }

    // Reset The Gamestate (new game)
    public void Reset()
    {
        _frameCounter = 0;
    }
}

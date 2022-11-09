using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // The speed at the start of the game
    public float InitialPlatformSpeed = 10;

    // The amount of time before the speed increases
    public float TimeUntilSpeedIncrease = 5;

    // The amount to increase the speed every time step
    public float SpeedIncrements = 5;

    // The current speed
    public float CurrentPlatformSpeed { 
        get => InitialPlatformSpeed + SpeedIncrements * MathF.Floor((_seccondsPassed / TimeUntilSpeedIncrease)); 
    }
 
    // Counts the number of frames since the game started
    public float SeccondsPassed { get => _seccondsPassed; }
    private float _seccondsPassed;

    // Start is called before the first frame update
    void Start()
    {
        _seccondsPassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Add the secconds passed since last frame to _seccondsPassed
        _seccondsPassed += Time.deltaTime;
        Debug.Log($"_frameCounter: {_seccondsPassed}, CurrentPlatformSpeed: {CurrentPlatformSpeed}");
    }

    // Reset The Gamestate (new game)
    public void Reset()
    {
        _seccondsPassed = 0;
    }
}
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
        get => InitialPlatformSpeed + SpeedIncrements * MathF.Floor((_seccondsElapsed / TimeUntilSpeedIncrease)); 
    }
 
    // Counts the number of secconds since the game started
    public float SeccondsElapsed { get => _seccondsElapsed;  }
    private float _seccondsElapsed;

    // Start is called before the first frame update
    void Start()
    {
        _seccondsElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Add the secconds passed since last frame to _seccondsPassed
        _seccondsElapsed += Time.deltaTime;
        Debug.Log($"_seccondsElapsed: {_seccondsElapsed}, CurrentPlatformSpeed: {CurrentPlatformSpeed}");
    }

    // Resets the Gamestate (new game)
    public void Reset()
    {
        _seccondsElapsed = 0;
    }
}
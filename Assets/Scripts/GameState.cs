using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameState : MonoBehaviour
{
    // The speed at the start of the game
    public float InitialPlatformSpeed = 10;

    // The amount of time before the speed increases
    public float TimeUntilSpeedIncrease = 5;

    // The amount to increase the speed every time step
    public float SpeedIncrements = 5;

    public PlayerScript Player;

    public PrefabSpawner[] Spawners;

    public UnityEngine.EventSystems.EventSystem EventSystem;

    public GameObject RestartButton;

    // The current speed
    public float CurrentPlatformSpeed { get => _currentPlatformSpeed; }
    private float _currentPlatformSpeed;
 
    // Counts the number of secconds since the game started
    public float SeccondsElapsed { get => _seccondsElapsed;  }
    private float _seccondsElapsed;

    // Counts the number of secconds since the game started
    public bool IsRunning { get => _isRunning;  }
    private bool _isRunning;

    private float _animationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _seccondsElapsed = 0;
        _isRunning = false;

        _animationSpeed = Player.Animator.speed;
        Player.Animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning) {
            // Add the secconds passed since last frame to _seccondsPassed
            _seccondsElapsed += Time.deltaTime;
            _currentPlatformSpeed = InitialPlatformSpeed + SpeedIncrements * MathF.Floor(_seccondsElapsed / TimeUntilSpeedIncrease);
        }
    }

    void FixedUpdate() {
        //bug.Log($"_seccondsElapsed: {_seccondsElapsed}, CurrentPlatformSpeed: {CurrentPlatformSpeed}");
    }


    // Resets the Gamestate (new game)
    public void StopGame()
    {
        _isRunning = false;

        _animationSpeed = Player.Animator.speed;
        Player.Animator.speed = 0;

        RestartButton.GetComponentsInChildren<Text>()[0].text = "Restart";
        RestartButton.SetActive(true);
    }

    // Resets the Gamestate (new game)
    public void StartGame()
    {
        _seccondsElapsed = 0;
        _isRunning = true;

        Player.Animator.speed = _animationSpeed;

        RestartButton.SetActive(false);

        foreach (PrefabSpawner spawner in Spawners) {
            spawner.Reset();
        }

        EventSystem.SetSelectedGameObject(null);    
    }
}
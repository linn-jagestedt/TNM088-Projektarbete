using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public ScreenShake ScreenShake;
    public GameState GameState;
    public PrefabSpawner[] Spawners;
    public float JumpHeight;
    private Rigidbody2D _rb;
    private bool _grounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _grounded = true;
    }

    void Update()
    {
        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && _grounded) {
            Debug.Log("jump");
            _rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            _grounded = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");

            ScreenShake.StartScreenShake();

            GameState.Reset();
            foreach (PrefabSpawner spawner in Spawners) {
                spawner.Reset();
            }
        }
    }
}
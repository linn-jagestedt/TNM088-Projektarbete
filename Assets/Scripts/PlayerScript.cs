using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameState GameState;
    public PrefabSpawner[] Spawners;
    public float JumpHeight;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("jump");
            _rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
            GameState.Reset();
            foreach (PrefabSpawner spawner in Spawners) {
                spawner.Reset();
            }
        }
    }
}
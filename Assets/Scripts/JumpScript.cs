using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpHeight;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("jump");
            rb.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
        }
    }
}
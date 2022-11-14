using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public GameState GameState;
    public float endX;
    public float startX;

    private void Update() {
        foreach (Transform child in transform) {
            if (child.transform.position.x < endX) {
                float newX = startX - (endX - child.transform.position.x);
                Vector2 pos = new Vector2(newX, child.transform.position.y);
                child.transform.position = pos;
            }
        }
    }

    private void FixedUpdate() {
        foreach (Rigidbody2D rb in GetComponentsInChildren<Rigidbody2D>()) {
            rb.velocity = Vector2.left * GameState.CurrentPlatformSpeed;
        }
    }
}
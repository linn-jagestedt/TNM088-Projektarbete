using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public Gamestate state;

    public float endX;
    public float startX;

    private void Update() {
        transform.Translate(Vector2.left * state.speed * Time.deltaTime);

        if (transform.position.x <= endX) {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}

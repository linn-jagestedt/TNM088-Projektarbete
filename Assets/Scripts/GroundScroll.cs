using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public Gamestate state;

    public float endX;
    public float startX;

    private void Update() {
        foreach (Transform child in transform) {
            child.transform.Translate(Vector2.left * state.speed * Time.deltaTime);

            if (child.transform.position.x < endX) {
                Vector2 pos = new Vector2(startX, child.transform.position.y);
                child.transform.position = pos;
            }
        }
    }
}

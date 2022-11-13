using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgrounds : MonoBehaviour
{
    public GameState GameState;
    public GameObject prefab;
    public float speedRatio;
    public int minTime;
    public int maxTime;
    public Vector2 Position;

    private float _secondsElapsed;
    private float _interval;

    // Start is called before the first frame update
    void Start()
    {
        _secondsElapsed = 0;
        _interval = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        _secondsElapsed += Time.deltaTime;

        if (_secondsElapsed > _interval) {
            _secondsElapsed = 0;
            Spawn();
            _interval = Random.Range(minTime, maxTime);
        }   
    }


    private void FixedUpdate() {
        foreach (Rigidbody2D rb in GetComponentsInChildren<Rigidbody2D>()) {
            rb.velocity = Vector2.left * GameState.CurrentPlatformSpeed;
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(prefab, Position, Quaternion.identity);
        obj.transform.parent = transform;

        Debug.Log("spawn background");
    }
}

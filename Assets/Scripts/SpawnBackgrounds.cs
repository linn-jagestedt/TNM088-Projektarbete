using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgrounds : MonoBehaviour
{
    private float backgroundSpeed;
    
    public Gamestate state;
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
        backgroundSpeed = state.speed * speedRatio;
    }

    // Update is called once per frame
    void Update()
    {
        _secondsElapsed += Time.deltaTime;

        if (_secondsElapsed > _interval) {
            _secondsElapsed = 0;
            Spawn();
            _interval = Random.Range(minTime, maxTime);
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(prefab, Position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.left * backgroundSpeed;

        Debug.Log("spawn background");
    }
}

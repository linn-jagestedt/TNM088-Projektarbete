using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    
    public GameState state;
    public GameObject prefab;
    public float speedRatio;
    public int minTime;
    public int maxTime;
    public Vector2 Position;
    public float EndX;

    private float _secondsElapsed;
    private float _interval;
    private GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _secondsElapsed = 0;
        _interval = Random.Range(minTime, maxTime);
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

        if (_enemy.transform.position.x <= EndX) {
            Destroy(_enemy);
        } 
    }

    void Spawn()
    {
        _enemy = Instantiate(prefab, Position, Quaternion.identity);
        _enemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * state.CurrentPlatformSpeed * speedRatio;;

        Debug.Log("spawn enemy");
    }
}

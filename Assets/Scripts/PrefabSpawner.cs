using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameState GameState;
    public GameObject[] Prefabs;
    public float SpeedRatio;
    public float MinInterval;
    public float MaxInterval;
    public Vector2 SpawnPosition;
    public float EndX;

    private float _secondsElapsed;
    private float _interval;
    private int _lastPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _lastPrefab = 0;
        _secondsElapsed = 0;
        _interval = Random.Range(MinInterval, MaxInterval);
    }

    void Update()
    {
        if (GameState.IsRunning) {
            _secondsElapsed += Time.deltaTime;

            if (_secondsElapsed > _interval) {
                _secondsElapsed = 0;
                Spawn();
                _interval = Random.Range(MinInterval, MaxInterval);
            }   
        }
    }

    private void FixedUpdate() {
        foreach (Transform child in transform) {
            if (child.position.x <= EndX) {
                Destroy(child.gameObject);
            }

            if (GameState.IsRunning) {
                child.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * GameState.CurrentPlatformSpeed * SpeedRatio;
            } else {
                child.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    private void Spawn()
    {
        int index = 0;
        
        if (Prefabs.Length > 1) {
            
            do {
                index = Random.Range(0, Prefabs.Length);
            } while (index == _lastPrefab);
    	    
            _lastPrefab = index;
        }
    	
        GameObject obj = Instantiate(Prefabs[index], SpawnPosition + (Vector2)Prefabs[index].transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }

    public void Reset() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}

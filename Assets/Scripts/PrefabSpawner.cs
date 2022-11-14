using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameState GameState;
    public GameObject Prefab;
    public float SpeedRatio;
    public int MinInterval;
    public int MaxInterval;
    public Vector2 SpawnPosition;
    public float EndX;

    private float _secondsElapsed;
    private float _interval;

    // Start is called before the first frame update
    void Start()
    {
        _secondsElapsed = 0;
        _interval = Random.Range(MinInterval, MaxInterval);
    }

    void Update()
    {
        _secondsElapsed += Time.deltaTime;

        if (_secondsElapsed > _interval) {
            _secondsElapsed = 0;
            Spawn();
            _interval = Random.Range(MinInterval, MaxInterval);
        }   
    }

    private void FixedUpdate() {
        foreach (Transform child in transform) {
            if (child.position.x <= EndX) {
                Destroy(child.gameObject);
            }

            child.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * GameState.CurrentPlatformSpeed * SpeedRatio;
        }
    }

    private void Spawn()
    {
        GameObject obj = Instantiate(Prefab, SpawnPosition, Quaternion.identity);
        obj.transform.parent = transform;
    }

    public void Reset() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
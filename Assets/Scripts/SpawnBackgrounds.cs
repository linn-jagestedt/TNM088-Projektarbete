using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgrounds : MonoBehaviour
{
    public GameObject prefab;
    public float speedRatio;
    public int minTime;
    public int maxTime;
    public Vector2 Position;
    public float EndX;

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
        foreach (Transform child in transform) {
            if (child.position.x <= EndX) {
                Destroy(child.gameObject);
            }

            child.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * GameState.CurrentPlatformSpeed * speedRatio;
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(prefab, Position, Quaternion.identity);
        obj.transform.parent = transform;

        Debug.Log("spawn background");
    }
}

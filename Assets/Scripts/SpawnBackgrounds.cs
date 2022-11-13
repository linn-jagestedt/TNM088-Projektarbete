using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgrounds : MonoBehaviour
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
    private GameObject _obj;

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

        if (_obj.transform.position.x <= EndX) {
            Destroy(_obj);
        } 
    }

    void Spawn()
    {
        _obj = Instantiate(prefab, Position, Quaternion.identity);
        _obj.GetComponent<Rigidbody2D>().velocity = Vector2.left * state.CurrentPlatformSpeed * speedRatio;;

        Debug.Log("spawn background");
    }
}

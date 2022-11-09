using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgrounds : MonoBehaviour
{
    public Gamestate state;
    private int backgroundSpeed;
    public GameObject prefab;
    public int minTime;
    public int maxTime;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() {
        Instantiate(prefab, new Vector2(0, 0), Quaternion.identity);
        Debug.Log("spawn prefab");
    }
}

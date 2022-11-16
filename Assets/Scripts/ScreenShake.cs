using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float EaseOutFactor;
    public float Magnitude;
    public float Duration;
    
    private float _magnitude;
    private bool _active;
    private float _countDown;
    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {   
        _countDown = 0;
        _active = false;
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_active) {
            
            _magnitude *= EaseOutFactor;
            _countDown -= Time.deltaTime;
            transform.position = _initialPosition + Random.insideUnitSphere * _magnitude;

            if (_countDown < 0) {
                _active = false;
                transform.localPosition = _initialPosition;
            }
        }
    }
    
    public void StartScreenShake() 
    {
        _countDown = Duration;
        _active = true;
        _magnitude = Magnitude;
    }
}

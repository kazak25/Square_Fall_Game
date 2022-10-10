using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _speed;

    private float _currentTime= 0;
    private bool _isMovingForward;
    private float _travelTime;

    private void Start()
    {
      _travelTime=  Vector3.Distance(_start.position, _end.position) / _speed;
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isMovingForward = !_isMovingForward;
        }

        _currentTime += _isMovingForward ? Time.deltaTime : -Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _travelTime) / _travelTime;
        var result = Vector3.Lerp(_start.position, _end.position, progress);
        transform.position = result;
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetA, _targetB;
    private Transform _targetPosition;
    [SerializeField] private float _speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = _targetB;
    }

    // Update is called once per frame (use physics)
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _speed * Time.deltaTime);

        if (transform.position == _targetB.position)
        {
            _targetPosition = _targetA;
        } else if (transform.position == _targetA.position)
        {    
            _targetPosition = _targetB;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}

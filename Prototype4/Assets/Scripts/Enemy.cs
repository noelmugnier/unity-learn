using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private GameObject _player;
    private float _speed = 5f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        _rigidBody.AddForce((_player.transform.position - transform.position).normalized * _speed);
    }
}

﻿using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble; // maximum tumble

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}

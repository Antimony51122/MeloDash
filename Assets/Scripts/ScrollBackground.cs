﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

interface IScrollable {
    void ScrollLeft();
}

public class ScrollBackground : MonoBehaviour {
    // ------------------------------------------------------
    // Config Params
    // ------------------------------------------------------

    [SerializeField] private float   scrollSpeed = -4f;
    [SerializeField] private Vector3 startPos    = new Vector3(0f, 0f, 0f);
    [SerializeField] private int     resetX      = -32;


    // ------------------------------------------------------
    // Cached Reference
    // ------------------------------------------------------


    ///////////////
    // Main Loop //
    ///////////////

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        float displacement = Time.deltaTime * scrollSpeed;
        transform.Translate(Vector2.right * displacement);

        // when the center of Wave scrolls to one screen width to the left of the original center,
        // reset the X of the Wave entity to it's original starting position
        if (transform.position.x < resetX) {
            transform.position = startPos;
        }
    }
}
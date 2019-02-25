using System;
using System.Collections.Generic;
using UnityEngine;
using  Core.VRMovementSystem;

class Player : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rotSpeed;

    void Update()
    {
        VRMovementSystem.VRMovement(transform, moveSpeed, rotSpeed);
    }
}


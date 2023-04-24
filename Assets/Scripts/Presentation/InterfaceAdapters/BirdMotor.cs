using System;
using FloppyBird.Core.Drivers.Physics;
using UnityEngine;

namespace FloppyBird.Presentation.InterfaceAdapters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMotor : MonoBehaviour, IBirdMotor
    {
        private Rigidbody2D _rigidBody2d; 
        
        public void Start()
        {
            _rigidBody2d = GetComponent<Rigidbody2D>();
        }

        public void UpdateVerticalVelocity(float upwardVelocity)
        {
            _rigidBody2d.velocity = Vector2.up * upwardVelocity;
        }
    }
}

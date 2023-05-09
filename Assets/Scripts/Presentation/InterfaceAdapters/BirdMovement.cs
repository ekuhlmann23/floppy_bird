using System;
using FloppyBird.Domain.InterfaceAdapters;
using UnityEngine;

namespace FloppyBird.Presentation.InterfaceAdapters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMovement : MonoBehaviour, IBirdMovement
    {
        private Rigidbody2D _rigidBody2D;

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        public void SetUpwardsVelocity(float newUpwardsVelocity)
        {
            _rigidBody2D.velocity = Vector2.up * newUpwardsVelocity;
        }
    }
}

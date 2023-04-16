using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class InputReaderSO : ScriptableObject, GameInput.IGameplayActions
{
    public event Action BirdJumped;

    private GameInput _gameInput;

    public void OnJump(InputAction.CallbackContext context)
    {
        BirdJumped?.Invoke();
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Disable();
    }

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Gameplay.AddCallbacks(this);
            _gameInput.Gameplay.Enable();
        }
    }
}

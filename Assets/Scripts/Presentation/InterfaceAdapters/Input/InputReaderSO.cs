using System;
using FloppyBird.Domain.InterfaceAdapters.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FloppyBird.Presentation.InterfaceAdapters.Input
{
    [CreateAssetMenu]
    public class InputReaderSO : ScriptableObject, GameInput.IGameplayActions, IInputReader
    {
        public event Action BirdJump;

        private GameInput _gameInput;

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Gameplay.AddCallbacks(this);
                _gameInput.Gameplay.Enable();
            }
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }


        public void OnJump(InputAction.CallbackContext context)
        {
            BirdJump?.Invoke();
        }
    }
}
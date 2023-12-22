using System.Linq;
using UnityEngine;

namespace _Project._Scripts.Core.Input
{
    public class InputSwitcher
    {
        private IInputHandler[] _inputHandlers;

        public InputSwitcher(IInputHandler[] inputHandlers)
        {
            _inputHandlers = inputHandlers;
        }

        public void SwitchInputScheme(InputState state)
        {
            var targetInputHandler = _inputHandlers.FirstOrDefault(x => x.State == state);
            if (targetInputHandler == null)
            {
                Debug.LogWarning("Trying to enable non-existing input handler");
                return;
            }

            DisableAllInputHandlers();
            targetInputHandler.Enable();
        }

        private void DisableAllInputHandlers()
        {
            foreach (var handler in _inputHandlers)
            {
                handler.Disable();
            }
        }
    }
}
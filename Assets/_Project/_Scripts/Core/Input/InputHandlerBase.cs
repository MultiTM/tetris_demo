using System;
using UnityEngine;

namespace _Project._Scripts.Core.Input
{
    public abstract class InputHandlerBase : MonoBehaviour, IInputHandler
    {
        public abstract InputState State { get; }
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
        }

        protected void ExecuteOnKeyDown(KeyCode[] keys, Action action)
        {
            foreach (var key in keys)   
            {
                if (UnityEngine.Input.GetKeyDown(key))
                {
                    action?.Invoke();
                    return;
                }
            }
        }
        
        protected void ExecuteOnAnyKeyDown(Action action)
        {
            if (UnityEngine.Input.anyKeyDown)
            {
                action?.Invoke();
            }
        }
    }
}
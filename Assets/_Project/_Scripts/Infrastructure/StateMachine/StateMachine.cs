using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public abstract class StateMachine<T> where T : IState
    {
        private List<T> _states;
        private T _currentState;

        public StateMachine(List<T> states)
        {
            _states = states;
        }
        
        public void EnterState<TState>() where TState : T
        {
            var targetState = _states.FirstOrDefault(x => x.GetType() == typeof(T));
            if (targetState == null)
            {
                Debug.LogWarning("Trying to enter non-existent state");
                return;
            }
            
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = targetState;
            _currentState.Enter();
        }
    }
}
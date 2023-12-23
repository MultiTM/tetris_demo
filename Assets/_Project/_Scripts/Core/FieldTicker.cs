using System.Collections;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class FieldTicker : MonoBehaviour
    {
        private Field _field;
        private float _tickDuration = 0.5f;
        private bool _isRunning = true;
        private WaitForSeconds _waiter;

        [Inject]
        private void Construct(Field field)
        {
            _field = field;
            SetTickDuration(_tickDuration);
        }

        public void SetTickDuration(float tickDuration)
        {
            _tickDuration = tickDuration;
            _waiter = new WaitForSeconds(_tickDuration);
        }
        
        public void StartTick()
        {
            _isRunning = true;
            StartCoroutine(TickRoutine());
        }

        private IEnumerator TickRoutine()
        {
            while (_isRunning)
            {
                yield return _waiter;
                _field.Tick();
            }
        }

        public void StopTick()
        {
            _isRunning = false;
        }
    }
}
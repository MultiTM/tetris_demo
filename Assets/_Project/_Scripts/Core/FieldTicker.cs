using System.Collections;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class FieldTicker : MonoBehaviour
    {
        private Field _field;
        private Coroutine _tickRoutine;
        private bool _isRunning = true;

        [Inject]
        private void Construct(Field field)
        {
            _field = field;
        }
        
        public void StartTick()
        {
            _tickRoutine = StartCoroutine(TickRoutine());
        }

        private IEnumerator TickRoutine()
        {
            while (_isRunning)
            {
                yield return new WaitForSeconds(0.5f);
                _field.Tick();
            }
        }

        public void StopTick()
        {
            StopCoroutine(_tickRoutine);
        }
    }
}
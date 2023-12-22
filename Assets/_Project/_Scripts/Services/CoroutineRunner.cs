using System.Collections;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Services
{
    public class CoroutineRunner : MonoBehaviour, IInitializable
    {
        public Coroutine RunRoutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void StopRoutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        public void Initialize()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
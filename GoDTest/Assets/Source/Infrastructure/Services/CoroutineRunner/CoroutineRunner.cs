using UnityEngine;

namespace Source.Infrastructure.Services.CoroutineRunner
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
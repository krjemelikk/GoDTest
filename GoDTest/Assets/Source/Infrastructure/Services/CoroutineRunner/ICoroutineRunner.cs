using System.Collections;
using UnityEngine;

namespace Source.Infrastructure.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}
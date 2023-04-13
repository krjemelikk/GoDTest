using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 MousePosition =>
            UnityEngine.Input.mousePosition;
    }
}
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.BootStrappers
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
    }
}
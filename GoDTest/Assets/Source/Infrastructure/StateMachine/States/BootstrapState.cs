using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine.States.Interfaces;

namespace Source.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.Load();
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }
    }
}
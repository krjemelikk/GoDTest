using Source.Infrastructure.StateMachine.States.Interfaces;

namespace Source.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IState;
        void Enter<TState, TConfig>(TConfig config) where TState : IConfigurableState<TConfig>;
    }
}
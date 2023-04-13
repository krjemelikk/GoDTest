using Source.Infrastructure.StateMachine.States.Interfaces;

namespace Source.Infrastructure.StateMachine.Factory
{
    public interface IStateFactory
    {
        IExitableState Create<TState>() where TState : IExitableState;
    }
}
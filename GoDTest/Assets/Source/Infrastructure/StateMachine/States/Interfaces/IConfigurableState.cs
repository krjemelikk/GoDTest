namespace Source.Infrastructure.StateMachine.States.Interfaces
{
    public interface IConfigurableState<in TConfig> : IExitableState
    {
        void Enter(TConfig config);
    }
}
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.Factory;
using Zenject;

namespace Source.Infrastructure.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            StateFactory();

            GameStateMachine();
        }

        private void GameStateMachine() => 
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();

        private void StateFactory() => 
            Container.BindInterfacesTo<StateFactory>().AsSingle();
    }
}
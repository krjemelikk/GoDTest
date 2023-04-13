using Source.Infrastructure.Services.LoadingScreen;
using Source.Infrastructure.Services.SceneLoader;
using Source.Infrastructure.StateMachine.States.Interfaces;

namespace Source.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IConfigurableState<string>
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(ISceneLoader sceneLoader, ILoadingScreen loadingScreen)
        {
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void Enter(string sceneName)
        {
            _loadingScreen.Show();
            _sceneLoader.LoadScene(sceneName);
        }

        public void Exit()
        {
            _loadingScreen.Hide();
        }
    }
}
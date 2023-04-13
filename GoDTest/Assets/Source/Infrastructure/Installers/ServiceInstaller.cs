using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services.CoroutineRunner;
using Source.Infrastructure.Services.Input;
using Source.Infrastructure.Services.LoadingScreen;
using Source.Infrastructure.Services.PersistentProgress;
using Source.Infrastructure.Services.SaveLoad;
using Source.Infrastructure.Services.SceneLoader;
using Source.Infrastructure.Services.StaticData;
using Zenject;

namespace Source.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SceneLoader();

            AssetProvider();

            StaticData();

            PersistentProgress();

            SaveLoad();

            LoadingScreen();

            CoroutineRunner();

            Input();
        }

        private void Input() =>
            Container.BindInterfacesTo<InputService>().AsSingle();

        private void PersistentProgress() =>
            Container.BindInterfacesTo<PersistentProgressService>().AsSingle();

        private void SaveLoad() => 
            Container.BindInterfacesTo<SaveLoadService>().AsSingle();

        private void SceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();

        private void AssetProvider() =>
            Container.BindInterfacesTo<AssetProvider>().AsSingle();

        private void StaticData() => 
            Container.BindInterfacesTo<StaticDataService>().AsSingle();

        private void LoadingScreen()
        {
            Container
                .BindInterfacesTo<LoadingScreen>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.LoadingScreen)
                .AsSingle();
        }

        private void CoroutineRunner()
        {
            Container
                .BindInterfacesTo<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunner)
                .AsSingle();
        }
    }
}
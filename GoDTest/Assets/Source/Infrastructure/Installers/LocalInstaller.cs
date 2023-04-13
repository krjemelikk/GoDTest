using Source.Infrastructure.Factory;
using Source.Infrastructure.Services.Inventory;
using Source.UI.Factory;
using Zenject;

namespace Source.Infrastructure.Installers
{
    public class LocalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UIFactory();

            InventoryService();

            ItemFactory();
        }

        private void ItemFactory() =>
            Container.BindInterfacesTo<ItemFactory>().AsSingle();

        private void InventoryService() => 
            Container.BindInterfacesTo<InventoryService>().AsSingle();

        private void UIFactory() =>
            Container.BindInterfacesTo<UIFactory>().AsSingle();
    }
}
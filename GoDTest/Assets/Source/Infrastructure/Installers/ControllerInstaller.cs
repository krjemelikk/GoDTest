using Source.Controllers;
using Zenject;

namespace Source.Infrastructure.Installers
{
    public class ControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InventoryController();
        }

        private void InventoryController()
        {
            Container.BindInterfacesTo<InventoryController>().AsSingle();
        }
    }
}
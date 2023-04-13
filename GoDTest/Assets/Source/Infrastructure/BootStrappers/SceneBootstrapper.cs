using Source.Controllers;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States;
using Source.UI.Factory;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.BootStrappers
{
    public class SceneBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        private IInventoryController _inventoryController;
        private IUIFactory _uiFactory;

        private void Start()
        {
            InitUI();
            InitControllers();
            _gameStateMachine.Enter<GameLoopState>();
        }

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IUIFactory uiFactory,
            IInventoryController inventoryController)
        {
            _gameStateMachine = gameStateMachine;
            _inventoryController = inventoryController;
            _uiFactory = uiFactory;
        }

        private void InitUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateButtons();
        }

        private void InitControllers()
        {
            _inventoryController.Initialize();
        }
    }
}
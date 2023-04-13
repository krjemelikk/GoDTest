using System.Collections.Generic;
using Source.Data;
using Source.Data.Inventory;
using Source.Enums;
using Source.Infrastructure.Services.PersistentProgress;
using Source.Infrastructure.Services.SaveLoad;
using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine.States.Interfaces;

namespace Source.Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticData;

        public LoadProgressState(
            IGameStateMachine gameStateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService,
            IStaticDataService staticData)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _staticData = staticData;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? CreateNewProgress();
        }

        private Progress CreateNewProgress()
        {
            var inventory = CreateInventory();
            return new Progress(inventory);
        }

        private InventoryData CreateInventory()
        {
            var initialData = _staticData.ForInventory();
            var dataForLocked = _staticData.ForItem(ItemTypeId.Locked);

            var inventorySize = initialData.LockedSlots + initialData.OpenedSlots;
            var inventorySlots = new List<InventorySlot>();

            for (var i = 0; i < initialData.OpenedSlots; i++)
                inventorySlots.Add(InventorySlot.EmptySlot());

            for (var i = 0; i < initialData.LockedSlots; i++)
                inventorySlots.Add(InventorySlot.LockedSlot(dataForLocked));

            return new InventoryData(initialData.InitialMoney, inventorySize, inventorySlots);
        }
    }
}
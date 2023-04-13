using Source.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Source
{
    public class GameSaver : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        private void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }
    }
}
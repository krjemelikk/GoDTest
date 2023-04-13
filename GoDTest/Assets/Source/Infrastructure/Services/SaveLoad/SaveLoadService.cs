using System.IO;
using Newtonsoft.Json;
using Source.Data;
using Source.Data.Converters;
using Source.Infrastructure.Services.PersistentProgress;
using Source.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly JsonConverter[] _converts;
        private readonly string _fullPath;
        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IPersistentProgressService progressService, IStaticDataService staticDataService)
        {
            _fullPath = Application.dataPath + "/Save/Progress.json";
            _progressService = progressService;

            _converts = new JsonConverter[]
            {
                new ItemDataConverter(staticDataService)
            };
        }

        public void SaveProgress()
        {
            var json = JsonConvert.SerializeObject(_progressService.Progress, Formatting.Indented, _converts);

            using (var writer = new StreamWriter(_fullPath, false))
            {
                writer.WriteLine(json);
            }
        }

        public Progress LoadProgress()
        {
            var json = "";

            if (!File.Exists(_fullPath))
                File.Create(_fullPath).Close();

            using (var reader = new StreamReader(_fullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null) json += line;
            }

            if (string.IsNullOrEmpty(json))
                return null;

            return JsonConvert.DeserializeObject<Progress>(json, _converts);
        }
    }
}
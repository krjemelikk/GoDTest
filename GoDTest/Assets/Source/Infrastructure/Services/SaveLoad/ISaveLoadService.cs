using Source.Data;

namespace Source.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        Progress LoadProgress();
    }
}
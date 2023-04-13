using Source.Data;

namespace Source.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public Progress Progress { get; set; }
    }
}
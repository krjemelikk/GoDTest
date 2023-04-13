using Source.Data;

namespace Source.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        Progress Progress { get; set; }
    }
}
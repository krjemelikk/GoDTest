using UnityEngine;

namespace Source.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        T Load<T>(string addressPath) where T : Object;
    }
}
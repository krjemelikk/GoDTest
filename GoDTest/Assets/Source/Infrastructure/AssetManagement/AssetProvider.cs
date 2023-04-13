using UnityEngine;

namespace Source.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string addressPath) where T : Object
        {
            return Resources.Load<T>(addressPath);
        }
    }
}
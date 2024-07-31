using System;
using System.IO;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace conpancka.Utils
{
    public static class AssetUtils
    {
        public static AssetBundle LoadAssetBundleFromEmbeddedResources(string bundleName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = null;
            try
            {
                resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(bundleName));
            }
            catch (Exception) { }

            if (resourceName == null)
            {
                Debug.LogError($"AssetBundle {bundleName} not found in assembly manifest");
                return null;
            }

            AssetBundle ret;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                ret = AssetBundle.LoadFromStream(stream);
            }

            return ret;
        }

        public static Sprite LoadSpriteFromEmbeddedResources(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourcePath = null;
            try
            {
                resourcePath = assembly.GetManifestResourceNames().SingleOrDefault(str => str.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception finding resource: {ex.Message}");
            }

            if (resourcePath == null)
            {
                Debug.LogError($"Resource '{resourceName}' not found in assembly manifest");
                return null;
            }

            byte[] imageData;
            using (var stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    Debug.LogError($"Stream for resource '{resourceName}' is null.");
                    return null;
                }

                using (var binaryReader = new BinaryReader(stream))
                {
                    imageData = binaryReader.ReadBytes((int)stream.Length);
                }
            }

            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(imageData))
            {
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                return sprite;
            }
            else
            {
                Debug.LogError("Failed to load texture from PNG data.");
                return null;
            }
        }
    }
}

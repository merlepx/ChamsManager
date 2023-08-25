using System.Collections.Generic;
using System.IO;

namespace ChamManager.Helpers
{
    public class AssetHelper
    {
        public static Dictionary<string, Shader> shaders = new Dictionary<string, Shader>();

        private static readonly string folderPath = $"{Application.dataPath}/ChamsManager";

        public static void GetAssets()
        {
            shaders.Clear();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Logging.Log("ChamsManager folder was not found, automatically created at " + folderPath);
                return;
            }
            string[] files = Directory.GetFiles(folderPath);
            foreach (string filePath in files)
            {
                AssetBundle assetBundle = AssetBundle.LoadFromFile(filePath);
                if (assetBundle != null)
                {
                    Shader[] bundleShaders = assetBundle.LoadAllAssets<Shader>();
                    foreach (Shader shader in bundleShaders)
                    {

                        if (!shaders.ContainsKey(shader.name))
                        {
                            shaders.Add(shader.name, shader);
                            Logging.Log("Shader added - " + shader.name);
                        }
                    }
                    assetBundle.Unload(false);
                }
                else
                    Logging.Log("Failed to load AssetBundle - " + filePath);
            }
        }
    }
}

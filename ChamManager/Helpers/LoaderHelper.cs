using ChamManager.Windows;
using ChamManager.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamManager.Helpers
{
    public class LoaderHelper : MonoBehaviour
    {
        private void Start()
        {
            File.WriteAllText("ChamsManager.log", "");

            AssetHelper.GetAssets();

            ChamsPreview.Init();

            Logging.Log("ChamsManager Loaded");
        }

        public void Update()
        {
            if (ChamsPreview.ChamPreviewCamera == null)
                ChamsPreview.Init();
        }
    }
}

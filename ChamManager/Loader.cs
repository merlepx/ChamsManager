using ChamManager.Helpers;
using ChamManager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamManager
{
    public class Loader
    {
        public static GameObject gameobject;

        public static void Load()
        {
            gameobject = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(gameobject);
            gameobject.AddComponent<LoaderHelper>();
            gameobject.AddComponent<Menu>();
        }
    }
}

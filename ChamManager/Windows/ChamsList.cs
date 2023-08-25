using ChamManager.Helpers;
using ChamManager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChamManager.Windows
{
    public class ChamsList
    {
        public static string selectedShaderName = "None";
        public static Shader selectedShader;
        public static Material originalMaterial;

        public static void Window()
        {
            GUILayout.Box("Selected Shader - " + selectedShaderName);

            foreach (var shader in AssetHelper.shaders)
            {
                if (GUILayout.Button(shader.Key))
                {
                    selectedShaderName = shader.Key;
                    selectedShader = shader.Value;
                    originalMaterial = null;
                    ChamsPreview.PreviewShader(shader.Value, Menu.chamscolor);
                }
            }

            GUI.DragWindow();
        }
    }
}

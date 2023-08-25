using ChamManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Diagnostics;

namespace ChamManager.Windows
{
    public class Menu : MonoBehaviour
    {
        public bool MenuOpen = false;

        public Rect chamsManagerWindowRect = new Rect(385, 20, 256, 150);
        public Rect chamsListRect = new Rect(205, 50, 175, 275);
        public Rect chamsPreviewWindowRect;

        public bool raycastToggle = false;

        public static Color chamscolor = Color.clear;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
                MenuOpen = !MenuOpen;

            if (Input.GetKeyDown(KeyCode.Backslash) && raycastToggle)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        ShaderHelper.ApplyLocalPlayerChams(ChamsList.originalMaterial);
                    }
                }
            }
        }

        private void OnGUI()
        {
            if (MenuOpen)
            {
                chamsManagerWindowRect = GUI.Window(0, chamsManagerWindowRect, ChamsManagerWindow, "Chams Manager");

                chamsPreviewWindowRect = new Rect(chamsManagerWindowRect.x, chamsManagerWindowRect.y + chamsManagerWindowRect.height + 5f, 256, 240);


                chamsPreviewWindowRect = GUILayout.Window(1, chamsPreviewWindowRect, ChamsPreviewWindow, "Chams Preview");
                chamsListRect = GUILayout.Window(2, chamsListRect, ChamsListWindow, "Chams List");
            }
        }

        private void ChamsManagerWindow(int id)
        {
            GUILayout.Box("Loaded Shaders - " + AssetHelper.shaders.Count.ToString());
            GUILayout.Label("Raycast Chams - Apply chams to whatever you're looking at");
            raycastToggle = GUILayout.Toggle(raycastToggle, "Raycast Chams");
            if (GUILayout.Button("Refresh Chams List"))
                AssetHelper.GetAssets();

            GUI.DragWindow();
        }


        private void ChamsListWindow(int id) =>
            ChamsList.Window();

        private void ChamsPreviewWindow(int id) =>
            ChamsPreview.Window();


    }
}

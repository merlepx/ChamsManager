using ChamManager.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace ChamManager.Windows
{
    public class ChamsPreview
    {
        private static GameObject cameraHolder;
        public static Camera ChamPreviewCamera { get; private set; }
        private static GameObject chamPreviewSphere;
        public static RenderTexture cameraTexture;

        public static void Window()
        {
            if (ChamPreviewCamera != null && chamPreviewSphere != null)
                GUILayout.Box(cameraTexture);
            if (GUILayout.Button("Apply Shader"))
                ShaderHelper.ApplyLocalPlayerChams(ChamsList.originalMaterial);
        }

        public static void Init()
        {
            Logging.Log("Creating Cham Preview");

            cameraHolder = new GameObject("ChamPreviewCamHolder");
            cameraTexture = new RenderTexture(200, 200, 1, RenderTextureFormat.DefaultHDR);

            ChamPreviewCamera = cameraHolder.AddComponent<Camera>();
            ChamPreviewCamera.enabled = true; // Set enabled after adding the component
            ChamPreviewCamera.transform.position = new Vector3(0f, -1000f, 0f);
            ChamPreviewCamera.targetTexture = cameraTexture;
            ChamPreviewCamera.cullingMask = 1 << 30;

            chamPreviewSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            chamPreviewSphere.transform.position = new Vector3(0f, -1000f, 1.2f);
            chamPreviewSphere.layer = 30;
        }

        public static void PreviewShader(Shader shader, Color color)
        {
            if (chamPreviewSphere)
            {
                Renderer renderer = chamPreviewSphere.GetComponent<Renderer>();
                Material material = new Material(shader);

                if (color != Color.clear)
                    material.SetColor("_Color", color);

                renderer.material = material;
            }
        }

        public static void PreviewMaterial(Material material, Color color)
        {
            if (chamPreviewSphere)
            {
                Renderer renderer = chamPreviewSphere.GetComponent<Renderer>();

                if (color != Color.clear)
                    material.SetColor("_Color", color);
                renderer.material = material;
            }
        }
    }
}

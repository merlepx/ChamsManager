using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using SDG.Unturned;
using ChamManager.Windows;

namespace ChamManager.Helpers
{
    internal class ShaderHelper
    {

        public static void ApplyShader(Material material, GameObject pgo)
        {
            if (material == null)
            {
                ApplyLocalPlayerChams(ChamsList.selectedShader);
                return;
            }
            Renderer[] rds = pgo.GetComponentsInChildren<Renderer>();

            for (int j = 0; j < rds.Length; j++)
            {
                Material[] materials = rds[j].materials;

                for (int k = 0; k < materials.Length; k++)
                {
                    materials[k] = material;
                }
            }
        }

        public static void ApplyShader(Shader shader, GameObject pgo)
        {
            if (shader == null) return;

            Renderer[] rds = pgo.GetComponentsInChildren<Renderer>();

            for (int j = 0; j < rds.Length; j++)
            {
                Material[] materials = rds[j].materials;

                for (int k = 0; k < materials.Length; k++)
                {
                    materials[k].shader = shader;

                }
            }
        }


        //both local player functions for unturned
        public static void ApplyLocalPlayerChams(Shader shader)
        {
            if (shader == null) return;
            for (int i = 0; i < Provider.clients.Count; i++)
            {
                SteamPlayer player = Provider.clients[i];
                if (player.player != Player.player)
                    return;


                Renderer[] rds = player.player.gameObject.GetComponentsInChildren<Renderer>();

                for (int j = 0; j < rds.Length; j++)
                {
                    Material[] materials = rds[j].materials;

                    for (int k = 0; k < materials.Length; k++)
                    {
                        materials[k].shader = shader;

                    }
                }
            }
        }

        public static void ApplyLocalPlayerChams(Material material)
        {
            if (material == null)
            {
                ApplyLocalPlayerChams(ChamsList.selectedShader);
                return;
            }
            for (int i = 0; i < Provider.clients.Count; i++)
            {
                SteamPlayer player = Provider.clients[i];
                if (player.player != Player.player)
                    continue;

                Renderer[] renderers = player.player.gameObject.GetComponentsInChildren<Renderer>();

                foreach (Renderer renderer in renderers)
                {
                    Material[] materials = renderer.materials;

                    for (int k = 0; k < materials.Length; k++)
                    {
                        renderer.material = material;
                    }
                }
            }
        }
    }
}

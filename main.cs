using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Windows;
using Unity.Netcode;
using GameNetcodeStuff;
using LC_API;
using System.Drawing.Text;
using System.Windows.Forms;
using LC_API.BundleAPI;
using JetBrains.Annotations;
using System.Xml.Linq;
using System.IO;
using BepInEx.Configuration;
using UnityEngine.Rendering;
using System.Drawing;
using static UnityEngine.GraphicsBuffer;
using Discord;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
namespace spessmancheeto
{

    internal class Cheeto : MonoBehaviour
    {


        private bool Initializer = false;
        private bool Objectscanner = false;
        public static bool cheatisopen = false;
        GameObject cheatMenu;
        public static List<GameObject> Toilet = new List<GameObject>();
        int testcontainer;
        private float timer = 0f;
        private float interval = 5f;
        public List<string> Enemynames = new List<String>();
        public List<string> Itemnames = new List<String>();
        void Start()
        {
            Regex regex = new Regex(@"\(([^)]*)\)");

            string enemyNamesInput = Interfacer.Config_Enemylist.Value;
            string itemNamesInput = Interfacer.Config_Itemlist.Value;

            MatchCollection enemyNamesMatches = regex.Matches(enemyNamesInput);
            foreach (Match match in enemyNamesMatches)
            {
                Enemynames.Add(match.Groups[1].Value);
            }

            MatchCollection itemNamesMatches = regex.Matches(itemNamesInput);
            foreach (Match match in itemNamesMatches)
            {
                Itemnames.Add(match.Groups[1].Value);
            }
        }
        void Update()
        {
            void Scrapupdater()
            {
                Toilet.Clear();
                foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
                {
                    if (go.activeInHierarchy)
                    {

                        if (Itemnames.Any(name => go.name.Contains(name)))
                        {
                            Toilet.Add(go);
                            var rend = go.GetComponentsInChildren<Renderer>();
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZWrite", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestGBuffer", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestDepthEqualForOpaque", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EnableFogOnTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensityUnit", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_UseEmissiveIntensity", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensity", 5);
                            foreach (Renderer Renderer in rend) Renderer.material.SetVector("_EmissiveColor", Interfacer.Itemcolor);
                            foreach (Renderer Renderer in rend) Renderer.material.renderQueue = 2500;
                        }
                    }
                }
            }
            void Enemyupdater()
            {
                Toilet.Clear();
                foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
                {
                    if (go.activeInHierarchy)
                    {
                        if (Enemynames.Any(name => go.name.Contains(name)))
                        {
                            Toilet.Add(go);
                            var rend = go.GetComponentsInChildren<Renderer>();
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZWrite", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestGBuffer", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestDepthEqualForOpaque", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EnableFogOnTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensityUnit", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_UseEmissiveIntensity", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensity", 5);
                            foreach (Renderer Renderer in rend) Renderer.material.SetVector("_EmissiveColor", Interfacer.Enemycolor);
                            foreach (Renderer Renderer in rend) Renderer.material.renderQueue = 2500;
                        }
                    }
                }
            }
            void Teamupdater()
            {
                Toilet.Clear();
                foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
                {
                    if (go.activeInHierarchy)
                    {
                        if (go.name.Contains("ScavengerModel"))
                        {
                            Toilet.Add(go);
                            var rend = go.GetComponentsInChildren<Renderer>();
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZWrite", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestGBuffer", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestDepthEqualForOpaque", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_ZTestTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EnableFogOnTransparent", 0);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensityUnit", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_UseEmissiveIntensity", 1);
                            foreach (Renderer Renderer in rend) Renderer.material.SetFloat("_EmissiveIntensity", 5);
                            foreach (Renderer Renderer in rend) Renderer.material.SetVector("_EmissiveColor", Interfacer.Teamcolor);
                            foreach (Renderer Renderer in rend) Renderer.material.renderQueue = 2500;
                        }
                    }
                }
            }
            GameObject Systems = GameObject.Find("Systems");
            Systems.transform.Find("Rendering").Find("VolumeMain").gameObject.SetActive(false);

            bool flag = !this.isInitialized;
            if (flag)
            {
                bool flag2 = StartOfRound.Instance != null;
                if (flag2)
                {
                    Debug.Log("Playercount: " + GetConnectedPlayers().ToString());
                }
                bool flag3 = !this.isInitialized && StartOfRound.Instance != null && GetConnectedPlayers() == 1;
                if (flag3)
                {
                    this.isInitialized = true;
                }
            }
            
            if (StartOfRound.Instance != null)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    Enemyupdater();
                    timer = 0f;
                }
                if (Keyboard.current.f6Key.wasPressedThisFrame)
                {
                    Scrapupdater();
                    Teamupdater();
                }

                if (Keyboard.current.f5Key.wasPressedThisFrame)
                {
                    if (cheatisopen)
                    {
                        ClosecheatUI();
                    }
                    else
                    {
                        OpencheatUI();
                    }

                }

                void ClosecheatUI()
                {
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                    UnityEngine.Cursor.visible = false;
                    cheatMenu.SetActive(false);
                    cheatisopen = false;
                }
                void OpencheatUI()
                {
                    UnityEngine.Cursor.lockState = CursorLockMode.None;
                    UnityEngine.Cursor.visible = true;
                    cheatMenu.SetActive(true);
                    cheatisopen = true;
                }

            }

        }
        public static int GetConnectedPlayers()
        {
            return StartOfRound.Instance.connectedPlayersAmount + 1;
        }
        private bool isInitialized;
    }

}
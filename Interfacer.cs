using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using LC_API.ServerAPI;
using BepInEx;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Windows;
using Unity.Netcode;
using GameNetcodeStuff;
using JetBrains.Annotations;
using LC_API.BundleAPI;
using LC_API;
using BepInEx.Configuration;

namespace spessmancheeto
{
    [BepInPlugin("spessmancheeto", "spessmancheeto", "1.0.0")]
    public class Interfacer : BaseUnityPlugin
    {
        private void Awake()
        {
            Config_Enemylist = Config.Bind("Lists", "EnemyList", "(Crawler) (BaboonBird) (DressGirl) (HoarderBug) (Blob) (Turret) (Landmine) (JesterEnemy) (MaskedPlayerEnemy) (Centipede) (MouthDog) (SandSpider) (SandWorm) (SpringMan) (Flowerman) (ForestGiant) (NutcrackerEnemy)");
            Config_Itemlist = Config.Bind("Lists", "ScrapList", "(Airhorn) (Clownhorn) (RedLocustHive) (BinFullOfBottles) (RedSodaCan) (GiftBox) (ChemicalJug) (FishTestProp) (EnginePart) (Key) (HandBell) (RubberDucky) (Cog) (PerfumeBottle) (Mug) (WhoopieCushion) (Painting) (Hairbrush) (BigBolt) (FancyRing) (Dentures) (RobotToy) (TragedyMask) (ComedyMask) (FancyGlass) (Magic7Ball) (PillBottle) (OldPhone) (Toothpaste) (FancyLamp) (Hairdryer) (MagnifyingGlass) (ToyCube)");
            Config_Enemycolor = Config.Bind("Colors (Red,Green,Blue,Alpha)", "Enemycolor", new Vector4(5, 0, 0, 1));
            Config_Itemcolor = Config.Bind("Colors (Red,Green,Blue,Alpha)", "Scrapcolor", new Vector4(5, 0, 5, 1));
            Config_Teamcolor = Config.Bind("Colors (Red,Green,Blue,Alpha)", "Teamcolor", new Vector4(0, 5, 0, 1));
            Enemynames = Config_Enemylist.Value;
            Itemnames = Config_Itemlist.Value;
            Enemycolor = Config_Enemycolor.Value;
            Itemcolor = Config_Itemcolor.Value;
            Teamcolor = Config_Teamcolor.Value;
            base.Logger.LogInfo("Cheeto hours");
            _harmony = new Harmony("Cheeto");
            _harmony.PatchAll();
            base.Logger.LogInfo("Cheeto time");
            Interfacer.bundle = BundleUtilities.LoadBundleFromInternalAssembly("cheatmenu");
            Interfacer.cheatMenu = Interfacer.bundle.LoadPersistentAsset<UnityEngine.GameObject>("Assets/Prefabs/cheatmenu.prefab");
        }

        private void OnDestroy()
        {
            bool flag = !Interfacer._loaded;
            if (flag)
            {

                GameObject gameObject = new GameObject("Cheeto");
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                gameObject.AddComponent<Cheeto>();
                Interfacer._loaded = true;
            }
        }
        public static ConfigEntry<string> Config_Enemylist;
        public static ConfigEntry<string> Config_Itemlist;
        public static ConfigEntry<Vector4> Config_Enemycolor;
        public static ConfigEntry<Vector4> Config_Teamcolor;
        public static ConfigEntry<Vector4> Config_Itemcolor;
        public static string Enemynames;
        public static string Itemnames;
        public static Vector4 Enemycolor;
        public static Vector4 Itemcolor;
        public static Vector4 Teamcolor;
        public static AssetBundle bundle;
        private static bool _loaded;
        public static GameObject cheatMenu;
        private Harmony _harmony;
    }
}

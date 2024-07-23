using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using KiraExtraPieces.Parts;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace KiraExtraPieces
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInProcess("Screw Drivers")]
    [BepInDependency("Kira.ExtraPieces", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Kira.KiraExtraPieces";
        private const string modName = "Kira Extra Pieces";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        public static ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

        public static AssetBundle Assets { get; private set; }

        public void LoadAssets()
        {
            Assets = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "KiraExtraPieces\\kira-extraparts"));
            mls.LogInfo($"Loading {modName} assets");
            foreach (string name in Assets.GetAllAssetNames())
            {
                mls.LogInfo($"- {name}");
            }
        }

        public Plugin()
        {
        }

        void Awake()
        {
            harmony.PatchAll(typeof(Plugin));

            LoadAssets();

            MakePart.MakeAll();

            mls.LogInfo($"{modName}-{modVersion} patches applied");
        }

        public static GameObject LoadModel(string path) => Assets.LoadAsset<GameObject>($"{path}.prefab");
    }
}

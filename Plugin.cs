using BepInEx;
using BepInEx.Logging;
using ExtraPieces.PartMapping;
using ExtraPieces.Utils;
using HarmonyLib;
using KiraExtraPieces.Parts;
using System.IO;
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

        public Plugin()
        {
        }

        void Awake()
        {
            harmony.PatchAll(typeof(Plugin));

            Assets = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "KiraExtraPieces\\kira-extraparts"));
            foreach (string name in Assets.GetAllAssetNames())
            {
                mls.LogInfo($"Found asset: {name}");
            }

            MapParts();

            mls.LogInfo("Extra Pieces patches applied");
        }

        public static GameObject LoadModel(string path) => Assets.LoadAsset<GameObject>($"{path}.prefab");

        private static readonly PartCombustionEngine    partCombustionEngine        = new PartCombustionEngine();
        private static readonly PartPinRound4x1         partPinRound4x1             = new PartPinRound4x1();
        private static readonly PartBolt                partBolt                    = new PartBolt();
        private static readonly PartBeamCorner1x3       partBeamCorner1x3           = new PartBeamCorner1x3();
        private static readonly PartBeam1x4             partBeam1x4                 = new PartBeam1x4();

        private static ConnectionpointData[] partBeam1x6Connections =
        {
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 0f)),
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 1f)),
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 2f)),
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 3f)),
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 4f)),
            ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 5f)),
        };

        private static readonly Part partBeam1x6 = CustomPartUtils.MakeBeam(
            connections: partBeam1x6Connections, 
            partType: ExtraPartType.PartBeam1x6.GetPartType(), 
            partName: "Beam x6", 
            mass: 4f, 
            health: 4f, 
            price: 20, 
            importPartBase: PartType.Part1x1x3);

        private static void MapParts()
        {
            PartMap partBeam1x6Map = new PartMap(
                enumName: ExtraPartType.PartBeam1x6.GetName(),
                instance: partBeam1x6,
                model: LoadModel("beam_4x"),
                mappedSprite: PartType.Part1x1x5
            );
            Mapping.AddPart(partBeam1x6Map);

            PartMap partCombustionEngineMap = new PartMap(
                enumName: ExtraPartType.PartCombustionEngine.GetName(),
                instance: partCombustionEngine,
                mappedModel: PartType.PartMotorCombustionReal4,
                mappedSprite: PartType.PartMotorCombustionReal4
            );
            Mapping.AddPart(partCombustionEngineMap);

            PartMap partPinRound4x1Map = new PartMap(
                enumName: ExtraPartType.PartPinRound4x1.GetName(),
                instance: partPinRound4x1,
                mappedModel: PartType.PartAxis1x4,
                mappedSprite: PartType.PartAxis1x4
            );
            Mapping.AddPart(partPinRound4x1Map);

            PartMap partBoltMap = new PartMap(
                enumName: ExtraPartType.PartBolt.GetName(),
                instance: partBolt,
                model: LoadModel("bolt"),
                mappedSprite: PartType.PartPinRound2x1
            );
            Mapping.AddPart(partBoltMap);

            PartMap partBeamCorner1x3Map = new PartMap(
                enumName: ExtraPartType.PartBeamCorner1x3.GetName(),
                instance: partBeamCorner1x3,
                model: LoadModel("beam_l_3x"),
                mappedSprite: PartType.Part1x1x3
            );
            Mapping.AddPart(partBeamCorner1x3Map);

            PartMap partBeam1x4Map = new PartMap(
                enumName: ExtraPartType.PartBeam1x4.GetName(),
                instance: partBeam1x4,
                model: LoadModel("beam_4x"),
                mappedSprite: PartType.Part1x1x3
            );
            Mapping.AddPart(partBeam1x4Map);
        }
    }
}

using ExtraPieces.PartMapping;
using ExtraPieces.Utils;
using System;
using UnityEngine;

namespace KiraExtraPieces.Parts
{
    internal static class MakePart
    {
        public static GameObject LoadModel(string path) => Plugin.Assets.LoadAsset<GameObject>($"{path}.prefab");

        public static void MakeAll()
        {
            MakeBeam1x6();
            MakeBolt();
            MakePinRoundx4();
            MakeBeam1x4();
            MakeBeamCorner1x3();
            MakeBeamT1x4();
            MakeCombustionEngine();

            OverridePinRoundx2();
        }

        internal class PartPinRound2x1Custom : PartPinRound2x1
        {
            public override bool IsColorable => true;
        }

        public static void OverridePinRoundx2() => Mapping.OverridePart(PartType.PartPinRound2x1, new PartPinRound2x1Custom());

        public static void MakeBolt()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Forward, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Forward, new Vector3(0f, -1f, 0f)),
            };

            Part instance = CustomPartUtils.MakePinRound(
                connections: connections,
                partType: ExtraPartType.PartBolt.GetPartType(), 
                partName: "Bolt x2", 
                mass: 2f, 
                health: 4f,
                price: 30, 
                importPartBase: PartType.PartPinRound2x1);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartBolt.GetName(),
                instance: instance,
                model: LoadModel("bolt"),
                mappedSprite: PartType.PartPinRound2x1
            );
            Mapping.AddPart(map);
        }

        public static void MakePinRoundx4()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Up, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Up, new Vector3(1f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Up, new Vector3(2f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundPin>(Direction.Up, new Vector3(3f, 0f, 0f)),
            };

            Part instance = CustomPartUtils.MakePinRound(
                connections: connections,
                partType: ExtraPartType.PartPinRound4x1.GetPartType(),
                partName: "Pin x4",
                tooltipText: "A larger type of pin",
                mass: 2f,
                health: 4f,
                price: 30,
                importPartBase: PartType.PartPinRound3x1);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartPinRound4x1.GetName(),
                instance: instance,
                model: LoadModel("pin_x4"),
                mappedSprite: PartType.PartAxis1x4
            );
            Mapping.AddPart(map);
        }

        public static void MakeBeamCorner1x3()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(-1f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 1f)),
            };

            Part instance = CustomPartUtils.MakeBeam(
                connections: connections,
                partType: ExtraPartType.PartBeamCorner1x3.GetPartType(),
                partName: "Beam Corner x3",
                mass: 3f,
                health: 3f,
                price: 5,
                importPartBase: PartType.Part1x1x3);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartBeamCorner1x3.GetName(),
                instance: instance,
                model: LoadModel("beam_l_x3"),
                mappedSprite: PartType.Part1x1x3
            );
            Mapping.AddPart(map);
        }

        public static void MakeBeamT1x4()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(1f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(-1f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 1f)),
            };

            Part instance = CustomPartUtils.MakeBeam(
                connections: connections,
                partType: ExtraPartType.PartBeamT1x4.GetPartType(),
                partName: "Beam T x4",
                mass: 4f,
                health: 4f,
                price: 8,
                importPartBase: PartType.Part1x1x3);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartBeamT1x4.GetName(),
                instance: instance,
                model: LoadModel("beam_t_x4"),
                mappedSprite: PartType.Part1x1x3
            );
            Mapping.AddPart(map);
        }

        public static void MakeBeam1x4()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 2f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 3f)),
            };

            Part instance = CustomPartUtils.MakeBeam(
                connections: connections,
                partType: ExtraPartType.PartBeam1x4.GetPartType(),
                partName: "Beam x4",
                mass: 4f,
                health: 4f,
                price: 20,
                importPartBase: PartType.Part1x1x3);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartBeam1x4.GetName(),
                instance: instance,
                model: LoadModel("beam_x4"),
                mappedSprite: PartType.Part1x1x3
            );
            Mapping.AddPart(map);
        }

        public static void MakeBeam1x6()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 2f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 3f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 4f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole>(Direction.Forward, new Vector3(0f, 0f, 5f)),
            };

            Part instance = CustomPartUtils.MakeBeam(
                connections: connections,
                partType: ExtraPartType.PartBeam1x6.GetPartType(),
                partName: "Beam x6",
                mass: 6f,
                health: 6f,
                price: 25,
                importPartBase: PartType.Part1x1x5);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartBeam1x6.GetName(),
                instance: instance,
                model: LoadModel("beam_x6"),
                mappedSprite: PartType.Part1x1x5
            );
            Mapping.AddPart(map);
        }

        public static void MakeCombustionEngine()
        {
            ConnectionpointData[] connections =
            {
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole> (Direction.Up, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole> (Direction.Up, new Vector3(0f, 2f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole> (Direction.Up, new Vector3(1f, 2f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorRoundHole> (Direction.Up, new Vector3(1f, 0f, 0f)),

                ConnectionpointUtils.NewConnectionPoint<ConnectorCrossHole> (Direction.Up, new Vector3(0f, 1f, -1f)),

                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(1f, 1f, 0f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(1f, 1f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(1f, 0f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(1f, 2f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(0f, 1f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(0f, 2f, 1f)),
                ConnectionpointUtils.NewConnectionPoint<ConnectorSolid> (Direction.Up, new Vector3(0f, 1f, 0f)),

                ConnectionpointUtils.NewConnectionPoint<ConnectorTurboSlot> (Direction.Forward, new Vector3(0f, 0f, 1f)),
            };

            Keyframe[] keyframes =
            {
                new Keyframe(time: 0f, value: 1000f),
                new Keyframe(time: 5785f, value: 4000f),
                new Keyframe(time: 9000f, value: 0f),
            };

            // TorqueFunction torqueFunction = new TorqueFunctionCombustion(5700f, 9000f);
            TorqueFunction torqueFunction = new TorqueFunctionAnimationCurve(new AnimationCurve(keyframes));

            string description = 
                "The most powerful combustion engine ever created, made to break world records.\n" +
                "With its peak power at 5800 rpm and a maximum 9000 rpm, easily beats any other engine on the market";

            Part instance = CustomPartUtils.MakeEngine(
                connections: connections,
                partType: ExtraPartType.PartCombustionEngine.GetPartType(),
                partName: "PW-Inferno 2000",
                tooltipText: "A combustion engine.\n\nAttach an axis to the engine, and connect it through gears with your suspension to make the car drive.",
                mass: 70f,
                health: 70f,
                price: 600,
                motorTopSpeed: 9000,
                torqueFunction: torqueFunction,
                importPartBase: PartType.PartMotorCombustionReal4);

            PartMap map = new PartMap(
                enumName: ExtraPartType.PartCombustionEngine.GetName(),
                instance: instance,
                description: description,
                mappedModel: PartType.PartMotorCombustionReal4,
                mappedSprite: PartType.PartMotorCombustionReal4
            );

            Mapping.AddPart(map);
        }
    }
}

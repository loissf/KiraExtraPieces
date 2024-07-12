using BlacklistNS;
using ImportParts;
using NWH.WheelController3D;
using PartIntroductionNS;
using UnityEngine;
using UnlockConditions;

namespace KiraExtraPieces.Parts
{
    public class PartWeightWheel : Part
    {
        private TorqueFunction _cachedTorqueFunction;

        public override PartCategory PartCategory => PartCategory.MECHANICS;

        public override float SuspensionDistance => 0f;

        public override float SuspensionStiffness => 0f;

        public override bool HasBuildingLimitations => false;

        public override int TierPoints => 3;

        public override TorqueFunction TorqueFunction
        {
            get
            {
                if (_cachedTorqueFunction == null)
                {
                    _cachedTorqueFunction = new TorqueFunctionAnimationCurve(_importPart.torqueFunction);
                }
                return _cachedTorqueFunction;
            }
        }

        public override DLCConfig DLCConfig => _importPart.dlcIncluded;

        public override bool HasSkill => false;

        public override bool IsBarSolidPart => false;

        public override PartType PartType => (PartType)ExtraPartType.PartBolt;

        public override bool GeneratesDownforce => false;

        public override string TooltipText => "Small asphalt tire.\n\nAttach it to a suspension, not directly onto an axis.";

        public override string PartName => "Racing Wheel Small";

        public override float DownforceStrength => 0f;

        public override Vector2 DownforceSurface => new Vector2(0f, 0f);

        public override bool HasProperties => false;

        public override bool IsWheel => true;

        public override bool IsTankTrackWheel => false;

        public override bool IsMotor => false;

        public override bool IsGear => false;

        public override bool ProvidesCustomPartProperties => false;

        public override bool IsGeneralActivatable => false;

        public override int AxeLength => 0;

        public override bool IsAxe => false;

        public override bool IsEngineImprovementGadget => false;

        public override bool IsNitro => false;

        public override float NitroBoostStrength => 0f;

        public override float PartPoolReducedFactor => 0.2f;

        public override float NitroFillAmount => 0f;

        public override float GearTooths => 0f;

        public override float MotorTorque => 0f;

        public override float MotorTopspeed => 0f;

        public override float Mass => 200f;

        public override float Armor => 0f;

        public override float Grip => -0.2f;

        public override float WheelRadius => 2.188f;

        public override bool IsSteerSusp => false;

        public override float Health => 200f;

        public override int TireFrictionPresetIndex => 0;

        public override int Price => 300;

        public override bool IsGearTransmission => false;

        public override bool IsPowertrainPart => true;

        public override int GearTransmissionStatesAmount => 0;

        public override bool IsPropeller => false;

        public override float TierPointsRelative => 0f;

        public override int TierLevelPart => 0;

        public override float PistonMinExpansion => 0f;

        public override float PistonExpansion => 0f;

        public override bool IsPiston => false;

        public override int SoundBuildCustom => 0;

        public override bool IsDestroyedOnDestroy => false;

        public override bool IsSharkFin => false;

        public override SharkFinFlatSideDirection SharkFinFlatSideDirection => SharkFinFlatSideDirection.X_AXIS;

        public override bool IsColorable => true;

        public override bool PartPropertiesForbidWASDKeys => false;

        public override int ColorMaterialIndex => 0;

        public override bool OnlyApplyColor => true;

        public override Vector3 CenterOfMass => new Vector3(0f, 0f, 0f);

        public override bool IsServoMotor => false;

        public override bool HasChildBoxColliders => false;

        public override bool IsRigidbodyHingeDetach => false;

        public override bool IsExhaust => false;

        public override bool IsRotateAnimVanilla => false;

        public override float GearToothsVisual => 0f;

        public override float WheelWidth => 0.3f;

        public override bool IsExcludedFromGame => false;

        public override bool IsSeat => false;

        public override GameObject UnlockMetaInfo => _importPart.unlockMetaInfo;

        public override UnlockablePart UnlockablePart => _importPart.unlockablePart;

        public override BlacklistChallengeConfig[] ChallengesWhereUnlocked => _importPart.challengesWhereUnlocked;

        public override PartIntroduction PartIntroduction => _importPart.partIntroduction;

        public override FrictionPreset FrictionPresetAsphalt => _importPart.frictionPresetAsphalt;

        public override FrictionPreset FrictionPresetSand => _importPart.frictionPresetSand;

        public override Material SkidMaterial => _importPart.skidMaterial;

        public override Material SkidMaterialSand => _importPart.skidMaterialSand;

        public PartWeightWheel()
        {
            _importPart = ImportPart.FindImportPathByPartType("PartWeight100");
        }

        public override Connectionpoint[] GetConnectionpoints(PartDirection direction, PartRotation rotation)
        {
            Connectionpoint[] array = new Connectionpoint[10];
            Vector3Int[] universalDirections = global::PartUtils.GetUniversalDirections(direction, rotation);
            PartDirection pD = PartDirectionHelper.FromVector3Int(universalDirections[1]);
            PartDirection pD2 = PartDirectionHelper.FromVector3Int(universalDirections[2]);
            array[0] = new ConnectorCrossHoleWheel(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[1] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            array[2] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[3] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[4] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * -1f);
            array[5] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * -1f);
            array[6] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * -1f);
            array[7] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * 0f);
            array[8] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * 1f);
            array[9] = new ConnectorSolid(direction, direction.ToVector3() * -1f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            return array;
        }

        public override Connectionpoint[] GetConnectionpointsWithDummyGearOutside(PartDirection direction, PartRotation rotation)
        {
            Connectionpoint[] array = new Connectionpoint[10];
            Vector3Int[] universalDirections = global::PartUtils.GetUniversalDirections(direction, rotation);
            PartDirection pD = PartDirectionHelper.FromVector3Int(universalDirections[1]);
            PartDirection pD2 = PartDirectionHelper.FromVector3Int(universalDirections[2]);
            array[0] = new ConnectorCrossHoleWheel(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[1] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            array[2] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[3] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[4] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * -1f);
            array[5] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * -1f);
            array[6] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * -1f);
            array[7] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * 0f);
            array[8] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * -1f + pD2.ToVector3() * 1f);
            array[9] = new ConnectorSolid(direction, direction.ToVector3() * -1f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            return array;
        }
    }

}
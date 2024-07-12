using BlacklistNS;
using ExtraPieces;
using ExtraPieces.PartMapping;
using ExtraPieces.Utils;
using ImportParts;
using NWH.WheelController3D;
using PartIntroductionNS;
using UnityEngine;
using UnlockConditions;

namespace KiraExtraPieces.Parts
{
    public class PartBolt : Part
    {
        private TorqueFunction _cachedTorqueFunction;

        public override PartCategory PartCategory => PartCategory.CONNECTORS;

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

        public override string TooltipText => "";

        public override string PartName => "Bolt x2";

        public override float DownforceStrength => 0f;

        public override Vector2 DownforceSurface => new Vector2(0f, 0f);

        public override bool HasProperties => false;

        public override bool IsWheel => false;

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

        public override float PartPoolReducedFactor => 1f;

        public override float NitroFillAmount => 0f;

        public override float GearTooths => 0f;

        public override float MotorTorque => 0f;

        public override float MotorTopspeed => 0f;

        public override float Mass => 1f;

        public override float Armor => 0f;

        public override float Grip => 0f;

        public override float WheelRadius => 0f;

        public override bool IsSteerSusp => false;

        public override float Health => 2f;

        public override int TireFrictionPresetIndex => 0;

        public override int Price => 15;

        public override bool IsGearTransmission => false;

        public override bool IsPowertrainPart => false;

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

        public override bool OnlyApplyColor => false;

        public override Vector3 CenterOfMass => new Vector3(0f, 0f, 0f);

        public override bool IsServoMotor => false;

        public override bool HasChildBoxColliders => false;

        public override bool IsRigidbodyHingeDetach => false;

        public override bool IsExhaust => false;

        public override bool IsRotateAnimVanilla => false;

        public override float GearToothsVisual => 0f;

        public override float WheelWidth => 0f;

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

        public PartBolt()
        {
            _importPart = ImportPart.FindImportPathByPartType("PartPinRound2x1");
            this._importPart.partName = this.PartName;
            this._importPart.partType = this.PartType;
            this._importPart.mass = this.Mass;
            this._importPart.health = this.Health;
            this._importPart.price = this.Price;

            // DEBUG
            Plugin.mls.LogInfo("Created instance of part: " + this.PartName);
            Plugin.mls.LogInfo("ImportPart Scriptable Object: " + this._importPart is null ? "NULL" : "LOADED");
            Plugin.mls.LogInfo($" - NAME: {this._importPart.partName}");
            Plugin.mls.LogInfo($" - TYPE: {this._importPart.partType}");
            Plugin.mls.LogInfo($" - MASS: {this._importPart.mass}");
            Plugin.mls.LogInfo($" - HEALTH: {this._importPart.health}");
            Plugin.mls.LogInfo($" - PRICE: {this._importPart.price}");
            Plugin.mls.LogInfo($" - ENUM: {this._importPart.EnumName}");
        }

        public override Connectionpoint[] GetConnectionpoints(PartDirection direction, PartRotation rotation)
        {
            Vector3Int[] universalDirections = global::PartUtils.GetUniversalDirections(direction, rotation);
            PartDirection partDirection = PartDirectionHelper.FromVector3Int(universalDirections[1]);

            Vector3[] pD = new Vector3[]
            {
                direction.ToVector3(),
                PartDirectionHelper.FromVector3Int(universalDirections[1]).ToVector3(),
                PartDirectionHelper.FromVector3Int(universalDirections[2]).ToVector3(),
            };

            Connectionpoint[] array = new Connectionpoint[]
            {
                ConnectionpointUtils.MakeConnectionPoint<ConnectorRoundPin>(partDirection, pD, new Vector3(0f, 0f, 0f)),
                ConnectionpointUtils.MakeConnectionPoint<ConnectorRoundPin>(partDirection, pD, new Vector3(-1f, 0f, 0f)),
            };

            return array;
        }

        public override Connectionpoint[] GetConnectionpointsWithDummyGearOutside(PartDirection direction, PartRotation rotation) => GetConnectionpoints(direction, rotation);
    }

}
using BlacklistNS;
using ImportParts;
using NWH.WheelController3D;
using PartIntroductionNS;
using UnityEngine;
using UnlockConditions;

namespace KiraExtraPieces.Parts
{
    public class PartCombustionEngine : Part
    {
        private TorqueFunction _cachedTorqueFunction;

        public override PartCategory PartCategory => PartCategory.ENGINES;

        public override float SuspensionDistance => 0f;

        public override float SuspensionStiffness => 0f;

        public override bool HasBuildingLimitations => false;

        public override int TierPoints => 16;

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

        public override bool IsBarSolidPart => true;

        public override PartProperty[] PartProperties
        {
            get
            {
                PartProperty[] obj = new PartProperty[2]
                {
                new PartProperty(),
                null
                };
                obj[0].DisplayName = "Key Forward";
                obj[0].PropertyName = "keyforward";
                obj[0].PropertyType = new PropString();
                obj[0].PropertyType.SetFromString("W");
                obj[1] = new PartProperty();
                obj[1].DisplayName = "Key Backwards";
                obj[1].PropertyName = "keybackwards";
                obj[1].PropertyType = new PropString();
                obj[1].PropertyType.SetFromString("S");
                return obj;
            }
        }

        public override PartType PartType => (PartType)ExtraPartType.PartCombustionEngine;

        public override bool GeneratesDownforce => false;

        public override string TooltipText => "A combustion engine.\n\nAttach an axis to the engine, and connect it through gears with your suspension to make the car drive.";

        public override string PartName => "PW-Inferno 2000";

        public override float DownforceStrength => 0f;

        public override Vector2 DownforceSurface => new Vector2(0f, 0f);

        public override bool HasProperties => true;

        public override bool IsWheel => false;

        public override bool IsTankTrackWheel => false;

        public override bool IsMotor => true;

        public override bool IsGear => false;

        public override bool ProvidesCustomPartProperties => true;

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

        public override float MotorTopspeed => 7400f;

        public override float Mass => 70f;

        public override float Armor => 0f;

        public override float Grip => 0f;

        public override float WheelRadius => 0f;

        public override bool IsSteerSusp => false;

        public override float Health => 70f;

        public override int TireFrictionPresetIndex => 0;

        public override int Price => 655;

        public override bool IsGearTransmission => false;

        public override bool IsPowertrainPart => true;

        public override int GearTransmissionStatesAmount => 0;

        public override bool IsPropeller => false;

        public override float TierPointsRelative => 0f;

        public override int TierLevelPart => 0;

        public override float PistonMinExpansion => 0f;

        public override float PistonExpansion => 0f;

        public override bool IsPiston => false;

        public override int SoundBuildCustom => 100;

        public override bool IsDestroyedOnDestroy => false;

        public override bool IsSharkFin => false;

        public override SharkFinFlatSideDirection SharkFinFlatSideDirection => SharkFinFlatSideDirection.X_AXIS;

        public override bool IsColorable => false;

        public override bool PartPropertiesForbidWASDKeys => false;

        public override int ColorMaterialIndex => 0;

        public override bool OnlyApplyColor => false;

        public override Vector3 CenterOfMass => new Vector3(0f, 0f, 0f);

        public override bool IsServoMotor => false;

        public override bool HasChildBoxColliders => false;

        public override bool IsRigidbodyHingeDetach => false;

        public override bool IsExhaust => false;

        public override bool IsRotateAnimVanilla => true;

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

        public PartCombustionEngine()
        {
            this._importPart = ImportPart.FindImportPathByPartType("PartMotorCombustionReal4");
            this._importPart.partName = this.PartName;
            this._importPart.partType = this.PartType;
            this._importPart.mass = this.Mass;
            this._importPart.health = this.Health;
            this._importPart.motorTopspeed = this.MotorTopspeed;
            this._importPart.price = this.Price;

            // DEBUG
            Plugin.mls.LogInfo("Created instance of part: " + this.PartName);
            Plugin.mls.LogInfo("ImportPart Scriptable Object: " + this._importPart is null ? "NULL" : "LOADED");
            Plugin.mls.LogInfo($" - NAME: {this._importPart.partName}");
            Plugin.mls.LogInfo($" - TYPE: {this._importPart.partType}");
            Plugin.mls.LogInfo($" - MASS: {this._importPart.mass}");
            Plugin.mls.LogInfo($" - HEALTH: {this._importPart.health}");
            Plugin.mls.LogInfo($" - SPEED: {this._importPart.motorTopspeed}");
            Plugin.mls.LogInfo($" - PRICE: {this._importPart.price}");
            Plugin.mls.LogInfo($" - ENUM: {this._importPart.EnumName}");
        }

        public override Connectionpoint[] GetConnectionpoints(PartDirection direction, PartRotation rotation)
        {
            Connectionpoint[] array = new Connectionpoint[13];
            Vector3Int[] universalDirections = global::PartUtils.GetUniversalDirections(direction, rotation);
            PartDirection pD = PartDirectionHelper.FromVector3Int(universalDirections[1]);
            PartDirection pD2 = PartDirectionHelper.FromVector3Int(universalDirections[2]);
            array[0] = new ConnectorRoundHole(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[1] = new ConnectorRoundHole(direction, direction.ToVector3() * 0f + pD.ToVector3() * 2f + pD2.ToVector3() * 0f);
            array[2] = new ConnectorRoundHole(direction, direction.ToVector3() * 1f + pD.ToVector3() * 2f + pD2.ToVector3() * 0f);
            array[3] = new ConnectorRoundHole(direction, direction.ToVector3() * 1f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[4] = new ConnectorCrossPower(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * -1f);
            array[5] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[6] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[7] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            array[8] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 2f + pD2.ToVector3() * 1f);
            array[9] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[10] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 2f + pD2.ToVector3() * 1f);
            array[11] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[12] = new ConnectorTurboSlot(pD.Opposite(), direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            return array;
        }

        public override Connectionpoint[] GetConnectionpointsWithDummyGearOutside(PartDirection direction, PartRotation rotation)
        {
            Connectionpoint[] array = new Connectionpoint[13];
            Vector3Int[] universalDirections = global::PartUtils.GetUniversalDirections(direction, rotation);
            PartDirection pD = PartDirectionHelper.FromVector3Int(universalDirections[1]);
            PartDirection pD2 = PartDirectionHelper.FromVector3Int(universalDirections[2]);
            array[0] = new ConnectorRoundHole(direction, direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[1] = new ConnectorRoundHole(direction, direction.ToVector3() * 0f + pD.ToVector3() * 2f + pD2.ToVector3() * 0f);
            array[2] = new ConnectorRoundHole(direction, direction.ToVector3() * 1f + pD.ToVector3() * 2f + pD2.ToVector3() * 0f);
            array[3] = new ConnectorRoundHole(direction, direction.ToVector3() * 1f + pD.ToVector3() * 0f + pD2.ToVector3() * 0f);
            array[4] = new ConnectorCrossPower(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * -1f);
            array[5] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[6] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[7] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            array[8] = new ConnectorSolid(direction, direction.ToVector3() * 1f + pD.ToVector3() * 2f + pD2.ToVector3() * 1f);
            array[9] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 1f);
            array[10] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 2f + pD2.ToVector3() * 1f);
            array[11] = new ConnectorSolid(direction, direction.ToVector3() * 0f + pD.ToVector3() * 1f + pD2.ToVector3() * 0f);
            array[12] = new ConnectorTurboSlot(pD.Opposite(), direction.ToVector3() * 0f + pD.ToVector3() * 0f + pD2.ToVector3() * 1f);
            return array;
        }
    }
}
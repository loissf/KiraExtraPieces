using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KiraExtraPieces.Parts
{
    // Existing PartType values go up to at least 168
    // ExtraPartType value has to be above that
    public enum ExtraPartType
    {
        PartPinRound4x1,
        PartBeam1x4,
        PartBeamCorner1x3,
        PartBolt,
        PartCombustionEngine,
        PartBeam1x6,
        PartBeamT1x4,
    }

    internal static class ExtraPartTypeExtension
    {
        public static string GetName(this ExtraPartType extraPartType) => Enum.GetName(typeof(ExtraPartType), extraPartType);
        public static PartType GetPartType(this ExtraPartType extraPartType) => (PartType)Enum.Parse(typeof(PartType), extraPartType.GetName());
    }
}

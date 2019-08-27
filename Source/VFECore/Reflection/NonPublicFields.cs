﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using Harmony;

namespace VFECore
{

    [StaticConstructorOnStartup]
    public static class NonPublicFields
    {

        public static FieldInfo Pawn_EquipmentTracker_equipment = AccessTools.Field(typeof(Pawn_EquipmentTracker), "equipment");

        public static FieldInfo Pawn_HealthTracker_pawn = AccessTools.Field(typeof(Pawn_HealthTracker), "pawn");

        public static FieldInfo PawnRenderer_pawn = AccessTools.Field(typeof(PawnRenderer), "pawn");

        public static FieldInfo SiegeBlueprintPlacer_center = AccessTools.Field(typeof(SiegeBlueprintPlacer), "center");
        public static FieldInfo SiegeBlueprintPlacer_faction = AccessTools.Field(typeof(SiegeBlueprintPlacer), "faction");
        public static FieldInfo SiegeBlueprintPlacer_NumSandbagRange = AccessTools.Field(typeof(SiegeBlueprintPlacer), "NumSandbagRange");
        public static FieldInfo SiegeBlueprintPlacer_placedSandbagLocs = AccessTools.Field(typeof(SiegeBlueprintPlacer), "placedSandbagLocs");
        public static FieldInfo SiegeBlueprintPlacer_SandbagLengthRange = AccessTools.Field(typeof(SiegeBlueprintPlacer), "SandbagLengthRange");

    }

}

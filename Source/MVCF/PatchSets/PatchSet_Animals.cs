﻿using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using MVCF.Commands;
using MVCF.Utilities;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Sound;

namespace MVCF.PatchSets;

public class PatchSet_Animals : PatchSet
{
    public override IEnumerable<Patch> GetPatches()
    {
        yield return Patch.Postfix(AccessTools.Method(typeof(Pawn), "GetGizmos"),
            AccessTools.Method(GetType(), nameof(Pawn_GetGizmos_Postfix)));
    }

    public static IEnumerable<Gizmo> Pawn_GetGizmos_Postfix(IEnumerable<Gizmo> __result, Pawn __instance)
    {
        foreach (var gizmo in __result) yield return gizmo;

        if (__instance.Faction != Faction.OfPlayer) yield break;
        if (!__instance.RaceProps.Animal) yield break;
        var man = __instance.Manager();
        if (man == null) yield break;
        if (__instance.CurJobDef == JobDefOf.AttackStatic && man.CurrentVerb != null)
            yield return new Command_Action
            {
                defaultLabel = "CommandStopForceAttack".Translate(),
                defaultDesc = "CommandStopForceAttackDesc".Translate(),
                icon = ContentFinder<Texture2D>.Get("UI/Commands/Halt"),
                action = delegate
                {
                    __instance.jobs.EndCurrentJob(JobCondition.InterruptForced);
                    man.CurrentVerb = null;
                    SoundDefOf.Tick_Low.PlayOneShotOnCamera();
                },
                hotKey = KeyBindingDefOf.Misc5
            };
        foreach (var mv in man.ManagedVerbs.Where(mv => !mv.Verb.IsMeleeAttack))
            if (mv.Verb.verbProps.hasStandardCommand)
                foreach (var gizmo in mv.Verb.GetGizmosForVerb(mv))
                    yield return gizmo;
            else
                yield return new Command_ToggleVerbUsage(mv);
    }
}

using Content.Shared.CCVar;
using Robust.Shared.Configuration;

namespace Content.Server.Atmos.EntitySystems
{
    public sealed partial class AtmosphereSystem
    {
        [Dependency] private readonly IConfigurationManager _cfg = default!;

        public bool SpaceWind { get; private set; }
        public float SpaceWindMaxForce { get; private set; }
        public float SpaceWindMaxAngularVelocity { get; private set; }
        public float SpaceWindStrengthMultiplier { get; private set; }
        public float SpaceWindKnockdownTime { get; private set; }
        public bool MonstermosEqualization { get; private set; }
        public bool MonstermosDepressurization { get; private set; }
        public bool MonstermosRipTiles { get; private set; }
        public float MonstermosRipTilesMinimumPressure { get; private set; }
        public bool GridImpulse { get; private set; }
        public float SpacingMinGas { get; private set; }
        public float SpacingMaxWind { get; private set; }
        public bool Superconduction { get; private set; }
        public bool ExcitedGroups { get; private set; }
        public bool ExcitedGroupsSpaceIsAllConsuming { get; private set; }
        public float AtmosMaxProcessTime { get; private set; }
        public float AtmosTickRate { get; private set; }
        public float Speedup { get; private set; }
        public float HeatScale { get; private set; }
        public float HumanoidThrowMultiplier { get; private set; }
        public bool SpaceWindAllowKnockdown { get; private set; }
        public bool SpaceWindVisuals { get; private set; }

        /// <summary>
        /// Time between each atmos sub-update.  If you are writing an atmos device, use AtmosDeviceUpdateEvent.dt
        /// instead of this value, because atmos devices do not update each are sub-update and sometimes are skipped to
        /// meet the tick deadline.
        /// </summary>
        public float AtmosTime => 1f / AtmosTickRate;

        private void InitializeCVars()
        {
            Subs.CVar(_cfg, CCVars.SpaceWind, value => SpaceWind = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindMaxForce, value => SpaceWindMaxForce = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindMaxAngularVelocity, value => SpaceWindMaxAngularVelocity = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindStrengthMultiplier, value => SpaceWindStrengthMultiplier = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindKnockdownTime, value => SpaceWindKnockdownTime = value, true);
            Subs.CVar(_cfg, CCVars.MonstermosEqualization, value => MonstermosEqualization = value, true);
            Subs.CVar(_cfg, CCVars.MonstermosDepressurization, value => MonstermosDepressurization = value, true);
            Subs.CVar(_cfg, CCVars.MonstermosRipTiles, value => MonstermosRipTiles = value, true);
            Subs.CVar(_cfg, CCVars.MonstermosRipTilesMinimumPressure, value => MonstermosRipTilesMinimumPressure = value, true);
            Subs.CVar(_cfg, CCVars.AtmosGridImpulse, value => GridImpulse = value, true);
            Subs.CVar(_cfg, CCVars.AtmosSpacingMinGas, value => SpacingMinGas = value, true);
            Subs.CVar(_cfg, CCVars.AtmosSpacingMaxWind, value => SpacingMaxWind = value, true);
            Subs.CVar(_cfg, CCVars.Superconduction, value => Superconduction = value, true);
            Subs.CVar(_cfg, CCVars.AtmosMaxProcessTime, value => AtmosMaxProcessTime = value, true);
            Subs.CVar(_cfg, CCVars.AtmosTickRate, value => AtmosTickRate = value, true);
            Subs.CVar(_cfg, CCVars.AtmosSpeedup, value => Speedup = value, true);
            Subs.CVar(_cfg, CCVars.AtmosHeatScale, value => { HeatScale = value; InitializeGases(); }, true);
            Subs.CVar(_cfg, CCVars.ExcitedGroups, value => ExcitedGroups = value, true);
            Subs.CVar(_cfg, CCVars.ExcitedGroupsSpaceIsAllConsuming, value => ExcitedGroupsSpaceIsAllConsuming = value, true);
            Subs.CVar(_cfg, CCVars.AtmosHumanoidThrowMultiplier, value => HumanoidThrowMultiplier = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindAllowKnockdown, value => SpaceWindAllowKnockdown = value, true);
            Subs.CVar(_cfg, CCVars.SpaceWindVisuals, value => SpaceWindVisuals = value, true);
        }
    }
}

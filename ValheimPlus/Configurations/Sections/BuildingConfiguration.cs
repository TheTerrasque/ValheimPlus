namespace ValheimPlus.Configurations.Sections
{
    public class BuildingConfiguration : ServerSyncConfig<BuildingConfiguration>
    {
        [ConfigDescription("No Invalid Placement Restriction", "Removes the \"Invalid Placement\" restriction")]
        public bool NoInvalidPlacementRestriction { get; set; } = false;
        [ConfigDescription("No Weather Damage", "Removes weather/rain damage on building objects")]
        public bool NoWeatherDamage { get; set; } = false;

        [ConfigDescription("Maximum Placement Distance", "The maximum distance you can place objects")]
        public float MaximumPlacementDistance { get; internal set; } = 5;
        [ConfigDescription("Disable Structural Integrity", "removes all structual integrity checks. Allows placement in free air.")]
        public bool DisableStructualIntegrity { get; set; } = false;
    }

}

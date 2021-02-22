namespace ValheimPlus.Configurations.Sections
{
    public class BeehiveConfiguration : ServerSyncConfig<BeehiveConfiguration>
    {
        [ConfigDescription("Honey production speed", "default is 1200, which is 24 ingame hours. lower is faster")]
        public float HoneyProductionSpeed { get; set; } = 10;
        [ConfigDescription("Maximum Honey Per Beehive", "How much honey a beehive can store before it's full")]
        public int MaximumHoneyPerBeehive { get; set; } = 4;
    }

}
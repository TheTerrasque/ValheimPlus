namespace ValheimPlus.Configurations.Sections
{
    public class FermenterConfiguration : ServerSyncConfig<FermenterConfiguration>
    {
        [ConfigDescription("Fermenter Duration", "default is 2400 (float) (48 ingame hours), lower is faster")]
        public float FermenterDuration { get; set; } = 2400;
        [ConfigDescription("Items produced", "Items produced in the fermenter")]
        public int FermenterItemsProduced { get; set; } = 4;
    }

}

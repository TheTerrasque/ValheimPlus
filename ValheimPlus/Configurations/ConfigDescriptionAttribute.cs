namespace ValheimPlus.Configurations
{
    public class ConfigDescriptionAttribute : System.Attribute
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public ConfigDescriptionAttribute(string name, string description)
        {
            this.Description = description;
            this.Name = name;
        }
    }
}
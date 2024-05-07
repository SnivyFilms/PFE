using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PFE
{
    public class Config : IConfig
    {
        [Description("Is the plugin Enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enable/Disable debug printouts")]
        public bool Debug { get; set; } = false;

        [Description("Fuse time for the grenade before it explodes after SCP 173 dies")]
        public float FuseTime { get; set; } = 0.5f;

        [Description("Magnitude of explosions (number of explosions that will occur. The higher the number the lower the frame rate.)")]
        public int Magnitude { get; set; } = 1;

        [Description("Determine the friendly fire multiplier for SCPs, 0 = no damage, 1 = normal grenade damage multipler, 2 = 2 times normal grenade multipler")]
        public float ScpFriendlyFireDamage { get; set; } = 0;
    }
}

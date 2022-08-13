using Exiled.API.Interfaces;
using System.ComponentModel;

namespace WalnutFuckingExplodes
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin Enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Fuse time for the grenade before it explodes after SCP 173 dies")]
        public float FuseTime { get; set; } = 0.5f;

        [Description("Magnitude of explosions (number of explosions that will occur. The higher the number the lower the frame rate.)")]
        public int Magnitude { get; set; } = 1;
    }
}

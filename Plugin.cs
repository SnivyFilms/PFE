using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace WalnutFuckingExplodes
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name { get; } = "Walnut Fucking Explodes (PFE Remake)";
        public override string Author { get; } = "XoMiya-WPC";
        public override string Prefix { get; } = "WalnutFuckingExplodes";
        public override Version Version { get; } = new Version("1.0.0");
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        private EventHandlers eventHandlers;
        public override void OnEnabled()
        {

            Instance = this;
            eventHandlers = new EventHandlers(this);
            Player.Died += eventHandlers.OnPlayerDeath;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            Player.Died -= eventHandlers.OnPlayerDeath;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}

using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace PFE
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name { get; } = "Peanut Fucking Explodes";
        public override string Author { get; } = "Vicious Vikki";
        public override string Prefix { get; } = "Peanut Fucking Explodes";
        public override Version Version { get; } = new Version(1, 1, 2);
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 1);

        private EventHandlers eventHandlers;
        public override void OnEnabled()
        {
            Instance = this;
            Log.Debug("PFE: Initalizing Instance");
            eventHandlers = new EventHandlers(this);
            Log.Debug("PFE: Initalizing Event Handlers");
            Player.Dying += eventHandlers.OnPlayerDying;
            Player.Died += eventHandlers.OnPlayerDeath;
            Log.Debug("PFE: Enabling Plugin");
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            Log.Debug("PFE: Clearing Instance");
            Player.Dying -= eventHandlers.OnPlayerDying;
            Player.Died -= eventHandlers.OnPlayerDeath;
            Log.Debug("PFE: Clearing Event Handlers");
            eventHandlers = null;
            Log.Debug("PFE: Disabling Plugin");
            base.OnDisabled();
        }
    }
}

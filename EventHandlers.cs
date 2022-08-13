using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace WalnutFuckingExplodes
{
    class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnPlayerDeath(DiedEventArgs ev)
        {
            if (ev.TargetOldRole != RoleType.Scp173)
            {
                return;
            }
            for (int i = 0; i < Plugin.Instance.Config.Magnitude; i++)
            {
                ev.Target.Position += Vector3.up;
                ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                grenade.FuseTime = plugin.Config.FuseTime;
                grenade.SpawnActive(ev.Target.Position, ev.Target);
            }
        }
    }
}

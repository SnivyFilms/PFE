using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

namespace PFE
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public Vector3 PeanutDeathLocation;

        public void OnPlayerDying(DyingEventArgs ev)
        {
            Log.Debug("PFE: Checking if dying player is SCP-173 for on Dying Event");
            if (ev.Player.Role != RoleTypeId.Scp173)
            {
                Log.Debug("PFE: Player isn't SCP-173 on Dying Event");
                return;
            }
            Log.Debug("PFE: Player is SCP-173 on Dying Event");
            PeanutDeathLocation = ev.Player.Position;
        }

        public void OnPlayerDeath(DiedEventArgs ev)
        {
            Log.Debug("PFE: Checking if the dead player was SCP-173 (again) for on Died Event");
            if (ev.TargetOldRole == RoleTypeId.Scp173)
            {
                Log.Debug("PFE: Getting the amount of grenades specified in the magnitude config");
                for (int i = 0; i < plugin.Config.Magnitude; i++)
                {
                    Log.Debug("PFE: Spawning " + plugin.Config.Magnitude + " Grenades");
                    ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                    Log.Debug("PFE: Setting fuse time of " + plugin.Config.FuseTime);
                    grenade.FuseTime = plugin.Config.FuseTime;
                    Log.Debug("PFE: Setting the SCP Damage Multipler (friendly fire) to " + plugin.Config.ScpFriendlyFireDamage);
                    grenade.ScpDamageMultiplier = plugin.Config.ScpFriendlyFireDamage * 3;
                    Log.Debug("PFE: Spawning " + plugin.Config.Magnitude + " Grenades at " + PeanutDeathLocation);
                    grenade.SpawnActive(PeanutDeathLocation);
                }
            }
        }

    }
}

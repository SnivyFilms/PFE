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
            Log.Debug("EFE: Checking the dying player");
            /*if (ev.Player.Role != RoleTypeId.Scp173)
            {
                Log.Debug("PFE: Player isn't SCP-173 on Dying Event");
                return;
            }*/
            Log.Debug("EFE: Player is dying");
            PeanutDeathLocation = ev.Player.Position;
        }

        public void OnPlayerDeath(DiedEventArgs ev)
        {
            Log.Debug("EFE: Checking the dead player again");
            /*if (ev.TargetOldRole == RoleTypeId.Scp173)
            {*/
                Log.Debug("EFE: Getting the amount of grenades specified in the managtude config");
                for (int i = 0; i < plugin.Config.Magnitude; i++)
                {
                    Log.Debug("EFE: Spawning " + plugin.Config.Magnitude + " Grenades");
                    ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                    Log.Debug("EFE: Setting fuse time of " + plugin.Config.FuseTime);
                    grenade.FuseTime = plugin.Config.FuseTime;
                    Log.Debug("EFE: Setting the SCP Damage Multipler (friendly fire) to " + plugin.Config.SCPFriendlyFireDamage);
                    grenade.ScpDamageMultiplier = plugin.Config.SCPFriendlyFireDamage * 3;
                    Log.Debug("EFE: Spawning " + plugin.Config.Magnitude + " Grenades at " + PeanutDeathLocation);
                    grenade.SpawnActive(PeanutDeathLocation);
                }
            //}
        }

    }
}

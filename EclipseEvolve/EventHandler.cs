namespace EclipseEvolve
{
    using System;
    using Exiled;
    using Exiled.API.Features;
    using Exiled.Events;
    using Exiled.Events.EventArgs.Player;
    using Exiled.API.Enums;
    using PlayerRoles;
    using UnityEngine;
    using Exiled.Events.Commands.PluginManager;
    using Exiled.Events.EventArgs.Scp096;
    using System.Collections.Generic;

    public class EventHandler
    {
        public Config Config { get; private set; }
        private readonly Dictionary<Player, int> playerKills = new Dictionary<Player, int>();

        // WelcomeMessage Metod 
        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            // Check if it is enabled
            if (Config.ModuleWelcomeMessage)
            Log.Debug("ModuleWelcomeMessage Enabled");
            {
                ev.Player.Broadcast(duration:10 ,Config.WelcomeMessage);
            }
        }
        // AntiTrollingTeam Metod
        public void OnActivatingGenerator(ActivatingGeneratorEventArgs ev)
        {
            // Check if it is enabled
            if (Config.ModuleAntiTrollingTeam)
            Log.Debug("AntiTrollingTeam Enabled");
            {
                if(ev.Player.IsScp)
                {
                    ev.IsAllowed = false;
                    ev.Player.ShowHint("<color=red>Don't try to harm your teammates</color>", duration:5);
                }
            }
        }
        // AntiTrollingTeam Metod
        public void OnOpeningGenerator(OpeningGeneratorEventArgs ev)
        {
            // Check if it is enabled
            if (Config.ModuleAntiTrollingTeam)
            Log.Debug("AntiTrollingTeam Enabled");
            {
                if (ev.Player.IsScp)
                {
                    ev.IsAllowed = false;
                    ev.Player.ShowHint("<color=red>Don't try to harm your teammates</color>", duration:5);
                }
            }
     
        }
        // UsefulHint
        public void OnActivatingWarhead(ActivatingWarheadPanelEventArgs ev)
        {
            // Check if it is enabled
            if (Config.ModuleUsefulHint)
            Log.Debug("UsefulHint Enabled");
            {
                // Check if the player belongs to Chaos Insurgency team
                if (ev.Player.Role.Team == Team.ChaosInsurgency)
                {
                    ev.IsAllowed = true;
                    ev.Player.ShowHint("<color=green>You're making it, keep it up  :)</color>", duration:5);
                }
                // Check if the player is Class-D
                else if (ev.Player.Role.Type == RoleTypeId.ClassD)
                {
                    ev.IsAllowed = true;
                    ev.Player.ShowHint("<color=green>You're making it, keep it up  :)</color>", duration:5);
                }
                else if (ev.Player.Role.Team == Team.FoundationForces)
                {
                    ev.IsAllowed = true;
                    ev.Player.ShowHint("<color=red>That is not your purpose, You should save it  :(</color>", duration:5);
                }
            }
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            ev.Target.ShowHint("<b><color=red> YOU SEE 096 ... RUN </color></b>");
        }
        // Thanks @Vretu-Dev for CounterKill
        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Attacker != null)
            {
                Player killer = ev.Attacker;

                if (playerKills.ContainsKey(killer))
                {
                    playerKills[killer]++;
                }
                else
                {
                    playerKills[killer] = 1;
                }
                killer.ShowHint(string.Format("<b><color=red>You have {0} kills</color></b>", playerKills[killer]), 5);
            }
        }
    }  
}

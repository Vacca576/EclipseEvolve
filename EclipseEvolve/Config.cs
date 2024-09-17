namespace EclipseEvolve
{
    using Exiled.API.Interfaces;
    using System;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Plugin Enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug Enabled?.")]
        public bool Debug { get; set; } = false;

        [Description("WelcomeMessage is Enabled?.")]
        public bool ModuleWelcomeMessage { get; set; } = true;

        [Description("If Module WelcomeMessage is Enabled, What Is Message?.")]
        public string WelcomeMessage { get; set; } = "Benvenuto %Player% su <color=orange>Eclipse</color>";

        [Description("AntiTrollingTeam (ActivatingGenerator for SCP-079) is Enabled?")]
        public bool ModuleAntiTrollingTeam { get; set; } = true;

        [Description("UsefulHint is Enabled?")]
        public bool ModuleUsefulHint { get; set; } = true;




    }
}
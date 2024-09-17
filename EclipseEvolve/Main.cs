namespace EclipseEvolve
{
    using System;
    using Exiled;
    using Exiled.API.Features;
    using Exiled.Events;
    using Player = Exiled.Events.Handlers.Player;
    using Server = Exiled.Events.Handlers.Server;
    using Handler = Exiled.Events.Handlers;

    public class Main : Plugin<Config>
    {
        private EventHandler EventHandler;
        public override string Author => "Vacca";
        public override string Name => "EclipseEvolve";
        public override string Prefix => "EclipseEvolve";
        public override Version RequiredExiledVersion => new Version(8,9,11);
        public override Version Version => new Version(1,0,3);

        // Registering Event OnEnabled
        public override void OnEnabled()
        {
            EventHandler = new EventHandler();
            Player.Verified += EventHandler.OnPlayerVerified;
            Player.ActivatingGenerator += EventHandler.OnActivatingGenerator;
            Player.OpeningGenerator += EventHandler.OnOpeningGenerator;
            Player.ActivatingWarheadPanel += EventHandler.OnActivatingWarhead;
            Player.Died += EventHandler.OnDied;
            Handler.Scp096.AddingTarget += EventHandler.OnAddingTarget;
            base.OnEnabled();
        }
        // Registering Event OnDisabled
        public override void OnDisabled()
        {
            EventHandler = new EventHandler();
            Player.ActivatingGenerator -= EventHandler.OnActivatingGenerator;
            Player.OpeningGenerator -= EventHandler.OnOpeningGenerator;
            Player.Verified -= EventHandler.OnPlayerVerified;
            Player.ActivatingWarheadPanel -= EventHandler.OnActivatingWarhead;
            Player.Died -= EventHandler.OnDied;
            Handler.Scp096.AddingTarget -= EventHandler.OnAddingTarget;
            base.OnDisabled();
        }
    }
}

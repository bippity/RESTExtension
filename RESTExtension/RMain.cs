using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI.Extensions;
using TShockAPI;
using Rests;
using HttpServer;
using TShockAPI.Hooks;
using System.IO;
using Terraria;
using TerrariaApi.Server;
using System.Reflection;
using Extensions;

namespace RESTExtension
{
    [ApiVersion(1, 15)]
    public class RMain : TerrariaPlugin
    {
        public static bool usingservername = false;
        public static string tsservername = "";

        public override string Author
        { get { return "White"; } }

        public override string Description
        { get { return "REST Extension"; } }

        public override string Name
        { get { return "REST++"; } }

        public override Version Version
        { get { return Assembly.GetExecutingAssembly().GetName().Version; } }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInit); 
            }
                
            base.Dispose(disposing);
        }

        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInit);
        }

        public RMain(Main game)
            : base(game)
        {
            Order = 1;
        }

        public void OnInit(EventArgs args)
        {
            TShock.RestApi.Register(new RestCommand("/ext/tshock/info", TI.TShockInfo));
            TShock.RestApi.Register(new RestCommand("/ext/world/info", WI.WorldInfo));
        }
    }
}
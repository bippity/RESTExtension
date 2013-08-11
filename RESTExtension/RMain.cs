using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI.Extensions;
using TShockAPI;
using Rests;
using HttpServer;
using Hooks;
using System.IO;
using Terraria;
using System.Reflection;

namespace RESTExtension
{
    [APIVersion(1, 13)]
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
                GameHooks.Initialize -= OnInit;
            base.Dispose(disposing);
        }

        public override void Initialize()
        {
            GameHooks.Initialize += OnInit;
        }

        public RMain(Main game)
            : base(game)
        {
            Order = 1;
        }

        public void OnInit()
        {
            TShock.RestApi.Register(new RestCommand("/tshock/info", TI.TShockInfo));
            TShock.RestApi.Register(new RestCommand("/world/info", WI.WorldInfo));
        }
    }
}
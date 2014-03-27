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
using System.Reflection;
using RESTExtension;

namespace Extensions
{
    public class WI
    {
        public static object WorldInfo(RestVerbs verbs, IParameterCollection parameters)
        {
            if (TShock.Config.UseServerName == true)
            {
                RMain.usingservername = true;
                RMain.tsservername = TShock.Config.ServerName;
            }
            else
            {
                RMain.usingservername = false;
                RMain.tsservername = Main.worldName;
            }

            List<string> Defeated = new List<string>();
            if (NPC.downedBoss1)
            {
                Defeated.Add("cthulhu:1");
                if (Defeated.Contains("cthulhu:0"))
                    Defeated.Remove("cthulhu:0");
            }
            else
                Defeated.Add("cthulu:0");

            if (NPC.downedBoss2)
            {
                Defeated.Add("eater:1");
                if (Defeated.Contains("eater:0"))
                    Defeated.Remove("eater:0");
            }
            else
                Defeated.Add("eater:0");

            if (NPC.downedBoss3)
            {
                Defeated.Add("skeletron:1");
                if (Defeated.Contains("skeletron:0"))
                    Defeated.Remove("skeletron:0");
            }
            else
                Defeated.Add("skeletron:0");

            if (NPC.downedQueenBee)
            {
                Defeated.Add("bee:1");
                if (Defeated.Contains("bee:0"))
                    Defeated.Remove("bee:0");
            }
            else
                Defeated.Add("bee:0");

            if (NPC.downedGoblins)
            {
                Defeated.Add("goblins:1");
                if (Defeated.Contains("goblins:0"))
                    Defeated.Remove("goblins:0");
            }
            else
                Defeated.Add("goblins:0");

            if (NPC.downedFrost)
            {
                Defeated.Add("frost:1");
                if (Defeated.Contains("frost:0"))
                    Defeated.Remove("frost:0");
            }
            else
                Defeated.Add("frost:0");

            if (NPC.downedPirates)
            {
                Defeated.Add("pirates:1");
                if (Defeated.Contains("pirates:0"))
                    Defeated.Remove("pirates:0");
            }
            else
                Defeated.Add("pirates:0");

            if (NPC.downedClown)
            {
                Defeated.Add("clown:1");
                if (Defeated.Contains("clown:0"))
                    Defeated.Remove("clown:0");
            }
            else
                Defeated.Add("clown:0");

            if (NPC.downedPlantBoss)
            {
                Defeated.Add("plantera:1");
                if (Defeated.Contains("plantera:0"))
                    Defeated.Remove("plantera:0");
            }
            else
                Defeated.Add("plantera:0");

            if (NPC.downedGolemBoss)
            {
                Defeated.Add("golem:1");
                if (Defeated.Contains("golem:0"))
                    Defeated.Remove("golem:0");
            }
            else
                Defeated.Add("golem:0");

             if (NPC.downedMechBoss1)
            {
                Defeated.Add("destroyer:1");
                    if (Defeated.Contains("destroyer:0"))
                        Defeated.Remove("destroyer:0");
            }
            else
                Defeated.Add("destroyer:0");

             if (NPC.downedMechBoss2)
            {
                Defeated.Add("skeletronprime:1");
                if (Defeated.Contains("skeletronprime:0"))
                    Defeated.Remove("skeletronprime:0");
            }
            else
                Defeated.Add("skeletronprime:0");

             if (NPC.downedMechBoss3)
            {
                Defeated.Add("twins:1");
                if (Defeated.Contains("twins:0"))
                    Defeated.Remove("twins:0");
            }
            else
                Defeated.Add("twins:0");

            string defeated = string.Join(", ", Defeated);

            List<string> Found = new List<string>();
            if (NPC.savedGoblin)
            {
                Found.Add("savedgoblin:1");
                if (Found.Contains("savedgoblin:0"))
                    Found.Remove("savedgoblin:0");
            }
            else
                Found.Add("savedgoblin:0");

            if (NPC.savedWizard)
            {
                Found.Add("savedwizard:1");
                if (Found.Contains("savedwizard:0"))
                    Found.Remove("savedwizard:0");
            }
            else
                Found.Add("savedwizard:0");

            if (NPC.savedMech)
            {
                Found.Add("savedmech:1");
                if (Found.Contains("savedmech:0"))
                    Found.Remove("savedmech:0");
            }
            else
                Found.Add("savedmech:0");

            if (NPC.savedStylist)
            {
                Found.Add("savedstylist:1");
                if (Found.Contains("savedstylist:0"))
                    Found.Remove("savedstylist:0");
            }
            else
                Found.Add("savedstylist:0");

            string found = string.Join(", ", Found);
 

            List<string> Mobs = new List<string>();
            for (int i = 0; i < Main.maxNPCTypes; i++)
            {
                if (Main.npc[i].active)
                {
                    if (!Main.npc[i].townNPC)
                    {
                        var npc = Main.npc[i];
                        Mobs.Add(npc.name);
                    }
                }
            }
            string mobs = string.Join(", ", Mobs);

            List<string> NPCs = new List<string>();

            for (int i = 0; i < Main.maxNPCTypes; i++)
            {
                if (Main.npc[i].townNPC)
                {
                    if (Main.npc[i].active)
                    {
                        var npc = Main.npc[i];
                        NPCs.Add(npc.name);
                    }
                }
            }

            string npcs = string.Join(", ", NPCs);

            double time = Main.time;
            if (!Main.dayTime)
            {
                time += 54000.0;
            }
            time = time / 86400.0 * 24;
            double num2 = 7.5;
            time = time - num2 - 12.0;
            if (time < 0.0)
            {
                time += 24.0;
            }
            int num3 = (int)time;
            double num4 = time - (double)num3;
            num4 = (double)((int)(num4 * 60.0));
            string text4 = string.Concat(num4);
            if (num4 < 10.0)
                text4 = "0" + text4;
            if (num3 > 24)
                num3 -= 12;
            string displaytime = string.Format("{0}:{1}", num3, text4);


            return new RestObject()
            {
                {"worldname", Main.worldName},
                {"tshockname", RMain.tsservername},
				{"size", Main.maxTilesX + "*" + Main.maxTilesY},
				{"time", displaytime},
				{"daytime", Main.dayTime},
				{"bloodmoon", Main.bloodMoon},
				{"invasionsize", Main.invasionSize},
                {"defeated", defeated},
                {"npcs", npcs},
                {"mobs", mobs}
            };
        }
    }
}
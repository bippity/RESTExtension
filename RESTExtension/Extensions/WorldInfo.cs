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
                RMain.tsservername = TShock.Config.ServerNickname;
            }

            List<string> Defeated = new List<string>();
            if (NPC.downedBoss1)
            {
                Defeated.Add("cthulu:1");
                {
                    if (Defeated.Contains("cthulu:0"))
                    {
                        Defeated.Remove("cthulu:0");
                    }
                }
            }
            else
                Defeated.Add("cthulu:0");

            if (NPC.downedBoss2)
            {
                Defeated.Add("eater:1");
                if (Defeated.Contains("eater:0"))
                {
                    Defeated.Remove("eater:0");
                }
            }
            else
                Defeated.Add("eater:0");

            if (NPC.downedBoss3)
            {
                Defeated.Add("skeletron:1");
                if (Defeated.Contains("skeletron:0"))
                {
                    Defeated.Remove("skeletron:0");
                }
            }
            else
                Defeated.Add("skeletron:0");

            if (NPC.downedGoblins)
            {
                Defeated.Add("goblins:1");
                {
                    if (Defeated.Contains("goblins:0"))
                        Defeated.Remove("goblins:0");
                }
            }
            else
                Defeated.Add("goblins:0");
            if (NPC.downedFrost)
            {
                Defeated.Add("frost:1");
                {
                    if (Defeated.Contains("frost:0"))
                        Defeated.Remove("frost:0");
                }
            }
            else
                Defeated.Add("frost:0");
            if (NPC.downedClown)
            {
                Defeated.Add("clown:1");
                {
                    if (Defeated.Contains("clown:0"))
                        Defeated.Remove("clown:0");
                }
            }
            else
                Defeated.Add("clown:0");

            string defeated = "";

            foreach (string s in Defeated)
            {
                if (defeated.Length == 0)
                {
                    defeated += s;
                }
                else if (defeated.Length > 0)
                {
                    defeated += ", " + s;
                }
            }

            List<string> Mobs = new List<string>();
            string mobs = "";
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

            foreach (string s in Mobs)
            {
                if (mobs.Length == 0)
                {
                    mobs += s;
                }
                else if (mobs.Length > 0)
                {
                    mobs += ", " + s;
                }
            }

            List<string> NPCs = new List<string>();
            string npcs = "";


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

            foreach (string s in NPCs)
            {
                if (npcs.Length == 0)
                {
                    npcs += s;
                }
                else if (npcs.Length > 0)
                {
                    npcs += ", " + s;
                }
            }

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
            {
                text4 = "0" + text4;
            }
            if (num3 > 24)
            {
                num3 -= 12;
            }
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
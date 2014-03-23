using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI.Extensions;
using TShockAPI;
using Rests;
using HttpServer;
//using Hooks;
using TShockAPI.Hooks;
using System.IO;
using Terraria;
using System.Reflection;
using RESTExtension;

namespace Extensions
{
    public class TI
    {
        public static object TShockInfo(RestVerbs verbs, IParameterCollection parameters)
        {
            string thresholds = string.Format("tilekill: {0}, tileplace: {1}, liquidset: {2}, projectile: {3}", TShock.Config.TileKillThreshold, TShock.Config.TilePlaceThreshold, TShock.Config.TileLiquidThreshold, TShock.Config.ProjectileThreshold);

            string superadmin = string.Format("prefix: {0} suffix: {1} RGB: {2} {3} {4}", TShock.Config.SuperAdminChatPrefix, TShock.Config.SuperAdminChatSuffix, TShock.Config.SuperAdminChatRGB[0], TShock.Config.SuperAdminChatRGB[1], TShock.Config.SuperAdminChatRGB[2]);

            return new RestObject()
            {
                {"servername", TShock.Config.ServerName},
                //{"servernickname", TShock.Config.ServerNickname},//doesn't exist?
                {"password", TShock.Config.ServerPassword},
                {"port", TShock.Config.ServerPort},
                {"maxslots", TShock.Config.MaxSlots},
                {"superadmininfo", superadmin},
                {"storagetype", TShock.Config.StorageType},
                {"thresholds", thresholds},
                {"maxspawns", TShock.Config.DefaultMaximumSpawns},
                {"spawnrate", TShock.Config.DefaultSpawnRate},
                {"chatoverhead", TShock.Config.EnableChatAboveHeads},
               // {"ssi", TShock.Config.ServerSideInventory},
                {"ssc", TShock.Config.ServerSideCharacterSave},
                {"protectedbuild", TShock.Config.DisableBuild},
                {"christmas", TShock.Config.ForceXmas}
            };
        }
    }
}

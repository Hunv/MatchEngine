using MatchEngine.DatabaseModel;
using MatchLibrary;
using MatchLibrary.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public static class ApiSetting
    {
        /// <summary>
        /// Get a Setting
        /// </summary>
        public static string GetSetting(string setting)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Settings.SingleOrDefault(x => x.Name == setting);

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        /// <summary>
        /// Get a clubs
        /// </summary>
        public static async Task SetSetting(string setting, string value)
        {
            using (var dbContext = new MyDbContext())
            {
                var tm = dbContext.Settings.SingleOrDefault(x => x.Name == setting);
                if (tm != null)
                {
                    tm.Value = value;

                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

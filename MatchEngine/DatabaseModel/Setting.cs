using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Setting
    {
        /// <summary>
        /// The name of the setting
        /// </summary>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// The value of the setting
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}

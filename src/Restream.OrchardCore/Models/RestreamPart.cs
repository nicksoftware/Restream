using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using OrchardCore.ContentManagement;

namespace Restream.OrchardCore.Models
{
    public class RestreamPart : ContentPart
    {

        public string TokenKey { get; set; }

        /// <summary>
        /// Video Frame width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Video Frame Height
        /// </summary>
        public int Height { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restream.OrchardCore.Settings
{
    public class RestreamPartSettings
    {
        //Widget Token
        public string Token { get; set; }

        public bool UseSettingsToken { get; set; } = true;
    }
}

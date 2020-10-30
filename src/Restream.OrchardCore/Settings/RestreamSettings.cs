using System;
using System.Collections.Generic;
using System.Text;

namespace Restream.OrchardCore.Settings
{
    public class RestreamSettings
    {
        public string TokenKey { get; set; }
        public string RestreamPlayerUrl { get; set; } = Constants.RestreamPlayerUrl;
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(TokenKey);
        }
    }
}

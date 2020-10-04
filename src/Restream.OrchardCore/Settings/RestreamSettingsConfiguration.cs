using Microsoft.Extensions.Options;
using OrchardCore.Settings;
using OrchardCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restream.OrchardCore.Configuration
{
    public class RestreamSettingsConfiguration : IConfigureOptions<RestreamSettings>
    {
        private readonly ISiteService _site;

        public RestreamSettingsConfiguration(ISiteService site)
        {
            _site = site;
        }

        public void Configure(RestreamSettings options)
        {
            var settings = _site.GetSiteSettingsAsync()
                .GetAwaiter().GetResult()
                .As<RestreamSettings>();

            options.TokenKey = settings.TokenKey;
        }
    }
}

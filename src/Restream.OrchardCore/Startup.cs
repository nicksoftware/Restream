using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using Restream.OrchardCore.Settings;
using Restream.OrchardCore.Models;
using Restream.OrchardCore.Drivers;
using Fluid;
using Restream.OrchardCore.Configuration;
using Microsoft.Extensions.Options;
using OrchardCore.Settings;
using OrchardCore.DisplayManagement.Handlers;

namespace Restream.OrchardCore
{
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<RestreamPart>();

        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<RestreamSettings>, RestreamSettingsConfiguration>();
            services.AddScoped<IDisplayDriver<ISite>, RestreamSettingsDisplayDriver>();
            services.AddContentPart<RestreamPart>()
                    .UseDisplayDriver<RestreamPartDisplayDriver>();
            services.AddScoped<INavigationProvider, AdminMenu>();
            services.AddScoped<IContentTypePartDefinitionDisplayDriver, RestreamPartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

        }
    }
}
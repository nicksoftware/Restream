
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;


namespace Restream.OrchardCore
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("RestreamPart", builder => builder
                .WithDescription("Provides Restream Video Streaming  properties.").Reusable());

            _contentDefinitionManager.AlterTypeDefinition("Restream", type => type
            .WithPart("RestreamPart")
            .Stereotype("Widget").Draftable().Securable().Build());


            return 1;
        }
    }
}

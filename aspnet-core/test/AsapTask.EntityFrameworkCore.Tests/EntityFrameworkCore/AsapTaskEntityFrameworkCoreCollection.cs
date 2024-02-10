using Xunit;

namespace AsapTask.EntityFrameworkCore;

[CollectionDefinition(AsapTaskTestConsts.CollectionDefinitionName)]
public class AsapTaskEntityFrameworkCoreCollection : ICollectionFixture<AsapTaskEntityFrameworkCoreFixture>
{

}

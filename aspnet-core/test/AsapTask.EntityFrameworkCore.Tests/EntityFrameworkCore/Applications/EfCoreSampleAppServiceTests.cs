using AsapTask.Samples;
using Xunit;

namespace AsapTask.EntityFrameworkCore.Applications;

[Collection(AsapTaskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AsapTaskEntityFrameworkCoreTestModule>
{

}

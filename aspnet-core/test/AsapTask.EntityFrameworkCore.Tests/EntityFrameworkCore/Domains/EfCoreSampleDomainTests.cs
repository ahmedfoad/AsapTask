using AsapTask.Samples;
using Xunit;

namespace AsapTask.EntityFrameworkCore.Domains;

[Collection(AsapTaskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AsapTaskEntityFrameworkCoreTestModule>
{

}

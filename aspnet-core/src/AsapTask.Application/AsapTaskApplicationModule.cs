using AsapTask.StockMarket;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.BackgroundWorkers.Quartz;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace AsapTask;

[DependsOn(
    typeof(AsapTaskDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(AsapTaskApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    //typeof(AbpBackgroundWorkersModule)
    typeof(AbpBackgroundWorkersQuartzModule) //Add BackgroundWorkersQuartz
    )]
public class AsapTaskApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AsapTaskApplicationModule>();
        });

        Configure<AbpBackgroundWorkerQuartzOptions>(options =>
        {
            options.IsAutoRegisterEnabled = true;
        });


    }


    //public override async Task OnApplicationInitializationAsync(
    //    ApplicationInitializationContext context)
    //{
    //    await context.AddBackgroundWorkerAsync<MyLogWorker>();
    //}
}

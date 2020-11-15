﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Quizlet_Fake
{
    [DependsOn(
        typeof(Quizlet_FakeDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(Quizlet_FakeApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    public class Quizlet_FakeApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<Quizlet_FakeApplicationModule>();
            });
            context.Services.AddAuthentication()
            .AddFacebook(facebook =>
            {
                facebook.AppId = "4123686247648546";
                facebook.AppSecret = "9433ea430168dade9c310171a70fe9f3";
                facebook.Scope.Add("email");
                facebook.Scope.Add("public_profile");
            });
        }
    }
}

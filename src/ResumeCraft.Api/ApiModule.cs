using Autofac;
using ResumeCraft.Api.Models.Admin;

namespace ResumeCraft.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region AdminModel
            builder.RegisterType<AdminUserManagementModel>().AsSelf();
            #endregion
        }
    }
}

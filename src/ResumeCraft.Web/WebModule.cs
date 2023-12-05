using Autofac;
using ResumeCraft.Web.Areas.Admin.Models;
using ResumeCraft.Web.Models;

namespace ResumeCraft.Web
{
    public class WebModule : Module
    {
        public WebModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region CommonModel
            builder.RegisterType<AccessDeniedModel>().AsSelf();
            builder.RegisterType<PageNotFoundModel>().AsSelf();
            #endregion

            #region AdminModel
            builder.RegisterType<AdminUserManagementModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AdminUpdateModel>().AsSelf();
            #endregion
        }
    }
}

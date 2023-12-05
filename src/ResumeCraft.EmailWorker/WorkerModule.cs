using Autofac;

namespace ResumeCraft.EmailWorker
{
    public class WorkerModule : Module
    {
        public WorkerModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EmailSender>().AsSelf();
        }
    }
}

using Autofac;

namespace ResumeCraft.EmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _scope.Resolve<EmailSender>().SendPromotionalEmail();

                _logger.LogInformation("Worker running at: {time}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                await Task.Delay(120000, stoppingToken);
            }
        }
    }
}

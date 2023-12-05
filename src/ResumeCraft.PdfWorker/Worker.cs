namespace ResumeCraft.PdfDeleteWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Executing started...");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var pdfDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName + $"\\ResumeCraft.Web\\wwwroot\\pdffiles";
                    //_logger.LogInformation("Worker running at: {time} - {wwwroot}", DateTimeOffset.Now, pdfDirectory);
                    DeleteExpiredPDFs(pdfDirectory);
                    await Task.Delay(5000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError("{message} - {obj}", ex.Message, ex);
                }
            }
        }

        private void DeleteExpiredPDFs(string pdfDirectory)
        {
            try
            {
                if (!Directory.Exists(pdfDirectory))
                {
                    return;
                }
                var pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");

                foreach (var pdfFile in pdfFiles)
                {
                    var fileCreationTime = File.GetCreationTime(pdfFile);
                    if (DateTime.Now - fileCreationTime > TimeSpan.FromSeconds(30))
                    {
                        File.Delete(pdfFile);
                        _logger.LogInformation("Deleted expired PDF file: {pdfFile}", pdfFile);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting PDF files: {ex.Message}", ex.Message);
            }
        }
    }
}

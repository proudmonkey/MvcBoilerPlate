
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MvcBoilerPlate.AspNetCore.Workers
{
    public class MessageQueueProcessorService: BackgroundService
    {
        private readonly ILogger<MessageQueueProcessorService> _logger;

        public MessageQueueProcessorService(ILogger<MessageQueueProcessorService> logger) {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogDebug($"MessageQueueProcessorService is starting.");

            stoppingToken.Register(() => _logger.LogDebug($" MessageQueueProcessorService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"MessageQueueProcessorService task doing background work.");

                //TO DO:
                //PubSub/Message Queue subscription and process message
                //Save to DB

                //This is just to simulate a job that runs every 5 seconds
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogDebug($"MessageQueueProcessorService background task is stopping.");
        }
    }
}

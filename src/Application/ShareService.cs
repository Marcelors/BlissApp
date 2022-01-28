using Application.DTOs;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class ShareService : IShareService
    {
        private readonly ILogger _logger;

        public ShareService(ILogger<ShareService> logger)
        {
            _logger = logger;
        }

        public void Send(ShareRequestDto dto)
        {
            _logger.LogInformation("Send Email to {email} with content {contet}", dto.DestinationEmail, dto.ContentUrl);
        }
    }
}

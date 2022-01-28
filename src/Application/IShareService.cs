using Application.DTOs;

namespace Application
{
    public interface IShareService
    {
        public void Send(ShareRequestDto dto);
    }
}

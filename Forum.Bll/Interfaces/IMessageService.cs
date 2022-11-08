using Forum.Common.Dtos.Message;

namespace Forum.Bll.Interfaces
{
    public interface IMessageService
    {
        Task<IList<MessageDto>> GetMessagesAsync();
        Task<MessageDto> GetMessageByIdAsync(int id);
        Task<MessageDto> CreateMessageAsync(MessageUpdateDto MessageUpdateDto);
        Task<MessageDto> UpdateMessageAsync(int id, MessageUpdateDto MessageUpdateDto);
        Task DeleteMessageAsync(int id);
    }
}

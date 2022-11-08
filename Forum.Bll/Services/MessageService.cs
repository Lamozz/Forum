using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Message;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Message> _repository;

        public MessageService(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<MessageDto>> GetMessagesAsync()
        {
            var messages = await _repository.GetAllAsync();
            return messages.Select(messages => _mapper.Map<Message, MessageDto>(messages)).ToList();
        }
        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _repository.GetByIdAsync(id);

            if (message is null)
            {
                throw new NotFoundException("Message isn't exists.");
            }
            return _mapper.Map<Message, MessageDto>(message);
        }
        public async Task<MessageDto> CreateMessageAsync(MessageUpdateDto messageUpdateDto)
        {
            var message = _mapper.Map<Message>(messageUpdateDto);

            await _repository.CreateAsync(message);

            return _mapper.Map<Message, MessageDto>(message);
        }
        public async Task<MessageDto> UpdateMessageAsync(int id, MessageUpdateDto messageUpdateDto)
        {
            var message = await _repository.GetByIdAsync(id);

            if (message is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(messageUpdateDto, message);

            await _repository.UpdateAsync(message);

            return _mapper.Map<Message, MessageDto>(message);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}

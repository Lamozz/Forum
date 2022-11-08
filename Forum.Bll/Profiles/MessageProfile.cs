using AutoMapper;
using Forum.Common.Dtos.Message;
using Forum.Domain;

namespace Forum.Bll.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageUpdateDto, Message>();
        }
    }
}

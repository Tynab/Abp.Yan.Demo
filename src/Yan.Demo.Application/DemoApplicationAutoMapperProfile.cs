using AutoMapper;
using Yan.Demo.Etos;
using Yan.Demo.Requests;

namespace Yan.Demo;

public class DemoApplicationAutoMapperProfile : Profile
{
    public DemoApplicationAutoMapperProfile() => CreateMap<MessageRequest, MessageEto>().ReverseMap();
}

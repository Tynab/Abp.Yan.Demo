using AutoMapper;
using Yan.Demo.Eto;
using Yan.Demo.Request;

namespace Yan.Demo;

public class DemoApplicationAutoMapperProfile : Profile
{
    public DemoApplicationAutoMapperProfile() => CreateMap<MessageRequest, MessageEto>().ReverseMap();
}

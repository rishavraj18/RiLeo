using RiLeo.Web.Models;

namespace RiLeo.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}

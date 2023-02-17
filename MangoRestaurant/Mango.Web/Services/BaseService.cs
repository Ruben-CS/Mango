using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services;

public class BaseService : IBaseService
{
    public void        Dispose()
    {
        throw new NotImplementedException();
    }

    public ResponseDto responseModel { get; set; }
    public Task<T>      SendAsync<T>(ApiRequest apiRequest)
    {
        throw new NotImplementedException();
    }
}
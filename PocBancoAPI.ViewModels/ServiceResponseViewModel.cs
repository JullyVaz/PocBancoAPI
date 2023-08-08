using System.Net;

namespace PocBancoAPI.ViewModels;

public class ServiceResponseViewModel<T>
{
    public ServiceResponseViewModel()
    {
        IsSuccess = true;
    }

    public ServiceResponseViewModel(Exception ex) 
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.InternalServerError;
        Message = ex.GetBaseException().Message;
    }



    public HttpStatusCode StatusCode { get; set; }
    public T Data { get; set; }
    public bool IsSuccess { get; set; } 
    public string Message { get; set; }
}

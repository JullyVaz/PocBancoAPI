using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    public T Data { get; set; } = default(T);
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public bool HasData { get; set; }


    public void SetData(T data)
    {
        Data = data;
        HasData = true;
    }
}
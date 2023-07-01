namespace PocBancoAPI.ViewModels;

public class ServiceResponseViewModel<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; }
}

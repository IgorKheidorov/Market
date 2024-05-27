namespace OOPSample.Interfaces;

internal interface IService
{
    ICommand ProcessRequest(object item, string procedureDescription);   
}

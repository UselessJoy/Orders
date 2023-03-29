using Orders.Model.Entity;

namespace Orders.Service.CheckService
{
    public interface IDaoCheck
    {

        Task<IResult> CheckInfo(int clientId, int orderId);

        Task<IResult> CheckSumm(int clientId, int orderId);

       // Task<IResult> Delete(Client client, int id);
    }
}

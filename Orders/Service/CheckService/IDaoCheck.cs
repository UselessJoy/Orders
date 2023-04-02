using Orders.Model.Entity;

namespace Orders.Service.CheckService
{
    public interface IDaoCheck
    {

        Task<IResult> CheckInfo(int orderId);

        Task<IResult> CheckSumm(int orderId);

       // Task<IResult> Delete(Client client, int id);
    }
}

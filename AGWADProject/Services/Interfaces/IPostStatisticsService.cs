namespace AGWADProject.Services.Interfaces
{
    public interface IPostStatisticsService
    {
        int GetTotalPostCount();
        int GetPostCountByPerson(int personId);
        int GetPostCountByCar(int carId);
    }
}

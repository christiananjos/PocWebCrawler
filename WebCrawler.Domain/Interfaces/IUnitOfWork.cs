namespace WebCrawler.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}

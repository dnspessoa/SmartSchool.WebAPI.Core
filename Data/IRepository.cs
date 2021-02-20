namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        //teste
        string GetIRepositoryTeste();

        void Add<T>(T entity ) where T : class;
        void Update<T>(T entity ) where T : class;
        void Delete<T>(T entity ) where T : class;
        void SaveChanges();
    }
}
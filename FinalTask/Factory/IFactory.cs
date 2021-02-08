using DAL.Interfaces;

namespace Factory
{
    public interface IFactory
    {
        public IRepository GetRepository(string fileType);
    }
}

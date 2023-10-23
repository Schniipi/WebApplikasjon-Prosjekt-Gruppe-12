
using WebApplication1.brukerDataX;

namespace bacit_dotnet.MVC.Repositories
{
    public interface IDyrRepository
    {
        void Upsert(Verdi dyr);
        Verdi Get(int id);
        List<Verdi> GetAll();
    }
}
using Consalud.Commons.contracts;
using Consalud.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;

namespace Consalud.DataAccess
{
    public class DatabaseEngine
    {
      
        public DatabaseEngine(IConfiguration configuration)
        {
            var pDataContext = new DataContext(configuration);
            FacturasRepository = new FacturasDA(pDataContext);
            UserRepository = new UserDA(pDataContext);
        }

        public IFacturasRepository FacturasRepository { private set; get; }
        public IUserRepository UserRepository { private set; get; }

        


    }
}



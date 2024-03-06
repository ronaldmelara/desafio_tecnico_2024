using Microsoft.Extensions.Configuration;

namespace Consalud.DataAccess
{
    public class DatabaseEngine
    {
      
        public DatabaseEngine(IConfiguration configuration)
        {
            Data = new DataContext(configuration);

            
        }


        public DataContext Data { private set; get; }
    }
}



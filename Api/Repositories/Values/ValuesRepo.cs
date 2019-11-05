using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories.Values
{
    public class ValuesRepo : IValuesRepo
    {
        private readonly DataContext dataContext;
        public ValuesRepo(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public List<Value> GetValues()
        {
            var values = dataContext.Values.ToList();
            return values;
        }
    }
}
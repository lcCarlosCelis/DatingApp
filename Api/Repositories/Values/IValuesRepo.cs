using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories.Values
{
    public interface IValuesRepo
    {
        List<Value> GetValues();
    }
}
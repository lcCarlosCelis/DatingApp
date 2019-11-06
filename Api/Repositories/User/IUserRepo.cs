using System.Collections.Generic;
using Api.DTOs.User;

namespace Api.Repositories.User
{
    public interface IUserRepo
    {
        List<UsuarioVista> getUsuarios();
    }
}
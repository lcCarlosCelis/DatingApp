using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.DTOs.User;

namespace Api.Repositories.User
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext dataContext;
        public UserRepo(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public List<UsuarioVista> getUsuarios()
        {
            var users = dataContext.Usuarios.ToList();
            var listView = new List<UsuarioVista>();
            foreach (var usuario in users)
            {
                var foto = dataContext.Fotos.FirstOrDefault(x => x.Usuario == usuario && x.EsMain == true);
                UsuarioVista usuarioVista = new UsuarioVista(){
                    NombreCompleto = usuario.NombreCompleto,
                    Url = foto.Url
                };
                listView.Add(usuarioVista);
            }
            return listView;
            
        }
    }
}

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Api.Data;
using Api.DTOs.Auth;
using Api.Models;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Repositories.Auth
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DataContext dataContext;
        private readonly IConfiguration configuration;
        public AuthRepo(DataContext dataContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dataContext = dataContext;
        }

        public Token login(Login login)
        {
            login.Usuario = login.Usuario.ToLower();
            var usrDb = dataContext.Usuarios.FirstOrDefault(x => x.Nombre == login.Usuario);
            if(usrDb == null){
                return null;
            }
            if(!Decrypt(login.Clave, usrDb.Hash, usrDb.Salt)){
                return null;
            }
            var newToken = BuildToken(usrDb);
            Token myToken = new Token(){
                myToken = newToken
            };
            return myToken;
        }

        private string BuildToken(Usuario usrDb)
        {
            var myClaims = new[]{
                new Claim(ClaimTypes.NameIdentifier, usrDb.Cedula),
                new Claim(ClaimTypes.Name, usrDb.Nombre)
            };
            var myKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(configuration.GetSection("Token:myKey").Value));
            var mySigning = new SigningCredentials(myKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(myClaims),
                SigningCredentials = mySigning,
                Expires = DateTime.Now.AddDays(1)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(myToken);
        }

        private bool Decrypt(string clave, byte[] hash, byte[] salt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var newHash = hmac.ComputeHash(System.Text.Encoding.UTF8.
                    GetBytes(clave));
                for (int i = 0; i < newHash.Length; i++)
                {
                    if(newHash[i] != hash[i]){ return false; }
                }
            }
            return true;
        }

        public bool register(Register register)
        {
            register.Usuario = register.Usuario.ToLower();
            if (dataContext.Usuarios.Any(x => x.Nombre == register.Usuario)) { return false; }
            byte[] myHash, mySalt;
            Encrypt(register.Clave, out myHash, out mySalt);
            Usuario usuario = new Usuario(){
                Cedula = register.Cedula,
                Nombre = register.Usuario,
                Hash = myHash,
                Salt = mySalt,
                NombreCompleto = register.Nombre,
                Creado = DateTime.Now,
                UltimoLog = DateTime.Now
            };
            dataContext.Usuarios.Add(usuario);
            dataContext.SaveChanges();
            Foto defFoto = new Foto(){
                Descripcion = "Foto por defecto",
                Url = "https://res.cloudinary.com/lccarloscelis/image/upload/v1572991126/barney_ocv7ol.jpg",
                PublicId = "barney_ocv7ol",
                Usuario = usuario
            };
            dataContext.Fotos.Add(defFoto);
            dataContext.SaveChanges();
            return true;
        }

        private void Encrypt(string clave, out byte[] myHash, out byte[] mySalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                myHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave));
                mySalt = hmac.Key;
            }
        }
    }
}

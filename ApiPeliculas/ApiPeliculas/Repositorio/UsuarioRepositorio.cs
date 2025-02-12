using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiPeliculas.Repositorio
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly ApplicationDBContext _bd;
        private string claveSecreta;

        public UsuarioRepositorio(ApplicationDBContext bd, IConfiguration config)
        {
            _bd = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public Usuario GetUsuario(int usuarioId)
        {
            return _bd.Usuario.FirstOrDefault(c => c.Id == usuarioId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(c => c.NombreUsuario).ToList();
        }

        public bool IsUniqueUser(string usuario)
        {
            var usuarioBd = _bd.Usuario.FirstOrDefault(u => u.NombreUsuario == usuario);
            if (usuarioBd == null) {
                return true;
            }
            return false;
        }

        public async Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var passwordEncriptado = obtenermd5(usuarioLoginDto.Password);

            var usuario = _bd.Usuario.FirstOrDefault(
                u => u.NombreUsuario.ToLower() == usuarioLoginDto.NombreUsuario.ToLower()
                && u.Password == passwordEncriptado
                );

            //Validamos si el usuario no existe con la combinacion de usuario y contrasena correcta
            if (usuario == null)
            {
                return new UsuarioLoginRespuestaDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            //Aqui existe el usuario entonces podemos procesar el login
            var manejandoToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = manejandoToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDto usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                Token = manejandoToken.WriteToken(token),
                Usuario = usuario
            };

            return usuarioLoginRespuestaDto;
        }

        public async Task<Usuario> Regsitro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var passwordEncriptada = obtenermd5(usuarioRegistroDto.Password);

            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioRegistroDto.NombreUsuario,
                Password = passwordEncriptada,
                Nombre = usuarioRegistroDto.Nombre,
                Role = usuarioRegistroDto.Role,

            };
            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            usuario.Password = passwordEncriptada;
            return usuario;
        }

        //Metodo para encriptar contrasena MD5 no se usa tanto en el acceso
        public static string obtenermd5(string texto)
        {
            // Crear una instancia del algoritmo MD5
            using (MD5 md5 = MD5.Create())
            {
                // Convertir el texto en un array de bytes
                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);

                // Generar el hash MD5 a partir de los bytes
                byte[] hashBytes = md5.ComputeHash(textoBytes);

                // Convertir el hash a formato hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                // Devolver el hash MD5 en formato string
                return sb.ToString();
            }
        }
    }
}

using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;

namespace ApiPeliculas.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int CategoriaId);
        bool IsUniqueUser(string usuario);
        Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto);
        Task<Usuario> Regsitro(UsuarioRegistroDto usuarioRegistroDto);

    }
}

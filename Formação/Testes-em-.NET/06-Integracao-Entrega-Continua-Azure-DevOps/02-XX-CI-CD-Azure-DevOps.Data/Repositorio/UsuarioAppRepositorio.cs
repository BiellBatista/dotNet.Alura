using _02_XX_CI_CD_Azure_DevOps.Data.Contexto;
using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_CI_CD_Azure_DevOps.Data.Repositorio
{
    public class UsuarioAppRepositorio : IUsuarioRepositorio
    {
        private readonly ByteBankContexto _contexto;

        public UsuarioAppRepositorio()
        {
            _contexto = new ByteBankContexto();
        }

        public bool Adicionar(UsuarioApp usuario)
        {
            try
            {
                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Atualizar(int id, UsuarioApp usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return false;
                }
                _contexto.Entry(usuario).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Id == id);

            try
            {
                if (usuario == null)
                {
                    return false;
                }
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioApp ObterPorId(int id)
        {
            try
            {
                var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Id == id);
                if (usuario == null)
                {
                    throw new Exception($"Erro ao obter usuário com Id = {id}.");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioApp ObterPorEmail(string email)
        {
            try
            {
                var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Email == email);
                if (usuario == null)
                {
                    throw new Exception($"Erro ao obter usuário com email = {email}.");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsuarioApp> ObterTodos()
        {
            try
            {
                return _contexto.Usuarios.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter Usuários.");
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
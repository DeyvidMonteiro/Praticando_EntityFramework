using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly eCommerceContext _db;
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.Include(a => a.Contato).OrderBy(a => a.Id).ToList();
        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.Include(a => a.Contato).
                Include(a => a.EnderecoEntrega).
                Include(a => a.Departamentos).
                FirstOrDefault(a=> a.Id == id)!;
        }

        public void Add(Usuario usuario)
        {
            CriarVinculoUsuarioDepartamento(usuario);

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            ExcluirVinculoUsuarioDepartamento(usuario);

            CriarVinculoUsuarioDepartamento(usuario);

            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }


        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }

        private void CriarVinculoUsuarioDepartamento(Usuario usuario)
        {
            if (usuario.Departamentos != null)
            {
                var departamentos = usuario.Departamentos;

                usuario.Departamentos = new List<Departamento>();

                foreach (var departamento in departamentos)
                {
                    if (departamento.Id > 0)
                    {
                        usuario.Departamentos.Add(_db.Departamentos.Find(departamento.Id)!);
                    }
                    else
                    {
                        usuario.Departamentos.Add(departamento);
                    }
                }
            }
        }

        private void ExcluirVinculoUsuarioDepartamento(Usuario usuario)
        {
            var usuarioBanco = _db.Usuarios.Include(a => a.Departamentos).FirstOrDefault(a => a.Id == usuario.Id)!;

            foreach (var departaento in usuarioBanco!.Departamentos!)
            {
                usuarioBanco.Departamentos.Remove(departaento);
            }
            _db.SaveChanges();
            _db.ChangeTracker.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;
using LimpiandoJuntos.Infrastructure.Data;

//Paso 4  
namespace LimpiandoJuntos.Infrastructure.Repositories
{
    //Se esta implementando la interfaz 
    public class DenunciaRepository : IDenunciaRepository
    {
        private readonly LimpiandoJuntosDbContext _context;

        public DenunciaRepository(LimpiandoJuntosDbContext context)
        {
            _context = context;
        }

        public int GuardarDenuncia(Denuncia denuncia)
        {
            var entity = denuncia;
            _context.Add(entity);
            var rows = _context.SaveChanges();

            if (rows <= 0)
                throw new Exception("No fue posible realizar el registro...");

            return entity.Id;
        }

        public IEnumerable<Denuncia> TraerTodasLasDenuncias()
        {
            return _context.Denuncia.ToList();
        }
        public Denuncia TraerDenunciaPorFolio(int folio)
        {
            return _context.Denuncia.SingleOrDefault(d => d.Id == folio);
        }
    }
}
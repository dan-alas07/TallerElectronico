using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class MarcaBL
    {
        private readonly MarcaDAL _marcaDal = new MarcaDAL();

        public List<Marca> SelectAll()
        {
            return _marcaDal.SelectAll();
        }

        public Marca SelectById(int idMarca)
        {
            if (idMarca <= 0)
                throw new ArgumentException("El ID de marca proporcionado no es válido.");

            return _marcaDal.SelectById(idMarca);
        }

        public Marca Insert(Marca marca)
        {
            if (marca == null)
                throw new ArgumentNullException(nameof(marca), "Los datos de la marca son requeridos.");

            if (string.IsNullOrWhiteSpace(marca.Nombre))
                throw new ArgumentException("El nombre de la marca es obligatorio.");

            marca.Nombre = marca.Nombre.Trim();

            // Validar longitud de Nombre según el esquema
            if (marca.Nombre.Length > 100)
                throw new ArgumentException("El nombre de la marca no puede superar los 100 caracteres.");

            // Validar unicidad de Nombre
            var listaMarcas = _marcaDal.SelectAll();
            if (listaMarcas.Any(m => m.Nombre.Equals(marca.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"La marca '{marca.Nombre}' ya se encuentra registrada.");

            marca.Estado = "A";

            return _marcaDal.Insert(marca);
        }

        public Marca Update(Marca marcaModificada)
        {
            if (marcaModificada == null)
                throw new ArgumentNullException(nameof(marcaModificada), "Los datos de la marca son requeridos.");

            if (marcaModificada.MarcaId <= 0)
                throw new ArgumentException("El ID de marca no es válido.");

            if (string.IsNullOrWhiteSpace(marcaModificada.Nombre))
                throw new ArgumentException("El nombre de la marca es obligatorio.");

            marcaModificada.Nombre = marcaModificada.Nombre.Trim();

            // Validar longitud de Nombre
            if (marcaModificada.Nombre.Length > 100)
                throw new ArgumentException("El nombre de la marca no puede superar los 100 caracteres.");

            var listaMarcas = _marcaDal.SelectAll();

            // Validar que el nombre no pertenezca a otra marca diferente
            if (listaMarcas.Any(m => m.Nombre.Equals(marcaModificada.Nombre, StringComparison.OrdinalIgnoreCase)
                                  && m.MarcaId != marcaModificada.MarcaId))
            {
                throw new InvalidOperationException($"La marca '{marcaModificada.Nombre}' ya está siendo usada por otro registro.");
            }

            var marcaExistente = _marcaDal.SelectById(marcaModificada.MarcaId);
            if (marcaExistente == null)
                throw new InvalidOperationException($"La marca con ID {marcaModificada.MarcaId} no existe o se encuentra inactiva.");

            return _marcaDal.Update(marcaModificada);
        }

        public bool Delete(int idMarca)
        {
            if (idMarca <= 0)
                throw new ArgumentException("El ID de marca no es válido.");

            var marcaExistente = _marcaDal.SelectById(idMarca);
            if (marcaExistente == null)
                throw new InvalidOperationException($"La marca con ID {idMarca} no existe o ya se encuentra inactiva.");

            return _marcaDal.Delete(idMarca);
        }
    }
}
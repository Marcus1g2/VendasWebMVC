﻿using VendasWebMvc.Data;
using VendasWebMvc.Models;
namespace VendasWebMvc.Services
{
    public class VendedorServicos
    {
        private readonly VendasWebMvcContext _context;

        public VendedorServicos(VendasWebMvcContext context)
        {
            _context = context;
        }

      public List<Vendedor> MostraV()
        {
            return _context.Vendedor.ToList();
        }
        public void AddVendedor(Vendedor v)
        {
            v.Departamento = _context.Departamento.First();
            _context.Vendedor.Add(v);

            _context.SaveChanges();
        }

    }
}
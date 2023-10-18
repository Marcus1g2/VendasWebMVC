


using NuGet.Protocol.Plugins;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;
namespace VendasWebMvc.Data
{
    public class ServicoDeSedding
    {
        private readonly VendasWebMvcContext _context;
        public ServicoDeSedding(VendasWebMvcContext context)
        {
            _context = context;
        }
        public  void Create()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroDeVenda.Any())
            {
                return;
            }
            Departamento D1 = new Departamento(1, "Computadores");
            Departamento D2 = new Departamento(2, "Eletronicos");
            Departamento D3 = new Departamento(3, "Moda");
            Vendedor V1 = new Vendedor(1, "Alberto", new DateTime(1998, 09, 23), 1200.0, D1);
            Vendedor V2 = new Vendedor(2, "Francisco", new DateTime(1995, 09, 23), 1200.0, D2);
            Vendedor V3 = new Vendedor(3, "Lucas", new DateTime(1991, 09, 23), 1200.0, D2);
            Vendedor V4 = new Vendedor(4, "Martha Red", new DateTime(1993, 11, 30), 3000.0, D3);
            Vendedor V5 = new Vendedor(5, "Donald Blue", new DateTime(2000, 1, 9), 4000.0, D3);
            Vendedor V6 = new Vendedor(6, "Alex Pink", new DateTime(1997, 3, 4), 3000.0, D2);

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2022, 05, 11), 22000, StatusVenda.Finalizado, V1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2020, 06, 01), 22500, StatusVenda.Finalizado, V2);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2019, 05, 11), 1500, StatusVenda.Finalizado, V3);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2018, 09, 1), 8000.0, StatusVenda.Finalizado, V4);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2018, 09, 21), 3000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2018, 09, 15), 2000.0, StatusVenda.Finalizado, V4);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Finalizado, V5);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2018, 09, 11), 4000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, V2);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2018, 09, 7), 9000.0, StatusVenda.Finalizado, V2);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2018, 09, 13), 6000.0, StatusVenda.Finalizado, V5);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, V6);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2018, 09, 4), 3000.0, StatusVenda.Finalizado, V1);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2018, 09, 12), 4000.0, StatusVenda.Finalizado, V4);
            RegistroDeVenda r16 = new RegistroDeVenda(16, new DateTime(2018, 10, 5), 2000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r17 = new RegistroDeVenda(17, new DateTime(2018, 10, 1), 12000.0, StatusVenda.Finalizado, V4);
            RegistroDeVenda r18 = new RegistroDeVenda(18, new DateTime(2018, 10, 24), 6000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r19 = new RegistroDeVenda(19, new DateTime(2018, 10, 22), 8000.0, StatusVenda.Finalizado, V1);
            RegistroDeVenda r20 = new RegistroDeVenda(20, new DateTime(2018, 10, 15), 8000.0, StatusVenda.Finalizado, V2);
            RegistroDeVenda r21 = new RegistroDeVenda(21, new DateTime(2018, 10, 17), 9000.0, StatusVenda.Finalizado, V5);
            RegistroDeVenda r22 = new RegistroDeVenda(22, new DateTime(2018, 10, 24), 4000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r23 = new RegistroDeVenda(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, V5);
            RegistroDeVenda r24 = new RegistroDeVenda(24, new DateTime(2018, 10, 12), 8000.0, StatusVenda.Finalizado, V1);
            RegistroDeVenda r25 = new RegistroDeVenda(25, new DateTime(2018, 10, 31), 7000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r26 = new RegistroDeVenda(26, new DateTime(2018, 10, 6), 5000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r27 = new RegistroDeVenda(27, new DateTime(2018, 10, 13), 9000.0, StatusVenda.Pendente, V4);
            RegistroDeVenda r28 = new RegistroDeVenda(28, new DateTime(2018, 10, 7), 4000.0, StatusVenda.Finalizado, V6);
            RegistroDeVenda r29 = new RegistroDeVenda(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Finalizado, V1);
            RegistroDeVenda r30 = new RegistroDeVenda(30, new DateTime(2018, 10, 12), 5000.0, StatusVenda.Finalizado, V5);

            _context.Departamento.AddRange(D1, D2, D3);
            _context.Vendedor.AddRange(V1, V2, V3, V4, V5, V6);
            _context.RegistroDeVenda.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

             _context.SaveChanges();

        }
    }
}

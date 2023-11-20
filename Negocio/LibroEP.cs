using AutoMapper;
using Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public class LibroEP
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibroEP(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LibroDTO>> Get()
        {
            try
            {
                var libros = await context.Libro.ToListAsync();
                return mapper.Map<List<LibroDTO>>(libros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener libros: {ex.Message}");
                throw;
            }
        }

       //public async Task<ResultadoOperacionDTO> Post(LibroCDTO libroCDTO)
       // {
       //     try
       //     {
       //         var libro = mapper.Map<Libro>(libroCDTO);
       //         context.Add(libro);
       //         await context.SaveChangesAsync();

       //         return new ResultadoOperacionDTO { Exitoso = true, Mensaje = "Libro creado correctamente" };
       //     }
       //     catch (Exception ex)
       //     {
       //         Console.WriteLine($"Error al crear libro: {ex.Message}");
       //         return new ResultadoOperacionDTO { Exitoso = false, Mensaje = "Error al crear libro" };
       //     }

          
       // }
    }
}

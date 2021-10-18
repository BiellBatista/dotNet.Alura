using _01_XX_Arrumando_Codigo.Data;
using _01_XX_Arrumando_Codigo.Data.Dtos.Cinema;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace _01_XX_Arrumando_Codigo.Services
{
    public class CinemaService
    {
        private IMapper _mapper;

        private AppDbContext _context;

        public CinemaService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            var cinemas = _context.Cinemas.ToList();

            if (cinemas is null)
                return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema is not null)
                return _mapper.Map<ReadCinemaDto>(cinema);

            return null;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema is null)
                return Result.Fail("Cinema não encontrado");

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema is null)
                return Result.Fail("Cinema não encontrado");

            _context.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
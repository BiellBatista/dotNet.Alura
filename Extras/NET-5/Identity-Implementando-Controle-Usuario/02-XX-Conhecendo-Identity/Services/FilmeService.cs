using _02_XX_Conhecendo_Identity.Data;
using _02_XX_Conhecendo_Identity.Data.Dtos.Filme;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace _02_XX_Conhecendo_Identity.Services
{
    public class FilmeService
    {
        private IMapper _mapper;

        private AppDbContext _context;

        public FilmeService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;

            if (classificacaoEtaria is null)
                filmes = _context.Filmes.ToList();

            filmes = _context.Filmes
                        .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
                        .ToList();

            if (filmes is not null)
                return _mapper.Map<List<ReadFilmeDto>>(filmes);

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme is not null)
                return _mapper.Map<ReadFilmeDto>(filme);

            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme is null)
                return Result.Fail("Filme não encontrado");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme is null)
                return Result.Fail("Filme não encontrado");

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
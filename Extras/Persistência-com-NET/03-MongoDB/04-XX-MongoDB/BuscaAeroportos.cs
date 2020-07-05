using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class BuscaAeroportos
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //acesso ao servidor do MongoDB
            var conexaoAeroporto = new ConectandoMongoDBGeo();
            var ponto = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(ponto);
            var construtor = Builders<Aeroporto>.Filter;
            //NearSphere irá traçar um circulo no mapa para verificar os pontos contidos nele
            var condicao = construtor.NearSphere(x => x.Loc, localizacao, 100000);

            Console.WriteLine("Listando Aeroportos");

            //buscando documentos, sem critério
            var listaAirports = await conexaoAeroporto.Airports.Find(condicao).ToListAsync();

            foreach (var airport in listaAirports)
            {
                Console.WriteLine(airport.ToJson<Aeroporto>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}

﻿using _05_XX_MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using _05_XX_MongoDB.Geocoding;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver;

namespace _05_XX_MongoDB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //coordenadas quaisquer para mostrar o mapa
            var coordenadas = new Coordenada("São Paulo", "-23.64340873969638", "-46.730219057147224");
            return View(coordenadas);
        }

        public async Task<JsonResult> Localizar(HomeViewModel model)
        {
            Debug.WriteLine(model);

            //Captura a posição atual e adiciona a lista de pontos
            Coordenada coordLocal = ObterCoordenadasDaLocalizacao(model.Endereco);
            var aeroportosProximos = new List<Coordenada>();
            // o primeiro ponto deve ser o da minha localizacao atual
            aeroportosProximos.Add(coordLocal);

            //Captura a latitude e longitude locais
            double lat = Convert.ToDouble(coordLocal.Latitude.Replace(".", ","));
            double lon = Convert.ToDouble(coordLocal.Longitude.Replace(".", ","));

            //Testa o tipo de aeroporto que será usado na consulta
            string tipoAero = "";

            if (model.Tipo == TipoAeroporto.Internacionais)
            {
                tipoAero = "International";
            }
            if (model.Tipo == TipoAeroporto.Municipais)
            {
                tipoAero = "Municipal";
            }

            //Captura o valor da distancia
            int distancia = model.Distancia * 1000;

            //acesso ao servidor do MongoDB
            var conexaoAeroporto = new ConectandoMongoDBGeo();

            //Configura o ponto atual no mapa           
            var ponto = new GeoJson2DGeographicCoordinates(lon, lat);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(ponto);

            // filtro
            var construtor = Builders<Aeroporto>.Filter;
            FilterDefinition<Aeroporto> filtro_builder;

            if (tipoAero == "")
            {
                //NearSphere irá traçar um circulo no mapa para verificar os pontos contidos nele
                filtro_builder = construtor.NearSphere(x => x.Loc, localizacao, distancia);
            }
            else
            {
                //NearSphere irá traçar um circulo no mapa para verificar os pontos contidos nele
                filtro_builder = construtor.NearSphere(x => x.Loc, localizacao, distancia) & construtor.Eq(x => x.Type, tipoAero);
            }

            //Captura  a lista
            var listaAirports = await conexaoAeroporto.Airports.Find(filtro_builder).ToListAsync();

            //Escreve os pontos
            foreach (var airport in listaAirports)
            {
                var aereo = new Coordenada(airport.Name,
                    Convert.ToString(airport.Loc.Coordinates.Latitude).Replace(',', '.'),
                    Convert.ToString(airport.Loc.Coordinates.Longitude).Replace(',', '.'));

                aeroportosProximos.Add(aereo);
            }

            return Json(aeroportosProximos);
        }

        private Coordenada ObterCoordenadasDaLocalizacao(string endereco)
        {
            string url = $"http://maps.google.com/maps/api/geocode/json?address={endereco}";
            Debug.WriteLine(url);

            var coord = new Coordenada("Não Localizado", "-10", "-10");
            var response = new WebClient().DownloadString(url);
            var googleGeocode = JsonConvert.DeserializeObject<GoogleGeocodeResponse>(response);
            //Debug.WriteLine(googleGeocode);

            if (googleGeocode.status == "OK")
            {
                coord.Nome = googleGeocode.results[0].formatted_address;
                coord.Latitude = googleGeocode.results[0].geometry.location.lat;
                coord.Longitude = googleGeocode.results[0].geometry.location.lng;
            }

            return coord;
        }
    }
}
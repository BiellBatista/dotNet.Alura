﻿using _05_XX_Restaurante.Service.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace _05_XX_Restaurante.Service.RabbitMqClient;

public class RabbitMqClient : IRabbitMqClient
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqClient(IConfiguration configuration)
    {
        _configuration = configuration;
        _connection = new ConnectionFactory() { HostName = _configuration["RabbitMqHost"], Port = int.Parse(_configuration["RabbitMqPort"]) }.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
    }

    public void PublicaRestaurante(RestauranteReadDto restauranteReadDto)
    {
        string mensagem = JsonSerializer.Serialize(restauranteReadDto);
        var body = Encoding.UTF8.GetBytes(mensagem);

        _channel.BasicPublish(exchange: "trigger",
            routingKey: "",
            basicProperties: null,
            body: body
            );
    }
}
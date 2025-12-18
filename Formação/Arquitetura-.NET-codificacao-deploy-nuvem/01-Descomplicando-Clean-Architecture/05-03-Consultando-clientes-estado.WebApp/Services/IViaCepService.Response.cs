namespace _05_03_Consultando_clientes_estado.WebApp.Services;

public record ViaCepResponse(string CEP, string Logradouro, string Complemento, string Unidade, string Bairro, string Localidade, string UF, string Estado, string Regiao);

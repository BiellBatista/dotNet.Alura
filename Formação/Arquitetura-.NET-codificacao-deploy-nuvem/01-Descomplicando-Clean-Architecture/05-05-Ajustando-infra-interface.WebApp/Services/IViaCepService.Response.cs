namespace _05_05_Ajustando_infra_interface.WebApp.Services;

public record ViaCepResponse(string CEP, string Logradouro, string Complemento, string Unidade, string Bairro, string Localidade, string UF, string Estado, string Regiao);
namespace _02_07_Traduzindo_informacoes_externas.WebApp.Services;

public record ViaCepResponse(string CEP, string Logradouro, string Complemento, string Unidade, string Bairro, string Localidade, string UF, string Estado, string Regiao);
namespace _05_04_Implementando_caso_uso.WebApp.Services;

public record ViaCepResponse(string CEP, string Logradouro, string Complemento, string Unidade, string Bairro, string Localidade, string UF, string Estado, string Regiao);
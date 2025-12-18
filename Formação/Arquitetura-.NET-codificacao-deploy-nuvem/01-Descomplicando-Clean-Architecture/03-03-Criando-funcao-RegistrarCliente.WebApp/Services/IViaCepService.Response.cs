namespace _03_03_Criando_funcao_RegistrarCliente.WebApp.Services;

public record ViaCepResponse(string CEP, string Logradouro, string Complemento, string Unidade, string Bairro, string Localidade, string UF, string Estado, string Regiao);
using System.Net.Http.Json;
using UrbanFarming.Domain.Classes;

namespace UrbanFarmingWeb.UI.Request
{
	public class RequestAPI
	{
		private readonly HttpClient _httpClient;
		public RequestAPI(HttpClient httpClient) { 
		
			_httpClient = httpClient;

			_httpClient.BaseAddress = new Uri("http://localhost:5152");
		
		}

		public async Task<Login> EfetuarLogin(string username, string password) => await _httpClient.GetAsync($"/api/Seguranca/Login?email={username}&senha={password}").Result.Content.ReadFromJsonAsync<Login>();
		public async Task<HttpResponseMessage> EfetuarCadastrado(Login dados) => _httpClient.PostAsJsonAsync<Login>($"/api/Seguranca/CadastrarUsuario", dados).Result;
        public async Task<HttpResponseMessage> EfetuarCadastradoFornecedor(Fornecedores dados) => _httpClient.PostAsJsonAsync<Fornecedores>("/api/Fornecedores", dados).Result;
        public async Task<HttpResponseMessage> EfetuarCadastradoProduto(Produtos dados) => _httpClient.PostAsJsonAsync<Produtos>("/api/Produtos", dados).Result;
        public async Task<HttpResponseMessage> EfetuarDeleteProduto(string dados) => _httpClient.DeleteAsync($"/api/Produtos/{dados}").Result;
        public async Task<HttpResponseMessage> EfetuarCadastradoPedido(Pedido dados) => _httpClient.PostAsJsonAsync<Pedido>("/api/Pedidos/CadastrarPedido", dados).Result;
        public async Task<List<Produtos>> ListaProdutos()=> await _httpClient.GetAsync("/api/Produtos/GetAllProdutos").Result.Content.ReadFromJsonAsync<List<Produtos>>();
        public async Task<List<Pedido>> ListaPedidos() => await _httpClient.GetAsync("/api/Pedidos").Result.Content.ReadFromJsonAsync<List<Pedido>>();

    }
}

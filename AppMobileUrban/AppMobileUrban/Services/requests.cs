using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using AppMobileUrban.Models;
using Xamarin.Forms.PlatformConfiguration;
using System.Collections.Generic;

namespace AppMobileUrban.Services
{
    public class requests
    {
        private RestClient client = new RestClient("http://10.0.2.2:5152");

        public async Task<Login> EfetuarLogin(string username, string password)
        {
            try
            {
                var request = new RestRequest($"/api/Seguranca/Login?email={username}&senha={password}", Method.Get);

                var response = await client.ExecuteAsync(request);

                return JsonConvert.DeserializeObject<Login>(response.Content);


            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public async void EfetuarCadastro(Login dados)
        {

            try
            { 
                var request = new RestRequest($"/api/Seguranca/CadastrarUsuario", Method.Post);

               var dadosJ = JsonConvert.SerializeObject(dados);

                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(dados);

                var response = await client.ExecuteAsync(request);

            
            }catch(Exception ex) { throw new Exception(ex.Message); }

        }

        public async void EfetuarCadastroProduto(Produtos produto)
        {
            try
            {
                var request = new RestRequest($"/api/Produtos", Method.Post);

                var dadosJ = JsonConvert.SerializeObject(produto);

                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(dadosJ);

                var response = await client.ExecuteAsync(request);

            }
            catch(Exception ex) { throw new Exception(ex.Message); }

        }

        public async Task<List<Fornecedores>> RetornaFornecedores()
        {
            try
            {
                var request = new RestRequest("/api/Fornecedores", Method.Get);
                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful)
                    throw new Exception($"Erro ao buscar fornecedores: {response.StatusCode} - {response.ErrorMessage}");

                var fornecedores = JsonConvert.DeserializeObject<List<Fornecedores>>(response.Content);

                return fornecedores ?? new List<Fornecedores>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}

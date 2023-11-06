
using System.Text;
using MVC_Gimnsaio.Models;
using Newtonsoft.Json;

namespace MVC_Gimnsaio.Service
{
    public class APIServiceVisita : IAPIServiceVisita
    {
        private static string _baseURL;

        HttpClient httpClient = new HttpClient();



        public APIServiceVisita()
        {
            // AÃ±adir el archivo JSON al contenedor
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseURL = builder.GetSection("ApiSettings:BaseUrl").Value;

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<Visita> CreateVisita(Visita newVisita)
        {

            var json = JsonConvert.SerializeObject(newVisita);

            var newVisitaJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the API
            HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "api/Visita", newVisitaJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Visita visitaNueva = JsonConvert.DeserializeObject<Visita>(content);

                return visitaNueva;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<string> DeleteVisita(int idVisita)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "api/Visita/" + idVisita);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string mensaje = await response.Content.ReadAsStringAsync();

                return mensaje;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<List<Visita>> GetVisitas()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Visita");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Visita> visitas = JsonConvert.DeserializeObject<List<Visita>>(content);

                return visitas;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<List<Visita>> GetVisitasPorMiembro(int idMiembro)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "VisitasPorMiembro/" + idMiembro);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Visita> visitasDeUnMiembro = JsonConvert.DeserializeObject<List<Visita>>(content);

                return visitasDeUnMiembro;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<Visita> GetVisitaByID(int idVisita)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Visita/" + idVisita);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Visita visitaEncontrada = JsonConvert.DeserializeObject<Visita>(content);

                return visitaEncontrada;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public async Task<Visita> UpdateVisita(Visita newVisita, int idVisita)
        {

            var json = JsonConvert.SerializeObject(newVisita);

            var newVisitaJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the API
            HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Visita/" + idVisita, newVisitaJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Visita visitaModificada = JsonConvert.DeserializeObject<Visita>(content);

                return visitaModificada;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
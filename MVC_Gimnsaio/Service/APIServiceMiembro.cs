using System.Text;
using Newtonsoft.Json;
using System.Text;
using MVC_Gimnsaio.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Gimnsaio.Service
{
    public class APIServiceMiembro : IAPIServiceMiembro
    {
        private static string _baseURL;

        HttpClient httpClient = new HttpClient();



        public APIServiceMiembro()
        {
            // AÃ±adir el archivo JSON al contenedor
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseURL = builder.GetSection("ApiSettings:BaseUrl").Value;

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<Miembro> CreateMiembro(Miembro newMiembro)
        {

            var json = JsonConvert.SerializeObject(newMiembro);

            var newMiembroJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the API
            HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "api/Miembro", newMiembroJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Miembro miembroNuevo = JsonConvert.DeserializeObject<Miembro>(content);

                return miembroNuevo;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<string> DeleteMiembro(int idMiembro)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "api/Miembro/" + idMiembro);

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

        public async Task<List<Miembro>> GetMiembros()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Miembro");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Miembro> miembros = JsonConvert.DeserializeObject<List<Miembro>>(content);

                return miembros;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<Miembro> GetMiembroByID(int idMiembro)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Miembro/" + idMiembro);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Miembro miembroEncontrado = JsonConvert.DeserializeObject<Miembro>(content);

                return miembroEncontrado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public async Task<Miembro> UpdateMiembro(Miembro newMiembro, int idMiembro)
        {

            var json = JsonConvert.SerializeObject(newMiembro);

            var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the API
            HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Miembro/" + idMiembro, newProductJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Miembro miembroModificado = JsonConvert.DeserializeObject<Miembro>(content);

                return miembroModificado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
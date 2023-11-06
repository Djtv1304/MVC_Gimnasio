using System.Text;
using MVC_Gimnsaio.Models;
using Newtonsoft.Json;

namespace MVC_Gimnsaio.Service

{
    public class APIServicePago : IAPIServicePago
    {
        private static string _baseURL;

        HttpClient httpClient = new HttpClient();

        public APIServicePago()
        {
            // AÃ±adir el archivo JSON al contenedor
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseURL = builder.GetSection("ApiSettings:BaseUrl").Value;

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<Pago> CreatePago(Pago newPago)
        {

            var json = JsonConvert.SerializeObject(newPago);

            var newPagoJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the API
            HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "api/Pago", newPagoJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Pago pagoNuevo = JsonConvert.DeserializeObject<Pago>(content);

                return pagoNuevo;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }





        public async Task<string> DeletePago(int idPago)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "api/Pago/" + idPago);

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

        public async Task<List<Pago>> GetPagos()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Pago");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Pago> pagos = JsonConvert.DeserializeObject<List<Pago>>(content);

                return pagos;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<List<Pago>> GetPagosPorMiembro(int idMiembro)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "PagosPorMiembro/" + idMiembro);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Pago> pagosDeUnMiembro = JsonConvert.DeserializeObject<List<Pago>>(content);

                return pagosDeUnMiembro;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<Pago> GetPagoByID(int idPago)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Pago/" + idPago);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Pago pagoEncontrado = JsonConvert.DeserializeObject<Pago>(content);

                return pagoEncontrado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public async Task<Pago> UpdatePago(Pago newPago, int idPago)
        {

            var json = JsonConvert.SerializeObject(newPago);

            var newPagoJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the API
            HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Pago/" + idPago, newPagoJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Pago pagoModificado = JsonConvert.DeserializeObject<Pago>(content);

                return pagoModificado;
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
    }
}
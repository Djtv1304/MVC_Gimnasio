using Newtonsoft.Json;
using System.Text;
using MVC_Gimnsaio.Models;
using Newtonsoft.Json;
using System.Text;
using MVC_Gimnsaio.Service;

public class APIServiceMembresia : IAPIServiceMembresia
{
    private static string _baseURL;

    HttpClient httpClient = new HttpClient();

    public APIServiceMembresia()
    {

        // Añadir el archivo JSON al contenedor
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _baseURL = builder.GetSection("ApiSettings:BaseUrl").Value;
        httpClient.BaseAddress = new Uri(_baseURL);

    }

    public async Task<List<Membresia>> GetMembresia()
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Membresia");

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Membresia> membresias = JsonConvert.DeserializeObject<List<Membresia>>(content);

            return membresias;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> CreateMembresia(Membresia newMembresia)
    {

        var json = JsonConvert.SerializeObject(newMembresia);

        var newMembresiaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the API
        HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "api/Membresia", newMembresiaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Membresia objects
            Membresia membresiaNueva = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaNueva;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> GetMembresiaByID(int idMembresia)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Membresia/" + idMembresia);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Membresia membresiaEncontrada = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaEncontrada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> UpdateMembresia(Membresia newMembresia, int idMembresia)
    {

        var json = JsonConvert.SerializeObject(newMembresia);
        var newMembresiaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a PUT request to the API
        HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Membresia/" + idMembresia, newMembresiaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Membresia membresiaModificada = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaModificada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }


    public async Task<string> DeleteMembresia(int idMembresia)
    {
        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "api/Membresia/" + idMembresia);

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

    // 3 Métodos del final adicionales de la API Membresía

    public async Task<List<Miembro>> GetMiembrosDeUnaMembresia(int idMembresia)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/MiembrosDeUnaMembresia/" + idMembresia);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Miembro> miembrosDeUnaMembresia = JsonConvert.DeserializeObject<List<Miembro>>(content);

            return miembrosDeUnaMembresia;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<string> RenovarMembresia(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/RenovarMembresia/" + idMiembro);

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

    public async Task<string> CancelarMembresia(int idMiembro)
    {
        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/EliminarMembresia/" + idMiembro);

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

}


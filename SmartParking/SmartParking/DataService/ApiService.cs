using Newtonsoft.Json;
using SmartParking.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.DataService
{
    
    public class ApiService
    {
        private HttpClient client;

        private static ApiService instance;
        private string URL = "https://smartparkingec.000webhostapp.com/index.php/RestServer";
        public ApiService()
        {
            client = new HttpClient();
        }

        public static ApiService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiService();
                }
                return instance;
            }
        }

        public async Task<List<CentralEmergencia>> GetCentralesEmergencia()
        {

            List<CentralEmergencia> centralEmergencias = new List<CentralEmergencia>();
            HttpResponseMessage response = client.GetAsync(URL + "/obtenerCentralEmergenciaTodos").Result;

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = response.Content.ReadAsStringAsync().Result;
            //centralEmergencias = JsonConvert.DeserializeObject<List<CentralEmergencia>>(content);
            return JsonConvert.DeserializeObject<List<CentralEmergencia>>(content);
        }

        public async Task<Usuario> PostLogin(Usuario usuario)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL + "/login", stringContent).Result;
            
            if (!response.IsSuccessStatusCode)
            {               
                return null;
            }

            string content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Usuario>(content);
        }

        public async Task<bool> PostAlerta(Alerta alerta)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(alerta), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL + "/registro_alerta", stringContent).Result;

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            string content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<Usuario> PostUsuarioRegistro(Usuario usuario)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL + "/registro", stringContent).Result;
            
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Usuario>(content);
        }

    }
}

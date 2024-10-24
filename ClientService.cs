using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeveloperAssessment
{
    public class ClientService
    {
        private const string FilePath = "clients.json";

        public void SaveClient(Client client)
        {
            var clients = LoadClients();
            clients.Add(client);
            SaveClients(clients);
        }
        public List<Client> LoadClients()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Client>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
        }

        private void SaveClients(List<Client> clients)
        {
            var json = JsonSerializer.Serialize(clients);
            File.WriteAllText(FilePath, json);
        }
    }
}

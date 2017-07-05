using MonitoringScosse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace MonitoringScosse.Data
{
    public class DataAccess : IDataAccess
    {
        private string connectionString;
        public DataAccess(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public bool isWorking(int id)
        {
            string url = "https://pw2017b.mvlabs.it/check/" + id;
            Stazione stazione;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(url);

                stazione = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Stazione>(response.Result)).Result;
            }

            return stazione.Working; 

        }
        public void Insert(Misurazione misurazione)
        {
            if (isWorking(misurazione.IdStazione))
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    connection.Query($@"
INSERT INTO Misurazioni(DataOra, SpostamentoX, SpostamentoY, SpostamentoZ, IdStazione)
VALUES('{misurazione.DataOra}', {misurazione.SpostamentoX}, {misurazione.SpostamentoY}, {misurazione.SpostamentoZ}, {misurazione.IdStazione})");
                }
            }
        }

        public IEnumerable<Misurazione> GetAll()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                return connection.Query<Misurazione>(@"
SELECT * FROM Misurazioni");
            }
        }
    }
}

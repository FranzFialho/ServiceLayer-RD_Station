using Newtonsoft.Json;
using ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Http
{
    public sealed class RDStationHttp
    {
        public static HttpClient clientRD = new HttpClient();

        public static async Task<HttpClient> PostOrganizations(string cardName, string cardCode, string Address)
        {
            try
            {
                //Criar um JSON para enviar a requisição
                var dados = new RDStation
                {
                    token = "MY_TOKENNN",
                    organization = new Organization
                    {
                        name = cardName,
                        user_id = "MY_USER_ID",
                        resume = "Integração SAP x RDStation",
                        organization_segments = new List<string>
                    {
                        "Tecnologia",
                        "Agropecuária"
                    },
                        organization_custom_fields = new List<OrganizationCustomField>()
                    {

                        new OrganizationCustomField
                        {
                            custom_field_id = "MY_ID_CUSTOM_FIELD",
                            value = cardName
                         },
                        new OrganizationCustomField
                        {
                            custom_field_id = "MY_ID_CUSTOM_FIELD",
                            value = cardCode
                        },
                        new OrganizationCustomField
                        {
                            custom_field_id = "MY_ID_CUSTOM_FIELD",
                            value = Address
                        }
                    }
                    }
                };

                var json = JsonConvert.SerializeObject(dados);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                await clientRD.PostAsync("https://plugcrm.net/api/v1/organizations", data);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Integrar dados na RDStation. " + ex.Message);
            }



            return clientRD;
        }

        public static async Task<HttpClient> GetOrganizations()
        {

            var result = await clientRD.GetAsync("https://plugcrm.net/api/v1/organizations?token=62693315cdcae1001d2d446a");

            Console.WriteLine(result);

            return clientRD;
        }

    }

}

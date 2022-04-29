using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Data;
using ServiceLayer.Model;
using ServiceLayer.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnersController : ControllerBase
    {

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessPartner>>> GetBusinessPartner()
        {
            dynamic GetBusinessPartners;
            try
            {

                GetBusinessPartners = await SL.Connection.Request("BusinessPartners").GetAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar todos os registros de parceiros de negócio. " + ex.Message);
            }


            return Ok(GetBusinessPartners);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessPartner>> GetBusinessPartner(string id)
        {
            dynamic GetIDBusinessPartners;
            try
            {
                GetIDBusinessPartners = await SL.Connection.Request("BusinessPartners", id).GetAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o registro do parceiros de negócio. " + ex.Message);
            }


            return Ok(GetIDBusinessPartners);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessPartner>> PostBusinessPartner(BusinessPartner businessPartner)
        {
            dynamic createdBp;
            try
            {

                createdBp = await SL.Connection.Request("BusinessPartners").PostAsync<BusinessPartner>(businessPartner);
                
                //Integração na RD Station
                await RDStationHttp.PostOrganizations(businessPartner.CardName, businessPartner.CardCode, businessPartner.Address);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao criar novo Parceiro de negócio. " + ex.Message);
            }


            return Ok(createdBp);
        }

    }
}

using B1SLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Data;
using ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        // GET: api/PedidoDeVendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
            dynamic GetAlloInvoice;
            try
            {
                GetAlloInvoice = await SL.Connection.Request("Invoices")
                                                .WithPageSize(3)
                                                .WithCaseInsensitive()
                                                .GetAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar notas fiscais. " + ex.Message);
            }

            return Ok(GetAlloInvoice);
        }

        // GET: api/PedidoDeVendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            dynamic GetIDoInvoice;

            try
            {
                GetIDoInvoice = await SL.Connection.Request("Invoices")
                                                .Filter($"DocNum eq {id}")
                                                .WithPageSize(10)
                                                .WithCaseInsensitive()
                                                .GetAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar notas fiscais. " + ex.Message);
            }

            return Ok(GetIDoInvoice);
        }


        // POST: api/PedidoDeVendas
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            dynamic createdInvoice;

            try
            {
                createdInvoice = await SL.Connection.Request("Invoices").PostAsync<Invoice>(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar uma nova nota fiscal. " + ex.Message);
            }

            return Ok(createdInvoice);
        }

    }
}

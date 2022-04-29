using B1SLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Data;
using ServiceLayer.Http;
using ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoDeVendasController : ControllerBase
    {


        // GET: api/PedidoDeVendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDeVenda>>> GetPedidoDeVenda()
        {
            dynamic order;
            try
            {
                order = await SL.Connection.Request("Orders")
                                        .WithPageSize(3)
                                        .WithCaseInsensitive()
                                        .GetAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar os Pedidos de Venda. " + ex.Message);
            }


            return Ok(order);
        }

        // GET: api/PedidoDeVendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDeVenda>> GetPedidoDeVenda(int id)
        {

            dynamic order;
            try
            {
                // Exemplo de Filtros
                //order = await loginSap.Request("Orders")
                //           .Filter($"DocNum eq {id}")
                //           .Select("CardCode, CardName")
                //           .OrderBy("CardName")
                //           .WithPageSize(10)
                //           .WithCaseInsensitive()
                //           .GetAsync();


                // Filtro pelo DocNum
                order = await SL.Connection.Request("Orders")
                                .Filter($"DocNum eq {id}")
                                .WithPageSize(10)
                                .WithCaseInsensitive()
                                .GetAsync();

       
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar pedido de venda. " + ex.Message);
            }

            return Ok(order);
        }


        // POST: api/PedidoDeVendas
        [HttpPost]
        public async Task<ActionResult<PedidoDeVenda>> PostPedidoDeVenda(PedidoDeVenda pedidoDeVenda)
        {
            dynamic createdOrder;
            try
            {
                createdOrder = await SL.Connection.Request("Orders").PostAsync<PedidoDeVenda>(pedidoDeVenda);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao gravar um novo pedido de venda. " + ex.Message);
            }


            return Ok(createdOrder);
        }

        //Exemplo de filtro para buscar dados nas linhas do documento.

        //   https:<SERVICELAYER>:50000/b1s/v1/$crossjoin(Orders,Orders/DocumentLines)
        //   ?$expand=Orders($select=DocEntry, DocNum),Orders/DocumentLines($select=ItemCode,LineNum)
        //   &$filter=Orders/DocEntry eq Orders/DocumentLines/DocEntry and Orders/DocumentLines/ItemCode eq 'A00001'




    }
}

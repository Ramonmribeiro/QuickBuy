using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
                //if (!true)
                //{
                //    return BadRequest("Olha só");
                //}
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            try
            {
                //var produto = new Produto();
                //produto.Nome = "";
                _produtoRepositorio.Adicionar(produto);
                return Created("api/prduto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

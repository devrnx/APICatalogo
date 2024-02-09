using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _context.Produtos.Select(x => new { x.ProdutoId, x.Nome, x.Preco });
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto model)
        {
            _context.Produtos.Add(model);
            return CreatedAtAction(nameof(model), GetById);
        }

        [HttpPut("{id}")]
        public IActionResult Update()
        {
            var produtos = _context.Produtos;
            return Ok(produtos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            var produtos = _context.Produtos;
            return Ok(produtos);
        }
    }
}
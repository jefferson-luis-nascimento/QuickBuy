using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProdutoController(IProdutoRepository produtoRepositorio,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                produto.Validate();

                if (!produto.EhValido)
                {
                    return BadRequest(produto.ObterMensagem());
                }

                _produtoRepositorio.Adicionar(produto);
                return Created("api/[controler]", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Atualizar(produto);
                return Created("api/[controler]", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                string nomeCompleto = ObterNomeArquivo(out IFormFile formFile);

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Json(Path.GetFileName(nomeCompleto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private string ObterNomeArquivo(out IFormFile formFile)
        {
            formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoSelecionado"];
            var nomeArquivo = formFile.FileName;
            var extensao = nomeArquivo.Split('.').Last();
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();

            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");

            novoNomeArquivo += DateTime.Now.ToString("yyyyMMddhhmmssfff") + "." + extensao;

            var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
            return pastaArquivos + novoNomeArquivo;
        }
    }
}

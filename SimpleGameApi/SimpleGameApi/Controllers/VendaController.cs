using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGameApi.Models.Domain.Contracts.Base;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase, 
                                   IGenericActionController<Venda, int>
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public ActionResult Add(Venda entity)
        {
            _vendaService.Add(entity);
            return Ok("Cadastro efetuado com sucesso!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string msg = "";
            var result = _vendaService.Delete(id);
            if (result)
                msg = "Exclusão efetuada com sucesso";
            else
                msg = "Exclusão não foi realizada, objeto não localizado";

            return Ok(msg);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _vendaService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _vendaService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Venda entity)
        {
            string msg = "";
            var result = _vendaService.Update(entity);
            if (result)
                msg = "Atualização efetuada com sucesso";
            else
                msg = "Atualização não foi realizada, objeto não localizado";

            return Ok(msg);
        }
    }
}

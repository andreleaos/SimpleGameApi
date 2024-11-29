using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGameApi.Models.Domain.Contracts.Base;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase,
        IGenericActionController<Estoque, int>
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpPost]
        public ActionResult Add(Estoque entity)
        {
            _estoqueService.Add(entity);
            return Ok("Cadastro realizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string msg = "";
            var result = _estoqueService.Delete(id);
            if (result)
                msg = "Exclusão efetuada com sucesso!";
            else
                msg = "Exclusão não foi realizada, objeto não localizado";

            return Ok(msg);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _estoqueService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _estoqueService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Estoque entity)
        {
            string msg = "";
            var result = _estoqueService.Update(entity);
            if (result)
                msg = "Atualização efetuada com sucesso!";
            else
                msg = "Atualização não foi realizada, objeto não localizado";

            return Ok(msg);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGameApi.Models.Domain.Contracts.Base;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase, 
                                     IGenericActionController<Aluguel, int>
    {
        private readonly IAluguelService _aluguelService;

        public AluguelController(IAluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        [HttpPost]
        public ActionResult Add(Aluguel entity)
        {
            _aluguelService.Add(entity);
            return Ok("Cadastro efetuado com sucesso!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string msg = "";
            var result = _aluguelService.Delete(id);
            if (result)
                msg = "Exclusão efetuada com sucesso";
            else
                msg = "Exclusão não foi realizada, objeto não localizado";

            return Ok(msg);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _aluguelService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _aluguelService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Aluguel entity)
        {
            string msg = "";
            var result = _aluguelService.Update(entity);
            if (result)
                msg = "Atualização efetuada com sucesso";
            else
                msg = "Atualização não foi realizada, objeto não localizado";

            return Ok(msg);
        }
    }
}

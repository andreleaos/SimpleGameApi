using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGameApi.Models.Domain.Contracts.Base;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;
using static Dapper.SqlMapper;

namespace SimpleGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase, IGenericActionController<Jogo, int>
    {
        private IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpPost]
        public ActionResult Add(Jogo entity)
        {
            _jogoService.Add(entity);
            return Ok("Cadastro efetuado com sucesso para o jogo: " + entity.Nome);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string msg = "";
            var result = _jogoService.Delete(id);

            if (result)
                msg = "Exclusão efetuada com sucesso";
            else
                msg = "Exclusão não foi realizada, jogo não localizado";

            return Ok(msg);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result =  _jogoService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _jogoService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Jogo entity)
        {
            string msg = "";
            var result = _jogoService.Update(entity);

            if (result)
                msg = "Atualização efetuada com sucesso";
            else
                msg = "Atualização não foi realizada, jogo não localizado";

            return Ok(msg);
        }
    }
}

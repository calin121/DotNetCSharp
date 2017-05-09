using Microsoft.AspNetCore.Mvc;

namespace PokeInfo
{
    public class PokeController : Controller
    {
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult GetInfo(int id)
        {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }
}
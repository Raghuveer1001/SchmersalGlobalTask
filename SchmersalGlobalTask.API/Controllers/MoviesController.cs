using Microsoft.AspNetCore.Mvc;
using SchmersalGlobalTask.Contracts;
using SchmersalGlobalTask.Services.Abstraction;

namespace SchmersalGlobalTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager _servicesManager;

        public MoviesController(IServiceManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        [Route("GetMovies")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var movies = await _servicesManager.MovieSrvc.GetMovieAllAsync();
                if (movies == null)
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("GetMovie")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var movie = await _servicesManager.MovieSrvc.GetMovieByIdAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetByGenre")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string genre)
        {
            try
            {
                var movie = await _servicesManager.MovieSrvc.GetMovieByGenreAsync(genre);
                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _servicesManager.MovieSrvc.CreateMovieAsync(dto);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public  async Task<IActionResult> Put(int id, [FromBody] MovieDTO dto)
        {
            /*Here id is not used if developer create different UpdateDTO  which contains only 
             required properties to be update that id can be used 
             */
            try
            {
                var result = await _servicesManager.MovieSrvc.UpdateMovieAsync(dto);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var result = await _servicesManager.MovieSrvc.DeleteMovieAsync(id);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
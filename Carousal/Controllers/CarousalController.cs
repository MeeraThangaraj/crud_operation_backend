using Carousal.BOs;
using Carousal.Helpers;
using Carousal.Services.CarousalServices;
using Microsoft.AspNetCore.Mvc;

namespace Carousal.Controllers
{
    [ApiController]
    public class CarousalController : Controller
    {

        private ICarousalServices _CarousalServices;
        public CarousalController(ICarousalServices carousalServices)
        {
            _CarousalServices = carousalServices;
        }
        [HttpPost]
        [Route("/api/data/AddCarousal")]
        public async Task<IActionResult> AddCarousal([FromBody] CarousalBO carousal)
        {
            try
            {

                #region Service Invocation
                var response = _CarousalServices.AddCarousal(carousal);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/data/GetAllCarousalData")]
        public async Task<IActionResult> GetAllCarousalData()
        {
            try
            {
                #region Service Invocation
                var response = _CarousalServices.GetAllCarousalData();
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("/api/data/DeleteCarousal")]
        public async Task<IActionResult> DeleteCarousal([FromQuery] int Id)
        {
            try
            {
                #region Service Invocation
                var response = _CarousalServices.DeleteCarousal(Id);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("/api/data/UpdateCarousal")]
        public async Task<IActionResult> UpdateCarousal([FromBody] CarousalBO carousal)
        {
            try
            {

                #region Service Invocation
                var response = _CarousalServices.UpdateCarousal(carousal);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/data/FetchOneCarousalData")]
        public async Task<IActionResult> FetchOneCarousalData([FromQuery] int Id)
        {
            try
            {
                #region Service Invocation
                var response = _CarousalServices.FetchOneCarousalData(Id);
                #endregion

                #region Response Handling
                if (response.Status == ServiceStatus.Success)
                {
                    return Ok(response.Content);
                }
                else if (response.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = response.Message });
                }
                else
                {
                    return StatusCode(500, new { message = response.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}

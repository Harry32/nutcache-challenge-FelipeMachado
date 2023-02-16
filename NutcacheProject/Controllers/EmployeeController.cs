using AutoMapper;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NutcacheProject.DTOs;

namespace NutcacheProject.Controllers
{
    [ApiController]
    [Route("/")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        private IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = mapper.Map<List<EmployeeResponse>>(await employeeService.GetAll());

            return Ok(employees);
        }

        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var employee = mapper.Map<EmployeeResponse>(await employeeService.Get(id));

            return Ok(employee);
        }

        [HttpPost]
        [Route("/")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertAsync([FromForm]EmployeeRequest employee)
        {
            if (ModelState.IsValid)
            {
                if (await employeeService.Insert(mapper.Map<Domain.Entities.Employee>(employee)))
                {
                    return NoContent();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] EmployeeRequest employee)
        {
            if (ModelState.IsValid)
            {
                if (await employeeService.Update(mapper.Map<Domain.Entities.Employee>(employee)))
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if(await employeeService.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
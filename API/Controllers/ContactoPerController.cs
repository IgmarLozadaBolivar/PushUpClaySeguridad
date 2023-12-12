using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ContactoPerController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ContactoPerController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactoPerDto>> Get(int id)
    {
        var data = await unitOfWork.ContactoPers.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<ContactoPerDto>(data);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactoPerDto>>> Get()
    {
        var data = await unitOfWork.ContactoPers.GetAllAsync();
        return mapper.Map<List<ContactoPerDto>>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ContactoPerDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.ContactoPers.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<ContactoPerDto>>(datos.registros);
        return new Pager<ContactoPerDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactoPerDto>> Post(ContactoPerDto dataDto)
    {
        var data = mapper.Map<ContactoPer>(dataDto);
        unitOfWork.ContactoPers.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        dataDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = dataDto.Id }, dataDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactoPerDto>> Put(int id, [FromBody] ContactoPerDto dataDto)
    {
        if (dataDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<ContactoPer>(dataDto);
        unitOfWork.ContactoPers.Update(data);
        await unitOfWork.SaveAsync();
        return dataDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.ContactoPers.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.ContactoPers.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("ContactoEmpleadoVigilante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ContactoEmpleadoVigilante()
    {
        var data = await unitOfWork.ContactoPers.ContactoEmpleadoVigilante();
        return mapper.Map<List<object>>(data);
    }
}
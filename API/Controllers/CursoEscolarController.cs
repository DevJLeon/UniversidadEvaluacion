using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class CursoEscolarController : ApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public CursoEscolarController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
    {
        var entidad = await unitofwork.CursoEscolares.GetAllAsync();
        return mapper.Map<List<CursoEscolarDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CursoEscolarDto>> Get(int id)
    {
        var entidad = await unitofwork.CursoEscolares.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<CursoEscolarDto>(entidad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolar>> Post(CursoEscolarDto entidadDto)
    {
        var entidad = this.mapper.Map<CursoEscolar>(entidadDto);
        this.unitofwork.CursoEscolares.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody]CursoEscolarDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<CursoEscolar>(entidadDto);
        unitofwork.CursoEscolares.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.CursoEscolares.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.CursoEscolares.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    
    [HttpGet("Consulta24")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Object>>> Consulta24()
    {
        var cursosEscolares = await unitofwork.CursoEscolares.Consulta24();
        return Ok(cursosEscolares);
    }
}
using BE_CRUDMascotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BE_CRUDMascotas.Models.DTO;
using BE_CRUDMascotas.Models.Repository;

namespace BE_CRUDMascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaController( IMapper mapper,IMascotaRepository mascotaRepository)
        {
           
            _mapper = mapper;
            _mascotaRepository = mascotaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listMascotas = await _mascotaRepository.GetListMascotas();
                //Mapper inyecciond de dependencias 
                //IEnumerable Lista
                var listMascotaDTO = _mapper.Map<IEnumerable<MascotaDTO>>(listMascotas);
                return Ok(listMascotaDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound();
                }

                var mascotaDTO = _mapper.Map<MascotaDTO>(mascota);
                return Ok(mascotaDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> borrar(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound();
                }
                else
                {
                    _mascotaRepository.DeleteMascota(mascota);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMascota(MascotaDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);
                mascota.FechaCreacion = DateTime.Now;
                mascota = await _mascotaRepository.AddMacota(mascota);

                var mascotaRetorno = _mapper.Map<MascotaDTO>(mascota);
                return CreatedAtAction("Get", new { id = mascotaRetorno.Id }, mascotaRetorno);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, MascotaDTO mascotaDto)
        {
            try
            {
                var EditarMascota = await _mascotaRepository.GetMascota(id);
                var mascota = _mapper.Map<Mascota>(mascotaDto);
                if (EditarMascota != null)
                {
                    EditarMascota.Nombre = mascota.Nombre;
                    EditarMascota.Raza = mascota.Raza;
                    EditarMascota.Color = mascota.Color;
                    EditarMascota.Nombre = mascota.Nombre;
                    EditarMascota.Peso = mascota.Peso;
                    EditarMascota.Edad = mascota.Edad;
                    EditarMascota= await _mascotaRepository.UpdateMascota(EditarMascota);
                }
                var MascotaRetorno = _mapper.Map<MascotaDTO>(EditarMascota);
                return Ok(EditarMascota);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

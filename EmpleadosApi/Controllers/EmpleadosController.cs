using EmpleadosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EmpleadosApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly BdEmpleados903Context _baseDatos;



        public EmpleadosController(BdEmpleados903Context baseDatos)
        {
            _baseDatos = baseDatos;
        }

        //metodo get ListaEMPLEADO  

        [HttpGet]
        [Route("ListaEmp")]

        public async Task<IActionResult> Lista()
        {
            var listaTareas = await
                _baseDatos.Empleados.ToListAsync();
            return Ok(listaTareas);

        }
        //Metodo Post Agregarempleado
        [HttpPost]
        [Route("AgregarEmp")]

        public async Task<IActionResult> Agregar([FromBody]
        Empleado request)
        {
            await _baseDatos.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok();

        }



        //modificar empleado

        [HttpPut]
        [Route("modificarEmp/{id:Int}")]

        public async Task<IActionResult> Modificar(int id, [FromBody] Empleado request)
        {

            var EmpModificar = await _baseDatos.Empleados.FindAsync(id);


            if (EmpModificar == null)
            {
                return BadRequest("No existeel empleado");
            }
            EmpModificar.Nombre = request.Nombre;

            try
            {
                await _baseDatos.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return NotFound();

            }

            return Ok();

        }


        // metodo delete EliminarTarea
        [HttpDelete]
        [Route("EliminarEmp/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var EmpEliminar= await
                _baseDatos.Empleados.FindAsync(id);

            if (EmpEliminar == null)
            {
                return BadRequest("No existe el empleado");



            }

            _baseDatos.Empleados.Remove(EmpEliminar);
            await _baseDatos.SaveChangesAsync();
            return Ok();





        }


    }
}

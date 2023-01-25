using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosEF2023.Models;
using MvcCrudDepartamentosEF2023.Repositories;

namespace MvcCrudDepartamentosEF2023.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        //MOSTRAMOS TODOS LOS DEPARTAMENTOS
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        //CREAMOS UNA VISTA LLAMADA DETALLES PARA LOS DETALLES 
        //DE UN DEPARTAMENTO
        public IActionResult Detalles(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        //VAMOS A TENER UNA VISTA PARA INSERTAR UN DEPARTAMENTO
        //CUANDO PULSE UN BOTON.  NECESITAMOS UN POST
        //QUE RECIBIRA EL PROPIO DEPARTAMENTO A INSERTAR
        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(Departamento dept)
        {
            this.repo.InsertDepartamento(dept.IdDepartamento
                , dept.Nombre, dept.Localidad);
            //DESPUES DE INSERTAR, LO LLEVAMOS DE NUEVO AL LISTADO
            return RedirectToAction("Index");
        }

        //CREAMOS UNA VISTA PARA MODIFICAR.  NECESITAMOS RECIBIR EL ID
        //DEL DEPARTAMENTO A MODIFICAR PARA DIBUJAR SUS DATOS EN LAS CAJAS
        //POSTERIORMENTE MEDIANTE UN BOTON SE REALIZA LA MODIFICACION
        public IActionResult Update(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Update(Departamento dept)
        {
            this.repo.UpdateDepartamento(dept.IdDepartamento
                , dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        //TENDREMOS UNA ACCION PARA ELIMINAR UN DEPARTAMENTO
        //EN ESTE CASO NO TENDREMOS NINGUNA VISTA PARA PRESENTAR
        //SIMPLEMENTE RECIBIMOS EL ID DEL DEPARTAMENTO A ELIMINAR
        //Y VOLVEMOS A MOSTRAR EL LISTADO DE DEPARTAMENTOS
        public IActionResult Delete(int id)
        {
            this.repo.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }
    }
}

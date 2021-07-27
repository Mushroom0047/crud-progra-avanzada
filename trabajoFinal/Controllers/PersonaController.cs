using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabajoFinal.Models;
using Biblioteca;
using System.Windows;

namespace trabajoFinal.Controllers {
    public class PersonaController : Controller {
        Operacion op = new Operacion();
        string usuarioActual = "";

        // GET: Persona
        public ActionResult Listado() {            
            List<Persona> Listado = op.ListarPersonas();
            if (Listado != null) {                
                return View(Listado);
                
            } else {
                return Content("No existe");
            }
            
        }

        [HttpGet]
        public ActionResult Edit(string rut) {
            Persona p = op.getPersonaByRut(rut);
            if (p !=null) {
                return View(p);
            } else {
                return Content("no se llama");
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formulario) {          
            if (formulario != null) {
                string rut, nombre, apellido, titulo;
                int edad;

                rut = formulario["rut"].ToString();
                nombre = formulario["nombre"].ToString();
                apellido = formulario["apellido"].ToString();
                titulo = formulario["titulo"].ToString();
                edad = int.Parse(formulario["edad"]);

                if(op.ModificarPersona(rut, nombre, apellido, titulo, edad)) {
                    MessageBox.Show("Modificado correctamente", "Alerta", MessageBoxButton.OK);
                    return RedirectToAction("Listado");
                } else {                    
                    return Content("Error al modificar !");
                }
                
            } else {
                MessageBox.Show("No existe el rut", "Error", MessageBoxButton.OK);
                return Content("No existe el rut");
            }
            //return RedirectToAction("Listado");
        }

        [HttpGet]
        public ActionResult Details(string rut) {
            Persona p = op.getPersonaByRut(rut);
            if (p != null) {
                return View(p);
            } else {
                return Content("no se llama");
            }
        }


        [HttpGet]
        public ActionResult Delete(string rut) {
            Persona p = op.getPersonaByRut(rut);
            if (p != null) {
                return View(p);
            } else {
                return Content("no se llama");
            }
        }

        [HttpPost]
        public ActionResult Delete(string rut, string confirmacion) {
            if (op.eliminarPersona(rut)) {
                MessageBox.Show("Registro eliminado correctamente !", "Alerta", MessageBoxButton.OK);
                return RedirectToAction("Listado");
            } else {
                return Content("error");
            }
        }

        [HttpPost]
        public ActionResult Create(FormCollection formulario) {
            if (formulario != null) {               
                string rut, nombre, apellido, titulo;
                int edad;                
                
                rut = formulario["rut"].ToString();
                nombre = formulario["nombre"].ToString();
                apellido = formulario["apellido"].ToString();
                titulo = formulario["titulo"].ToString();
                edad = int.Parse(formulario["edad"]);

                if (op.InsertPersona(rut, nombre, apellido, titulo, edad)) {
                    MessageBox.Show("Agregado !", "Alerta", MessageBoxButton.OK);
                    return RedirectToAction("Listado");
                } else {
                    return Content("error");
                }
                
            } else {
                return Content("No existe el rut");
            }                      
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formulario) {
            if (formulario != null) {
                if(op.login(formulario["usuario"].ToString(), formulario["password"].ToString())) {
                    usuarioActual = formulario["usuario"].ToString();
                    return RedirectToAction("Listado");
                } else {
                    MessageBox.Show("los datos no coinciden", "Alerta", MessageBoxButton.OK);
                    return View();
                }
            } else {
                return Content("error");
            }
        }

        [HttpGet]
        public ActionResult Registrarse() {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(FormCollection formulario) {
            if (formulario != null) {

                string usuario = formulario["usuario"].ToString();
                string password = formulario["password"].ToString();               

                if (op.InsertUsuario(usuario, password)) {
                    MessageBox.Show("Agregado !", "Alerta", MessageBoxButton.OK);
                    return RedirectToAction("Login");
                } else {
                    return Content("error");
                }

            } else {
                return Content("No existe el rut");
            }
        }
    }
}
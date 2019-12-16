using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LugoTechCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace LugoTechCrud.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(_context.Usuarios.ToList());
        }
        //Get/User/Create
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios model)
        {
            
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuarios.Where(u => u.NombreUsuario == model.NombreUsuario);
                
                if (usuario.Any()) {
                    if(usuario.Where(u=> u.Contra == model.Contra).Any())
                    {
                        
                        return Json(new { status = true, Message = "Sesion Iniciada" });
                    }
                    else
                    {
                        return Json(new { status = false, Message = "Contraseña incorrecta"});
                    }
                }
                else
                {
                    return Json(new { status = false, Message = "Usuario no existe" });
                }
                
            }
            return View(model);
        }
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Usuarios());
            }
            else
            {
                return View(_context.Usuarios.Find(id));
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit([Bind("Id", "Nombres", "Apellidos", "NombreUsuario", "Contra", "Genero", "Nacionalidad","TipoUsuario", "Estado")] Usuarios user)
        {
            if (ModelState.IsValid)
            {
                if(user.Id == 0)
                {
                    user.TipoUsuario = 2;
                    _context.Add(user);
                }
                else
                {
                    _context.Update(user);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);

        }

        public async Task<IActionResult> ActivateOrDeactivate(Usuarios usuario)
        {
            
            var usuarioB = _context.Usuarios.Find(usuario.Id);
            if (usuarioB.Id != 0)
            {
                usuarioB.Estado = !(usuarioB.Estado);
                _context.Usuarios.Update(usuarioB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            return View(usuarioB);
        }

    }
}

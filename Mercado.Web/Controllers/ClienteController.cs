using Mercado.Domain.Entities;
using Mercado.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MercadoDbContext _db;

        public ClienteController(MercadoDbContext db)
        {
            _db = db;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            return View(_db.Cliente.ToList());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View(ObterIdCliente(id));
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                _db.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ObterIdCliente(id));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente clienteNovo)
        {
            var clienteVelho = ObterIdCliente(id);
            try
            {
                clienteVelho.NomeCliente = clienteNovo.NomeCliente;
                clienteVelho.Telefone = clienteNovo.Telefone;
                clienteVelho.Email = clienteNovo.Email;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ObterIdCliente(id));
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cliente)
        {
            var clienteExiste = ObterIdCliente(id);
            try
            {
                _db.Remove(clienteExiste);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Cliente ObterIdCliente(int id)
        {
            return _db.Cliente.Find(id);
        }
    }
}

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
    public class ProdutoController : Controller
    {
        private readonly MercadoDbContext _db;

        public ProdutoController(MercadoDbContext db)
        {
            _db = db;
        }

        // GET: PedidoController
        public ActionResult Index()
        {
            return View(_db.Produto.ToList());
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View(ObterIdProduto(id));
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                _db.Add(produto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ObterIdProduto(id));
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produto produtoNovo)
        {
            var produtoVelho = ObterIdProduto(id);
            try
            {
                produtoVelho.NomeProduto = produtoNovo.NomeProduto;
                produtoVelho.Setor = produtoNovo.Setor;
                produtoVelho.Marca = produtoNovo.Marca;
                produtoVelho.Valor = produtoNovo.Valor;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ObterIdProduto(id));
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produto produto)
        {
            var produtoExiste = ObterIdProduto(id);
            try
            {
                _db.Remove(produtoExiste);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Produto ObterIdProduto(int id)
        {
            return _db.Produto.Find(id);
        }
    }
}

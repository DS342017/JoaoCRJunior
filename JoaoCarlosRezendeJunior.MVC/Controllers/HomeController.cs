using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using JoaoCarlosRezendeJunior.MVC.Models;
using System.Collections.Generic;
using System;

namespace JoaoCarlosRezendeJunior.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient
                .GetAsync(_httpClient.BaseAddress + $"pedidos");

            return View(await response.Content.ReadAsAsync<IEnumerable<PedidoViewModel>>());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await _httpClient
                .GetAsync(_httpClient.BaseAddress + $"pedidos/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return View(await response.Content.ReadAsAsync<PedidoViewModel>());
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,NomeMedicamento,QtdeMedicamento,DataEntrega,CodCliente")] PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                await _httpClient
                    .PostAsJsonAsync(_httpClient.BaseAddress + $"pedidos", pedido);
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await _httpClient
                .GetAsync(_httpClient.BaseAddress + $"pedidos/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return View(await response.Content.ReadAsAsync<PedidoViewModel>());
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,NomeMedicamento,QtdeMedicamento,DataEntrega,CodCliente")] PedidoViewModel pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _httpClient
                        .PutAsJsonAsync(_httpClient.BaseAddress + $"pedidos/{id}", pedido);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await _httpClient
                .GetAsync(_httpClient.BaseAddress + $"pedidos/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return View(await response.Content.ReadAsAsync<PedidoViewModel>());
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient
                .DeleteAsync(_httpClient.BaseAddress + $"pedidos/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregarAdventureWorksMVCEntityFrameworks.Models;
using EntregarAdventureWorksMVCEntityFrameworks.ViewModel;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace EntregarAdventureWorksMVCEntityFrameworks.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly AdventureWorks2016Context _context;

        public SalesOrderDetailsController(AdventureWorks2016Context context)
        {
            _context = context;
        }

        // GET: SalesOrderDetails
        public async Task<IActionResult> Index(int? page, int size = 500, int rango = 100)
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            int pageSize = size;
            int pageNumber = (page ?? 1);
            ViewBag.Size = size;
            ViewBag.Rango = rango;
            return View(adventureWorks2016Context.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> IndexFiltrado1()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            var Filtrado = from fila in adventureWorks2016Context
                where fila.ModifiedDate.Year == 2011 &&  fila.UnitPrice > 1000
                orderby fila.ModifiedDate, fila.SalesOrder
                select fila;
            return View(await Filtrado.ToListAsync());
        }

        public async Task<IActionResult> IndexFiltrado2()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            var Filtrado = from fila in adventureWorks2016Context
                where fila.ModifiedDate.Year == 2012 && fila.UnitPrice > 1000 && fila.ProductId > 800
                orderby fila.ModifiedDate, fila.SalesOrder
                           select fila;
            return View(await Filtrado.ToListAsync());
        }

        public async Task<IActionResult> IndexFiltrado3()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            var Filtrado = from fila in adventureWorks2016Context
                where fila.ModifiedDate.Year == 2013 && fila.UnitPrice > 1000 && fila.ProductId > 800 && fila.UnitPrice > 1500
                orderby fila.ModifiedDate, fila.SalesOrder
                           select fila;
            return View(await Filtrado.ToListAsync());
        }

        public async Task<IActionResult> IndexVista4(string color = "h", int page = 1, int size = 200, int rango = 50)
        {
            var JoinSalesOrderDetailProduct  = from product in _context.Product
                join sales in _context.SalesOrderDetail
                    on product.ProductId equals sales.ProductId
                where sales.OrderQty > 2 
                orderby product.Name, product.Color
                select new SalesOrderDetailProductJoinViewModel()
                {
                    Name = product.Name,
                    Color = product.Color,
                    SalesOrderId = sales.SalesOrderId,
                    SalesOrderDetailId = sales.SalesOrderDetailId,
                    CarrierTrackingNumber = sales.CarrierTrackingNumber,
                    OrderQty = sales.OrderQty,
                    ProductId = sales.ProductId,
                    SpecialOfferId = sales.SpecialOfferId,
                    UnitPrice = sales.UnitPrice,
                    UnitPriceDiscount = sales.UnitPriceDiscount,
                    LineTotal = sales.LineTotal,
                    Rowguid = sales.Rowguid,
                    ModifiedDate = sales.ModifiedDate,
                };
            ViewBag.Page = page;
            ViewBag.Size = size;
            ViewBag.Rango = rango;
            ViewBag.Color = color;
            int pagina = page;
            int tamano = size;
                var AgrupadoPorColor = from Venta in JoinSalesOrderDetailProduct.ToList()
                                   group Venta by Venta.Color into grupo
                select grupo;
            ViewBag.Totales = (JoinSalesOrderDetailProduct.Count() / size) + 1;
            return View(AgrupadoPorColor);
        }

        // GET: SalesOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail
                .Include(s => s.SalesOrder)
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderId");
            return View();
        }

        // POST: SalesOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesOrderId,SalesOrderDetailId,CarrierTrackingNumber,OrderQty,ProductId,SpecialOfferId,UnitPrice,UnitPriceDiscount,LineTotal,Rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesOrderId,SalesOrderDetailId,CarrierTrackingNumber,OrderQty,ProductId,SpecialOfferId,UnitPrice,UnitPriceDiscount,LineTotal,Rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (id != salesOrderDetail.SalesOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderDetailExists(salesOrderDetail.SalesOrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeader, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail
                .Include(s => s.SalesOrder)
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(id);
            if (salesOrderDetail != null)
            {
                _context.SalesOrderDetail.Remove(salesOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _context.SalesOrderDetail.Any(e => e.SalesOrderId == id);
        }
    }
}

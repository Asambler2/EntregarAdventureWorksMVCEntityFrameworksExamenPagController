using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregarAdventureWorksMVCEntityFrameworks.Models;
using PagedList;

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
        public async Task<IActionResult> Index(int? page)
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View( adventureWorks2016Context.ToPagedList(pageNumber, pageSize));
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

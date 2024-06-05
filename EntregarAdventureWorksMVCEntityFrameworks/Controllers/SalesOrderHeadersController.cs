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
    public class SalesOrderHeadersController : Controller
    {
        private readonly AdventureWorks2016Context _context;

        public SalesOrderHeadersController(AdventureWorks2016Context context)
        {
            _context = context;
        }

        // GET: SalesOrderHeaders
        public async Task<IActionResult> Index(int? page, int size = 200, int rango = 100)
        {
            int pageSize = size;
            int pageNumber = (page ?? 1);
            ViewBag.Size = size;
            return View(_context.SalesOrderHeader.ToPagedList(pageNumber, pageSize));
        }

        // GET: SalesOrderHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesOrderId,RevisionNumber,OrderDate,DueDate,ShipDate,Status,OnlineOrderFlag,SalesOrderNumber,PurchaseOrderNumber,AccountNumber,CustomerId,SalesPersonId,TerritoryId,BillToAddressId,ShipToAddressId,ShipMethodId,CreditCardId,CreditCardApprovalCode,CurrencyRateId,SubTotal,TaxAmt,Freight,TotalDue,Comment,Rowguid,ModifiedDate")] SalesOrderHeader salesOrderHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader.FindAsync(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }
            return View(salesOrderHeader);
        }

        // POST: SalesOrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesOrderId,RevisionNumber,OrderDate,DueDate,ShipDate,Status,OnlineOrderFlag,SalesOrderNumber,PurchaseOrderNumber,AccountNumber,CustomerId,SalesPersonId,TerritoryId,BillToAddressId,ShipToAddressId,ShipMethodId,CreditCardId,CreditCardApprovalCode,CurrencyRateId,SubTotal,TaxAmt,Freight,TotalDue,Comment,Rowguid,ModifiedDate")] SalesOrderHeader salesOrderHeader)
        {
            if (id != salesOrderHeader.SalesOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderHeaderExists(salesOrderHeader.SalesOrderId))
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
            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return View(salesOrderHeader);
        }

        // POST: SalesOrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderHeader = await _context.SalesOrderHeader.FindAsync(id);
            if (salesOrderHeader != null)
            {
                _context.SalesOrderHeader.Remove(salesOrderHeader);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return _context.SalesOrderHeader.Any(e => e.SalesOrderId == id);
        }
    }
}

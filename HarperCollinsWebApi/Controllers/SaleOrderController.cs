﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HarperCollinsWebApi.Data;
using HarperCollinsWebApi.Models;

namespace HarperCollinsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderController : ControllerBase
    {
        private readonly HarperCollinsWebApiDbContext _context;

        public SaleOrderController(HarperCollinsWebApiDbContext context)
        {
            _context = context;
        }

        /* GET: api/SaleOrder
                api/SaleOrder?titleId=1
                api/SaleOrder?customerId=1
                api/SaleOrder?customerId=10&releaseDate=05/01/2019
                api/SaleOrder?customerId=10&titleId=10&releaseDate=05/01/2019
        */
        [HttpGet]
        public IEnumerable<SaleOrder> GetSaleOrders(
            int customerId = 0,
            int titleId = 0,
            string releaseDate = "")
        {
            IQueryable<SaleOrder> query = _context.SaleOrders
                                            .Include(so => so.Customer)
                                            .Include(so => so.Title);

            if (customerId > 0)
            {
                query = query.Where(so => so.CustomerId.Equals(customerId));
            }

            if (titleId > 0)
            {
                query = query.Where(so => so.TitleId.Equals(titleId));
            }

            if (!string.IsNullOrEmpty(releaseDate))
            {
                DateTime parsedValue;

                if (!DateTime.TryParse(releaseDate, out parsedValue))
                {
                    parsedValue = DateTime.MinValue;
                }

                query = query.Where(so => so.ReleaseDate.Equals(parsedValue));
            }

            return query.ToList();
        }

        // GET: api/SaleOrder/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saleOrder = await _context.SaleOrders.FindAsync(id);

            if (saleOrder == null)
            {
                return NotFound();
            }

            return Ok(saleOrder);
        }

        // PUT: api/SaleOrder/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleOrder([FromRoute] int id, [FromBody] SaleOrder saleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saleOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SaleOrder
        [HttpPost]
        public async Task<IActionResult> PostSaleOrder([FromBody] SaleOrder saleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SaleOrders.Add(saleOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleOrder", new { id = saleOrder.Id }, saleOrder);
        }

        // DELETE: api/SaleOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saleOrder = await _context.SaleOrders.FindAsync(id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            _context.SaleOrders.Remove(saleOrder);
            await _context.SaveChangesAsync();

            return Ok(saleOrder);
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrders.Any(e => e.Id == id);
        }
    }
}
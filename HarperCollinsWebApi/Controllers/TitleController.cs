<<<<<<< HEAD
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
    public class TitleController : ControllerBase
    {
        private readonly HarperCollinsWebApiDbContext _context;

        public TitleController(HarperCollinsWebApiDbContext context)
        {
            _context = context;
        }

        /* GET: api/Title
                api/Title?isbn=9781404110380
                api/Title?title=THE GOWN
                api/Title?author=Jory
                api/Title?title=THE&author=john&isbn=9 */
        [HttpGet]
        public IEnumerable<Title> GetTitles(
            string isbn = "",
            string title = "",
            string author = "" )
        {
            IQueryable<Title> query = _context.Titles;

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query = query.Where(t => t.ISBN.Contains(isbn));
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(t => t.PublicationTitle.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(t => t.Author.Contains(author));
            }

            return query.ToList();
        }

        // GET: api/Title/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await _context.Titles.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/Title/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle([FromRoute] int id, [FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.Id)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        // POST: api/Title
        [HttpPost]
        public async Task<IActionResult> PostTitle([FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Titles.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // DELETE: api/Title/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();

            return Ok(title);
        }

        private bool TitleExists(int id)
        {
            return _context.Titles.Any(e => e.Id == id);
        }
    }
=======
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
    public class TitleController : ControllerBase
    {
        private readonly HarperCollinsWebApiDbContext _context;

        public TitleController(HarperCollinsWebApiDbContext context)
        {
            _context = context;
        }

        /* GET: api/Title
                api/Title?isbn=9781404110380
                api/Title?title=THE GOWN
                api/Title?author=Jory
                api/Title?title=THE&author=john&isbn=9 */
        [HttpGet]
        public IEnumerable<Title> GetTitles(
            string isbn = "",
            string title = "",
            string author = "" )
        {
            IQueryable<Title> query = _context.Titles;

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query = query.Where(t => t.ISBN.Contains(isbn));
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(t => t.PublicationTitle.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(t => t.Author.Contains(author));
            }

            return query.ToList();
        }

        // GET: api/Title/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await _context.Titles.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/Title/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle([FromRoute] int id, [FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.Id)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        // POST: api/Title
        [HttpPost]
        public async Task<IActionResult> PostTitle([FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Titles.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // DELETE: api/Title/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();

            return Ok(title);
        }

        private bool TitleExists(int id)
        {
            return _context.Titles.Any(e => e.Id == id);
        }
    }
>>>>>>> 170412e4236f2b2d23354ca322baa1af1e3afbce
}
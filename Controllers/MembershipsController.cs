﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demoDataFirst.Data;
using demoDataFirst.Models;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipsController : ControllerBase
    {
        private readonly DataContext _context;

        public MembershipsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Memberships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membership>>> GetMembership()
        {
            return await _context.Membership.ToListAsync();
        }

        // GET: api/Memberships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membership>> GetMembership(int id)
        {
            var membership = await _context.Membership.FindAsync(id);

            if (membership == null)
            {
                return NotFound();
            }

            return membership;
        }

        // PUT: api/Memberships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembership(int id, Membership membership)
        {
            if (id != membership.MembershipId)
            {
                return BadRequest();
            }

            _context.Entry(membership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExists(id))
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

        // POST: api/Memberships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Membership>> PostMembership(Membership membership)
        {
            _context.Membership.Add(membership);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembership", new { id = membership.MembershipId }, membership);
        }

        // DELETE: api/Memberships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            var membership = await _context.Membership.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }

            _context.Membership.Remove(membership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembershipExists(int id)
        {
            return _context.Membership.Any(e => e.MembershipId == id);
        }
    }
}

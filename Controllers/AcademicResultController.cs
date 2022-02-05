using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1262228_Arosh_NGJs.Data;
using _1262228_Arosh_NGJs.Models;
using Microsoft.EntityFrameworkCore;

namespace _1262228_Arosh_NGJs.Controllers
{
    [Route("AcademicResult")]
    [ApiController]
    public class AcademicResultController : ControllerBase
    {
        private NgDbContext _context = null;
        public AcademicResultController(NgDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicResult>>> GetAcademicresults()
        {
            return await _context.AcademicResults.ToListAsync();
        }

        // GET: api/academicresults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicResult>> Getacademicresult(int id)
        {
            var academicresult = await _context.AcademicResults.FindAsync(id);

            if (academicresult == null)
            {
                return NotFound();
            }

            return academicresult;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Putacademicresult(int id, AcademicResult academicresult)
        {
            if (id != academicresult.AcademicResultID)
            {
                return BadRequest();
            }

            _context.Entry(academicresult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!academicresultExists(id))
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

 
        [HttpPost]
        public async Task<ActionResult<AcademicResult>> Postacademicresult(AcademicResult academicresult)
        {
            _context.AcademicResults.Add(academicresult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getacademicresult", new { id = academicresult.AcademicResultID }, academicresult);
        }

  
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicResult>> Deleteacademicresult(int id)
        {
            var academicresult = await _context.AcademicResults.FindAsync(id);
            if (academicresult == null)
            {
                return NotFound();
            }

            _context.AcademicResults.Remove(academicresult);
            await _context.SaveChangesAsync();

            return academicresult;
        }

        private bool academicresultExists(int id)
        {
            return _context.AcademicResults.Any(e => e.AcademicResultID == id);
        }


    }
}
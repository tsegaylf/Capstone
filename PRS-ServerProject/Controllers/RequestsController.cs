using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_ServerProject.Model;

namespace PRS_ServerProject.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PRSCSContext _context;

        public RequestsController(PRSCSContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        private void GetRequestForReviewer(int userId) {
            var request = _context.Request.Find(userId);
            if (request == null) {
                throw new Exception("Instant must not be null");
            }
            _context.Request.Where(r => r.Status == "Review" && r.UserId != userId);
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Request.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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


        // PUT: api/
        [HttpPut("review {id}")]
        public async Task<IActionResult> PutStatusReview(int id) {
            var request = await _context.Request.FindAsync(id);
            if (request == null) { throw new Exception("No request with that ID."); }
            request.Status = "Review"; //Request with total <= are set to APPROVED
            _context.SaveChanges();
            return NoContent();
            //var success = Update(request);
            //if (!success) { throw new Exception("Request update failed!"); }
        }

        // PUT: api/
        [HttpPut("approve {id}")]
        public async Task<IActionResult> PutStatusApproved(int id) {
            var request = await _context.Request.FindAsync(id);
            if (request == null) { throw new Exception("No request with that ID."); }
            request.Status = "Approved"; //Request with total <= are set to APPROVED
            _context.SaveChanges();
            return NoContent();
        }

        // PUT: api/
        [HttpPut("reject {id}")]
        public async Task<IActionResult> PutStatusRejected(int id) {
            var request = await _context.Request.FindAsync(id);
            if (request == null) { throw new Exception("No request with that ID."); }
            request.Status = "Rejected"; //Request with total <= are set to APPROVED
            _context.SaveChanges();
            return NoContent();
        }


        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}

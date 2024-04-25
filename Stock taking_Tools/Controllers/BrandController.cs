using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock_taking_Tools.Models;

namespace ToolInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetTool()
        {
            return await _context.Tools.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Tool>> GetTool(int id)
        {
            var Tool = await _context.Tools.FindAsync(id);

            if (Tool == null)
            {
                return NotFound();
            }
            
            return Tool;
        }

        [HttpPost]
        public async Task<ActionResult<Tool>> AddTool(Tool Tool)
        {
            _context.Tools.Add(Tool);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTool), new { id = Tool.Id }, Tool);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTool(int id, Tool Tool)
        {
            if (id != Tool.Id)
            {
                return BadRequest();
            }
            _context.Entry(Tool).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            var Tool = await _context.Tools.FindAsync(id);

            if (Tool == null)

            {
                return NotFound();
            }

            _context.Tools.Remove(Tool);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentsManager.Models;

namespace AppointmentsManager.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
          if (_context.Appointments == null)
          {
              return NotFound();
          }
            return await _context.Appointments.Where(e=>!e.deleted && !e.Done).ToListAsync();
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
          if (_context.Appointments == null)
          {
              return NotFound();
          }
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

          //  _context.Entry(appointment).State = EntityState.Modified;

            try
            {

                Appointment Entry = await _context.Appointments.FirstAsync(e=> e.Id== appointment.Id);
                Entry.Title=appointment.Title;
                Entry.Description=appointment.Description;
                Entry.Time = appointment.Time;
                Entry.Address = appointment.Address;
                Entry.Date = appointment.Date;
                Entry.CreatedDate = appointment.CreatedDate;
                Entry.ModifiedDate = appointment.ModifiedDate;
                Entry.deleted = appointment.deleted;
                Entry.Done = appointment.Done;
                Entry.LevelOfImportance = appointment.LevelOfImportance;


                _context.Appointments.Update(Entry);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/Appointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
          if (_context.Appointments == null)
          {
              return Problem("Entity set 'AppDbContext.Appointments'  is null.");
          }
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> FiltredAppointment(Filter Filters )
        {
            List<Appointment> ALlData=await _context.Appointments.ToListAsync();
            if(Filters.All)
            {
                return ALlData;
            }
            if (Filters.LevelOfImportance != null)
            {
                 ALlData=ALlData.Where(e=> e.LevelOfImportance==Filters.LevelOfImportance).ToList();
            }
            if (Filters.SpecifiedDate != null)
            {
                ALlData = ALlData.Where(e => e.Date == Filters.SpecifiedDate).ToList();
            }

            return ALlData.Where(e => !e.deleted && !e.Done).ToList();



        }
        private bool AppointmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

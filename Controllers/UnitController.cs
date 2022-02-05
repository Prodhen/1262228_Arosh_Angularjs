using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1262228_Arosh_NGJs.Data;
using _1262228_Arosh_NGJs.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1262228_Arosh_NGJs.Controllers
{
    [Route("api/Unit"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class UnitController : Controller
    {

        private NgDbContext _ctx = null;
        public UnitController(NgDbContext context)
        {
            _ctx = context;
        }


        [HttpGet, Route("GetUnit")]
        public async Task<object> GetUnit()
        {
            List<Unit> units = null;
            //object result = null;
            try
            {
                using (_ctx)
                {
                    units = await _ctx.Units.ToListAsync();
                    //result = new
                    //{
                    //    Unit
                    //};
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return units;
        }

        // GET api/Values/GetUnitByID/5
        [HttpGet, Route("GetUnitByID/{id}")]
        public async Task<Unit> GetUnitByID(int id)
        {
            Unit unit = null;
            try
            {
                using (_ctx)
                {
                    unit = await _ctx.Units.FirstOrDefaultAsync(x => x.UnitID == id);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return unit;
        }


        // POST api/Values/PostUnit
        [HttpPost, Route("PostUnit")]
        public async Task<object> PostUnit([FromBody] Unit model)
        {
            object result = null; string message = "";
            if (model == null)
            {
                return BadRequest();
            }
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        _ctx.Units.Add(model);
                        await _ctx.SaveChangesAsync();
                        _ctxTransaction.Commit();
                        message = "Saved Successfully";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback();
                        e.ToString();
                        message = "Saved Error";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }

        // PUT api/Values/PutUnit/5
        [HttpPut, Route("PutUnit/{id}")]
        public async Task<object> PutUnit(int id, [FromBody] Unit model)
        {
            object result = null; string message = "";
            if (model == null)
            {
                return BadRequest();
            }
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var entityUpdate = _ctx.Units.FirstOrDefault(x => x.UnitID == id);
                        if (entityUpdate != null)
                        {
                            entityUpdate.UnitName = model.UnitName;
                            entityUpdate.Seat = model.Seat;


                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Entry Updated";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Entry Update Failed!!";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }

        // DELETE api/Values/DeleteUnitByID/5
        [HttpDelete, Route("DeleteUnitByID/{id}")]
        public async Task<object> DeleteUnitByID(int id)
        {
            object result = null; string message = "";
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var idToRemove = _ctx.Units.SingleOrDefault(x => x.UnitID == id);
                        if (idToRemove != null)
                        {
                            _ctx.Units.Remove(idToRemove);
                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Deleted Successfully";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Error on Deleting!!";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }
    }
}
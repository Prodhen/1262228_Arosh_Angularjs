using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Cors;
using _1262228_Arosh_NGJs.Models;
using _1262228_Arosh_NGJs.Data;
using Microsoft.EntityFrameworkCore;

namespace _1262228_Arosh_NGJs.Controllers
{
    [Route("api/Student"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class StudentController : Controller
    {

        private NgDbContext _ctx = null;


        public StudentController(NgDbContext context)
        {
            _ctx = context;
        }
        public async Task<ActionResult<IEnumerable<Student>>> GetAcademicresults()
        {
            return await _ctx.Students.ToListAsync();
        }

        // GET: api/Values/GetUser
        [HttpGet, Route("GetUser")]
        public async Task<object> GetUser()
        {
            List<Student> users = null;
            //object result = null;
            try
            {
                using (_ctx)
                {
                    users = await _ctx.Students.ToListAsync();
                    //result = new
                    //{
                    //    User
                    //};
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return users;
        }



        [HttpGet, Route("GetUnit")]
        public async Task<object> GetUnit()
        {
            List<Unit> unit = null;
            try
            {
                using (_ctx)
                {
                    unit = await _ctx.Units.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return unit;
        }



        [HttpGet, Route("GetStudentByID/{id}")]
        public async Task<Student> GetUserByID(int id)
        {
            Student student = null;
            try
            {
                using (_ctx)
                {
                    student = await _ctx.Students.FirstOrDefaultAsync(x => x.StudentID == id);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return student;
        }



        [HttpPost, Route("PostStudent")]
        public async Task<object> PostStudent([FromBody] Student student)
        {
            object result = null; string message = "";
            if (student == null)
            {
                return BadRequest();
            }
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        _ctx.Students.Add(student);
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


        [HttpPut, Route("PutStudent/{id}")]
        public async Task<object> PutUser(int id, [FromBody] Student student)
        {
            object result = null;
            string message = "";
            if (student == null)
            {
                return BadRequest();
            }
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var stu = _ctx.Students.FirstOrDefault(x => x.StudentID == id);
                        if (stu != null)
                        {
                            stu.Name = student.Name;
                            stu.FatherName = student.FatherName;
                            stu.MotherName = student.MotherName;
                            stu.UnitID = student.UnitID;
                            stu.Gender = student.Gender;
                            stu.DOB = student.DOB;
                            stu.Status = student.Status;
                            stu.Email = student.Email;

                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Updated";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Update Failed!";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }


        [HttpDelete, Route("DeleteStudentByID/{id}")]
        public async Task<object> DeleteUserByID(int id)
        {
            object result = null; string message = "";
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var idToRemove = _ctx.Students.SingleOrDefault(x => x.StudentID == id);
                        if (idToRemove != null)
                        {
                            _ctx.Students.Remove(idToRemove);
                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Deleted Successfully";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Error on Deleting!";
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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;


//using Microsoft.AspNetCore.Cors;
//using _1262228_Arosh_NGJs.Models;
//using _1262228_Arosh_NGJs.Data;
//using Microsoft.EntityFrameworkCore;

//namespace _1262228_Arosh_NGJs.Controllers
//{
//    [Route("api/Values"), Produces("application/json"), EnableCors("AppPolicy")]
//    [ApiController]
//    public class StudentController : Controller
//    {

//        private NgDbContext _ctx = null;
//        public StudentController(NgDbContext context)
//        {
//            _ctx = context;
//        }

//        public async Task<ActionResult<IEnumerable<Student>>> GetAcademicresults()
//        {
//            return await _ctx.Students.ToListAsync();
//        }


//        //public async Task<ActionResult<IEnumerable<Student>>> GetAcademicresults()
//        //{
//        //    return await _ctx.Students.ToListAsync();
//        //}



//        // GET: api/Values/GetBooks
//        [HttpGet, Route("GetBook")]
//        public async Task<object> GetBook()
//        {
//            List<Unit> book = null;
//            try
//            {
//                using (_ctx)
//                {
//                    book = await _ctx.Units.ToListAsync();
//                }
//            }
//            catch (Exception ex)
//            {
//                ex.ToString();
//            }
//            return book;
//        }


//        // GET: api/Values/GetUser
//        //[HttpGet, Route("GetOrder")]
//        //public async Task<object> GetOrder()
//        //{
//        //    List<Student> users = null;
//        //    //object result = null;
//        //    try
//        //    {
//        //        using (_ctx)
//        //        {
//        //            users = await _ctx.Students.ToListAsync();
//        //            //result = new
//        //            //{
//        //            //    User
//        //            //};
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ex.ToString();
//        //    }
//        //    return users;
//        //}









//        // GET: api/Values/GetUser
//        [HttpGet, Route("GetUser")]
//        public async Task<object> GetUser()
//        {
//            List<Student> users = null;
//            //object result = null;
//            try
//            {
//                using (_ctx)
//                {
//                    users = await _ctx.Students.ToListAsync();
//                    //result = new
//                    //{
//                    //    User
//                    //};
//                }
//            }
//            catch (Exception ex)
//            {
//                ex.ToString();
//            }
//            return users;
//        }

//        // GET api/Values/GetUserByID/5
//        [HttpGet, Route("GetUserByID/{id}")]
//        public async Task<Student> GetUserByID(int id)
//        {
//            Student user = null;
//            try
//            {
//                using (_ctx)
//                {
//                    user = await _ctx.Students.FirstOrDefaultAsync(x => x.StudentID == id);
//                }
//            }
//            catch (Exception ex)
//            {
//                ex.ToString();
//            }
//            return user;
//        }


//        // POST api/Values/PostUser
//        [HttpPost, Route("PostUser")]
//        public async Task<object> PostUser([FromBody] Student model)
//        {
//            object result = null; string message = "";
//            if (model == null)
//            {
//                return BadRequest();
//            }
//            using (_ctx)
//            {
//                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
//                {
//                    try
//                    {
//                        _ctx.Students.Add(model);
//                        await _ctx.SaveChangesAsync();
//                        _ctxTransaction.Commit();
//                        message = "Saved Successfully";
//                    }
//                    catch (Exception e)
//                    {
//                        _ctxTransaction.Rollback();
//                        e.ToString();
//                        message = "Saved Error";
//                    }

//                    result = new
//                    {
//                        message
//                    };
//                }
//            }
//            return result;
//        }

//        // PUT api/Values/PutUser/5
//        [HttpPut, Route("PutUser/{id}")]
//        public async Task<object> PutUser(int id, [FromBody] Student model)
//        {
//            object result = null; string message = "";
//            if (model == null)
//            {
//                return BadRequest();
//            }
//            using (_ctx)
//            {
//                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
//                {
//                    try
//                    {
//                        var entityUpdate = _ctx.Students.FirstOrDefault(x => x.StudentID == id);
//                        if (entityUpdate != null)
//                        {
//                            entityUpdate.Name = model.Name;
//                            entityUpdate.FatherName = model.FatherName;
//                            entityUpdate.MotherName = model.MotherName;
//                            entityUpdate.UnitID = model.UnitID;
//                            entityUpdate.Gender = model.Gender;
//                            entityUpdate.DOB = model.DOB;
//                            entityUpdate.Status = model.Status;
//                            entityUpdate.Email = model.Email;

//                            await _ctx.SaveChangesAsync();
//                        }
//                        _ctxTransaction.Commit();
//                        message = "Entry Updated";
//                    }
//                    catch (Exception e)
//                    {
//                        _ctxTransaction.Rollback(); e.ToString();
//                        message = "Entry Update Failed!!";
//                    }

//                    result = new
//                    {
//                        message
//                    };
//                }
//            }
//            return result;
//        }

//        // DELETE api/Values/DeleteUserByID/5
//        [HttpDelete, Route("DeleteUserByID/{id}")]
//        public async Task<object> DeleteUserByID(int id)
//        {
//            object result = null; string message = "";
//            using (_ctx)
//            {
//                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
//                {
//                    try
//                    {
//                        var idToRemove = _ctx.Students.SingleOrDefault(x => x.StudentID == id);
//                        if (idToRemove != null)
//                        {
//                            _ctx.Students.Remove(idToRemove);
//                            await _ctx.SaveChangesAsync();
//                        }
//                        _ctxTransaction.Commit();
//                        message = "Deleted Successfully";
//                    }
//                    catch (Exception e)
//                    {
//                        _ctxTransaction.Rollback(); e.ToString();
//                        message = "Error on Deleting!!";
//                    }

//                    result = new
//                    {
//                        message
//                    };
//                }
//            }
//            return result;
//        }
//    }
//}




























using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MiddelClass_WebAPIController : ApiController
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: api/MiddelClass_WebAPI
        public IQueryable<CategoryMiddle> GetMiddle()
        {
            return db.CategoryMiddles;
        }

        // GET: api/MiddelClass_WebAPI/5
        public IHttpActionResult GetMiddle(int id)
        {
            CategoryMiddle _categoryMiddle = db.CategoryMiddles.Find(id);
            if (_categoryMiddle == null)
            {
                return NotFound();
            }

            return Ok(_categoryMiddle);
        }

        // POST: api/MiddelClass_WebAPI
        [ResponseType(typeof(CategoryMiddle))]
        public IHttpActionResult PostMiddle(CategoryMiddle _categoryMiddle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryMiddles.Add(_categoryMiddle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = _categoryMiddle.CategoryMID }, _categoryMiddle);
        }

        // PUT: api/MiddelClass_WebAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMiddle(int id, CategoryMiddle _categoryMiddle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _categoryMiddle.CategoryMID)
            {
                return BadRequest();
            }

            db.Entry(_categoryMiddle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryMiddleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/MiddelClass_WebAPI/5
        [ResponseType(typeof(CategoryMiddle))]
        public IHttpActionResult DeleteMiddle(int id)
        {
            CategoryMiddle _categoryMiddle = db.CategoryMiddles.Find(id);
            if (_categoryMiddle == null)
            {
                return NotFound();
            }

            db.CategoryMiddles.Remove(_categoryMiddle);
            db.SaveChanges();

            return Ok(_categoryMiddle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryMiddleExists(int id)
        {
            return db.CategoryMiddles.Count(e => e.CategoryMID == id) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Models;
using Repositories;

namespace SayIT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LearningTypesController : ODataController
    {
        private SayItContext db = new SayItContext();

        // GET: odata/LearningTypes
        [EnableQuery]
        public IQueryable<LearningType> GetLearningTypes()
        {
            return db.LearningTypes;
        }

        // GET: odata/LearningTypes(5)
        [EnableQuery]
        public SingleResult<LearningType> GetLearningType([FromODataUri] int key)
        {
            return SingleResult.Create(db.LearningTypes.Where(learningType => learningType.Id == key));
        }

        // PUT: odata/LearningTypes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<LearningType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LearningType learningType = db.LearningTypes.Find(key);
            if (learningType == null)
            {
                return NotFound();
            }

            patch.Put(learningType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(learningType);
        }

        // POST: odata/LearningTypes
        public IHttpActionResult Post(LearningType learningType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LearningTypes.Add(learningType);
            db.SaveChanges();

            return Created(learningType);
        }

        // PATCH: odata/LearningTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<LearningType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LearningType learningType = db.LearningTypes.Find(key);
            if (learningType == null)
            {
                return NotFound();
            }

            patch.Patch(learningType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(learningType);
        }

        // DELETE: odata/LearningTypes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            LearningType learningType = db.LearningTypes.Find(key);
            if (learningType == null)
            {
                return NotFound();
            }

            db.LearningTypes.Remove(learningType);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/LearningTypes(5)/QuizQuestion
        [EnableQuery]
        public IQueryable<QuizQuestion> GetQuizQuestion([FromODataUri] int key)
        {
            return db.LearningTypes.Where(m => m.Id == key).SelectMany(m => m.QuizQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LearningTypeExists(int key)
        {
            return db.LearningTypes.Count(e => e.Id == key) > 0;
        }
    }
}

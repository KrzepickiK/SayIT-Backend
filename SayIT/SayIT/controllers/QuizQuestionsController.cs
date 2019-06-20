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
using System.Web.OData;
using Models;
using Repositories;

namespace SayIT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuizQuestionsController : ODataController
    {
        private SayItContext db = new SayItContext();

        // GET: odata/QuizQuestions
        [EnableQuery]
        public IQueryable<QuizQuestion> GetQuizQuestions()
        {
            return db.QuizQuestions;
        }

        // GET: odata/QuizQuestions(5)
        [EnableQuery]
        public SingleResult<QuizQuestion> GetQuizQuestion([FromODataUri] int key)
        {
            return SingleResult.Create(db.QuizQuestions.Where(quizQuestion => quizQuestion.Id == key));
        }

        // PUT: odata/QuizQuestions(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<QuizQuestion> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuizQuestion quizQuestion = db.QuizQuestions.Find(key);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            patch.Put(quizQuestion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(quizQuestion);
        }

        // POST: odata/QuizQuestions
        public IHttpActionResult Post(QuizQuestion quizQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuizQuestions.Add(quizQuestion);
            db.SaveChanges();

            return Created(quizQuestion);
        }

        // PATCH: odata/QuizQuestions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<QuizQuestion> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuizQuestion quizQuestion = db.QuizQuestions.Find(key);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            patch.Patch(quizQuestion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(quizQuestion);
        }

        // DELETE: odata/QuizQuestions(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            QuizQuestion quizQuestion = db.QuizQuestions.Find(key);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            db.QuizQuestions.Remove(quizQuestion);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/QuizQuestions(5)/LearningType
        [EnableQuery]
        public SingleResult<LearningType> GetLearningType([FromODataUri] int key)
        {
            return SingleResult.Create(db.QuizQuestions.Where(m => m.Id == key).Select(m => m.LearningType));
        }

        // GET: odata/QuizQuestions(5)/Translation
        [EnableQuery]
        public SingleResult<Translation> GetTranslation([FromODataUri] int key)
        {
            return SingleResult.Create(db.QuizQuestions.Where(m => m.Id == key).Select(m => m.Translation));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizQuestionExists(int key)
        {
            return db.QuizQuestions.Count(e => e.Id == key) > 0;
        }
    }
}

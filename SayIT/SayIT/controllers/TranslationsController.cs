using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Models;
using Repositories;

namespace SayIT.controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Translation>("Translations");
    builder.EntitySet<Category>("Categories"); 
    builder.EntitySet<QuizQuestion>("QuizQuestions"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TranslationsController : ODataController
    {
        private SayItContext db = new SayItContext();


        // GET: odata/Translations
        [EnableQuery]
        public IQueryable<Translation> GetTranslations()
        {

            return db.Translations;
             
        }

        // GET: odata/Translations(5)
        [EnableQuery]
        public SingleResult<Translation> GetTranslation([FromODataUri] int key)
        {
            return SingleResult.Create(db.Translations.Where(translation => translation.Id == key));
        }

        // PUT: odata/Translations(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Translation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Translation translation = db.Translations.Find(key);
            if (translation == null)
            {
                return NotFound();
            }

            patch.Put(translation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(translation);
        }

        // POST: odata/Translations
        public IHttpActionResult Post([FromBody]Translation translation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Translations.Add(translation);
            db.SaveChanges();

            return Created(translation);
        }

        // PATCH: odata/Translations(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Translation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Translation translation = db.Translations.Find(key);
            if (translation == null)
            {
                return NotFound();
            }

            patch.Patch(translation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(translation);
        }

        // DELETE: odata/Translations(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Translation translation = db.Translations.Find(key);
            if (translation == null)
            {
                return NotFound();
            }

            db.Translations.Remove(translation);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Translations(5)/Category
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Translations.Where(m => m.Id == key).Select(m => m.Category));
        }

        // GET: odata/Translations(5)/QuizQuestion
        [EnableQuery]
        public IQueryable<QuizQuestion> GetQuizQuestion([FromODataUri] int key)
        {
            return db.Translations.Where(m => m.Id == key).SelectMany(m => m.QuizQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TranslationExists(int key)
        {
            return db.Translations.Count(e => e.Id == key) > 0;
        }
    }
}

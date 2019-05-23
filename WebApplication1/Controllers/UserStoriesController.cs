using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserStoriesController : ApiController
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: api/UserStories
        public IQueryable<UserStory> GetUserStories()
        {
            return db.UserStories;
        }

        // GET: api/UserStories/5
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult GetUserStory(int id)
        {
            UserStory userStory = db.UserStories.Find(id);
            if (userStory == null)
            {
                return NotFound();
            }

            return Ok(userStory);
        }

        // PUT: api/UserStories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserStory(int id, UserStory userStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userStory.UserStoryId)
            {
                return BadRequest();
            }

            db.Entry(userStory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoryExists(id))
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

        // POST: api/UserStories
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult PostUserStory(UserStory userStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserStories.Add(userStory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userStory.UserStoryId }, userStory);
        }

        // DELETE: api/UserStories/5
        [ResponseType(typeof(UserStory))]
        public IHttpActionResult DeleteUserStory(int id)
        {
            UserStory userStory = db.UserStories.Find(id);
            if (userStory == null)
            {
                return NotFound();
            }

            db.UserStories.Remove(userStory);
            db.SaveChanges();

            return Ok(userStory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserStoryExists(int id)
        {
            return db.UserStories.Count(e => e.UserStoryId == id) > 0;
        }
    }
}
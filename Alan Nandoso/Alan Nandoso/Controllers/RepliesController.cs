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
using Alan_Nandoso.Model;
using Alan_Nandoso.Models;

namespace Alan_Nandoso.Controllers
{
    public class RepliesController : ApiController
    {
        private Alan_NandosoContext db = new Alan_NandosoContext();

        // GET: api/Replies
        public IQueryable<Reply> GetReplies()
        {
            return db.Replies;
        }

        // GET: api/Replies/5
        [ResponseType(typeof(Reply))]
        public IHttpActionResult GetReply(int id)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return NotFound();
            }

            return Ok(reply);
        }

        // PUT: api/Replies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReply(int id, Reply reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reply.ID)
            {
                return BadRequest();
            }

            db.Entry(reply).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplyExists(id))
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

        // POST: api/Replies
        [ResponseType(typeof(Reply))]
        public IHttpActionResult PostReply(Reply reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Replies.Add(reply);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reply.ID }, reply);
        }

        // DELETE: api/Replies/5
        [ResponseType(typeof(Reply))]
        public IHttpActionResult DeleteReply(int id)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return NotFound();
            }

            db.Replies.Remove(reply);
            db.SaveChanges();

            return Ok(reply);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReplyExists(int id)
        {
            return db.Replies.Count(e => e.ID == id) > 0;
        }
    }
}
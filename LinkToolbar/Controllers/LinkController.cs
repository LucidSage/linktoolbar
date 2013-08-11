using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LinkToolbar.Models;

namespace LinkToolbar.Controllers
{
    public class LinkController : ApiController
    {
        private LinkToolbarContext db = new LinkToolbarContext();

        // GET api/Link
        public IEnumerable<Link> GetLinks()
        {
            return db.Links.AsEnumerable();
        }

        // GET api/Link/5
        public Link GetLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return link;
        }

        // PUT api/Link/5
        public HttpResponseMessage PutLink(int id, Link link)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != link.LinkId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(link).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Link
        public HttpResponseMessage PostLink(Link link)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(link);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, link);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = link.LinkId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Link/5
        public HttpResponseMessage DeleteLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Links.Remove(link);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, link);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
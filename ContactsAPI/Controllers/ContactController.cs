using ContactAPI.Models;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ContactsAPI.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContact _ContactRepository;

        public ContactController(IContact contactRepository)
        {
            _ContactRepository = contactRepository;
        }
        // GET api/contact
        public IHttpActionResult Get()
        {
            return Ok(_ContactRepository.GetContactList());
        }

        // GET api/contact/5
        public IHttpActionResult Get(int id)
        {
            if (_ContactRepository.GetContact(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_ContactRepository.GetContact(id));
            }
        }

        // POST api/contact
        [HttpPost]
        public IHttpActionResult SaveContact([FromBody]Contact value)
        {
            if (value != null)
            {
                _ContactRepository.SaveContact(value);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/contact/5
        [HttpPut]
        public IHttpActionResult UpdateContact(int id, [FromBody]Contact value)
        {
            if (value != null)
            {
                var result = _ContactRepository.UpdateContact(id, value);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/contact/5
        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            bool result = _ContactRepository.DeleteContact(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

        }

    }
}

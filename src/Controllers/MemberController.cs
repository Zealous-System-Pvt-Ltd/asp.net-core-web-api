using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMSApi.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private SocietyManagementContext _dbContext;
        public MemberController(SocietyManagementContext context)
        {
            _dbContext = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Members>> Get()
        {
            return _dbContext.Members.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Members> GetById(Guid id)
        {
            var item = _dbContext.Members.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult CreateMember([FromBody]Members model)
        {
            model.MemberId = Guid.NewGuid();
            _dbContext.Members.Add(model);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = model.MemberId }, model);
        }

        [HttpPut("{id}")]
        [ActionName("UpdateMember")]
        public IActionResult UpdateMember(Guid id, [FromBody] Members model)
        {
            var member = _dbContext.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            member.FirstName = model.FirstName;
            member.MiddleName = model.MiddleName;
            member.LastName = model.LastName;
            member.MobileNo = model.MobileNo;
            member.EmailId = model.EmailId;
            _dbContext.Members.Update(member);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName("deleteMember")]
        public IActionResult deleteMember(Guid id)
        {
            var member = _dbContext.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            _dbContext.Members.Remove(member);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForENGLISH.Models;
using NuGet.Packaging.Signing;

namespace ApiForENGLISH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuetionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public QuetionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetFood")]
        public async Task<ActionResult<IEnumerable<Quetion>>> GetFood()
        {
            var randQ = await (_context.Quetions.Select(
                x => new
                {
                    QnId = x.QuetId,
                    QnInWords = x.QnInWords,
                    ImageName = x.Image,
                    Options = new string[] {x.Option1, x.Option2, x.Option3, x.Option4},
                    Category = x.Category,
                })).Where(x => x.Category == "food")
                .OrderBy(y => Guid.NewGuid())
                .Take(5).ToListAsync();

            return Ok(randQ);
        }

        [HttpGet]
        [Route("GetSport")]
        public async Task<ActionResult<IEnumerable<Quetion>>> GetSport()
        {
            var randQ = await (_context.Quetions.Select(
                x => new
                {
                    QnId = x.QuetId,
                    QnInWords = x.QnInWords,
                    ImageName = x.Image,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
                    Category = x.Category,
                })).Where(x => x.Category == "sport")
                .OrderBy(y => Guid.NewGuid())
                .Take(5).ToListAsync();

            return Ok(randQ);
        }


        [HttpGet]
        [Route("GetCloth")]
        public async Task<ActionResult<IEnumerable<Quetion>>> GetCloth()
        {
            var randQ = await (_context.Quetions.Select(
                x => new
                {
                    QnId = x.QuetId,
                    QnInWords = x.QnInWords,
                    ImageName = x.Image,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
                    Category = x.Category,
                })).Where(x => x.Category == "cloth")
                .OrderBy(y => Guid.NewGuid())
                .Take(5).ToListAsync();

            return Ok(randQ);
        }

        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Quetion>> RetreiveAnswer(int[] qnIds)
        {
            var answers = await (_context.Quetions
                 .Where(x => qnIds.Contains(x.QuetId))
                 .Select(y => new
                 {
                     QnId = y.QuetId,
                     QnInWords = y.QnInWords,
                     ImageName = y.Image,
                     Options = new string[] { y.Option1, y.Option2, y.Option3, y.Option4 },
                     Answer = y.Answer
                 })).ToListAsync();
            return Ok(answers);
        }
    }
}

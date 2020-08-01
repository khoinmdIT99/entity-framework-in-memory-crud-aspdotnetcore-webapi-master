using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimonGilbert.Blog.Models;
using SimonGilbert.Blog.Services.Interfaces;
using SimonGilbert.Blog.Validation;

namespace SimonGilbert.Blog.Controllers
{
    [Route("blogs")]
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogController(IBlogPostService blogPostService)
        {
            this._blogPostService = blogPostService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]BlogPost blogPost)
        {
            if (blogPost.IsValid(out IEnumerable<string> errors))
            {
                var result = await _blogPostService.Create(blogPost);

                return CreatedAtAction(
                    nameof(GetAllByUserAccountId), 
                    new { id = result.UserAccountId }, result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody]BlogPost blogPost)
        {
            if (blogPost.IsValid(out IEnumerable<string> errors))
            {
                var result = await _blogPostService.Update(blogPost);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _blogPostService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllByUserAccountId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var result = _blogPostService.GetAllByUserAccountId(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var result = await _blogPostService.Delete(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


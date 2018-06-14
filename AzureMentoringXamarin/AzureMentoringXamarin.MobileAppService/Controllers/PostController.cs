using System;
using Microsoft.AspNetCore.Mvc;

using AzureMentoringXamarin.Models;

namespace AzureMentoringXamarin.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
	{

		private readonly IPostRepository PostRepository;

		public PostController(IPostRepository postRepository)
		{
			PostRepository = postRepository;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(PostRepository.GetAll());
		}

		[HttpGet("{Id}")]
		public Post GetPost(string id)
		{
			Post post = PostRepository.Get(id);
			return post;
		}

		[HttpPost]
		public IActionResult Create([FromBody]Post post)
		{
			try
			{
				if (post == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}

				PostRepository.Add(post);

			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return Ok(post);
		}

		[HttpPut]
		public IActionResult Edit([FromBody] Post post)
		{
			try
			{
				if (post == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}
				PostRepository.Update(post);
			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return NoContent();
		}

		[HttpDelete("{Id}")]
		public void Delete(string id)
		{
			PostRepository.Remove(id);
		}
	}
}

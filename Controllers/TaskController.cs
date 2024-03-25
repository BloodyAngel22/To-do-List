using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using To_do_List.Models;

namespace To_do_List.Controllers
{
	public class TaskController : Controller
	{
		private ApplicationDbContext _context;
		private readonly ILogger<TaskController> _logger;

		public TaskController(ILogger<TaskController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_context.Tasks);
		}

		[HttpGet]
		public IActionResult Create() => View();

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult Create(TaskModel task)
		{
			if (ModelState.IsValid)
			{
				_context.Tasks.Add(task);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(task);
		}

		public async Task<IActionResult> MarkAsDone(int id)
		{
			var task = await _context.Tasks.FindAsync(id);

			if (task != null)
			{
				task.IsDone = true;
				_context.Tasks.Update(task);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			var task = await _context.Tasks.FindAsync(id);

			if (task != null)
			{
				_context.Tasks.Remove(task);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
			return View(task);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult Edit(TaskModel task)
		{
			if (ModelState.IsValid)
			{
				_context.Tasks.Update(task);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(task);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Error!");
		}
	}
}
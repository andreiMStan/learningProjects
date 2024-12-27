using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StudentService_CRUD.Domain.Models;
using StudentService_CRUD.Services;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
				app.UseSwagger();
				app.UseSwaggerUI();
}

app.UseHttpsRedirection();


[ApiController]
[Route("tasks/[Controller]")]
public class StudentsTaskController(StudentService studentService):ControllerBase

				[HttpPatch]
				[Route("{studentId}/name")]
				public async Task<IActionResult>UpdateStudentName(int studentId, [FromBody]string name)
{
				var result = await studentService.ChangeStudentNameAsync(studentId, name);
				if (result) return Ok();
				return BadRequest();
				}
}


					[HttpPatch]
				[Route("{studentId}/name")]
				public async Task<IActionResult>UpdateStudentEmail(int studentId, [FromBody]string email)
{
				var result = await studentService.UpdateStudentEmailAsync(studentId, email);
				if (result) return Ok();
				return BadRequest();
				}

[HttpPatch]
				[Route("{studentId}/email")]
				public async Task<IActionResult>UpdateStudentEmail(int studentId, [FromBody]string email)
{
				var result = await StudentService.UpdateStudentEmailAsync(studentId, email);
				if (result) return Ok();
				return BadRequest();
				}

}
[HttpPost]
[Route("{studentId}/relatives")]
				public async Task<IActionResult>AddStudentRelatives(int studentId, [FromBody]Relatives relative)
{
				var result = await studentService.AddStudentRelativesAsync(studentId, relative);
				if (result) return Ok();
				return BadRequest();
				}
}
}
[HttpDelete]
[Route("{studentId}/relatives")]
				public async Task<IActionResult>RemoveStudentRelative(int studentId, int relativeId)
{
				var result = await StudentService.RemoveStudentRelativeAsync(studentId, relativeId);
				if (result) return Ok();
				return BadRequest();
				}
}

app.Run();


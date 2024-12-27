using StudentService_CRUD.Domain.Models;
using System.Data;

namespace StudentService_CRUD.Services
{
				public class StudentService
				{
			

        public async Task<bool>ChangeStudentNameAsync(int studentId,string name)
								{
												var existingStudent = await= ctx.Students!

																.Include(s => s.AuditLogs)
																.FirstOrDefaultAsync(s => s.Id == studentId);

												if (existingStudent. is null) throw new ApplicationException("student not found")


																existingStudent.Name = name;
												var auditLog = new AuditLog
												{
																DataCreated = DateTime.UtcNow,
																PerformedAction = UpdateType.NameUpdated
												};
												existingStudent.AuditLogs!.Add(auditLog);
												await ctx.SaveChangesAsync();
												return true;

								}

								public async Task<bool>UpdateStudentEmailAsync(int studentId,string email)
								{
												var existingStudent = await ctx.Students!
																.Include(s => s.AuditLogs)
																.FirstOrDefaultAsync(s => s.Id == studentId);
												if (existingStudent. is null) throw new ApplicationException("student not found")
																				existingStudent.Email = email;
												{
																DataCreated = DateTime.UtcNow,
																PerformedAction = UpdateType.NameUpdated
												};
												existingStudent.AuditLogs!.Add(auditLog);
												await ctx.SaveChangesAsync();
												return true;


								}

								public async Task<bool> ChangeStudentAddressAsync(int studentId, Address address)
								{
												var existingStudent = await ctx.Students!
																.Include(s => s.Address)
																.Include(s => s.AuditLogs)
																.FirstOrDefaultAsync(s => s.Id == studentId);
												if (existingStudent. is null) throw new ApplicationException("student not found")
																				existingStudent.Address = address;
												{
																DataCreated = DateTime.UtcNow,
																PerformedAction = UpdateType.UpdatedAddress
												};
												existingStudent.AuditLogs!.Add(auditLog);
												await ctx.SaveChangesAsync();
												return true;


								}		
								public async Task<bool> AddStudentRelatives(int studentId, Relatives relative)
								{
												var existingStudent = await ctx.Students!
																.Include(s => s.Relatives)
																.Include(s => s.AuditLogs)
																.FirstOrDefaultAsync(s => s.Id == studentId);
												if (existingStudent. is null) throw new ApplicationException("student not found")
																				existingStudent.Relatives!.Add( relative;)
												{
																DataCreated = DateTime.UtcNow,
																PerformedAction = UpdateType.RelativeAdded
												};
												existingStudent.AuditLogs!.Add(auditLog);
												await ctx.SaveChangesAsync();
												return true;


								}		public async Task<bool> RemoveStudentRelativeAsync(int studentId, int relativeId)
								{
												var existingStudent = await ctx.Students!
																.Include(s => s.Relatives)
																.Include(s => s.AuditLogs)
																.FirstOrDefaultAsync(s => s.Id == studentId);
												if (existingStudent. is null) throw new ApplicationException("student not found")
												var relative = existingStudent.Relatives!.FirstOrDefault(r => r.Id == relativeId);
												if (relative is not null)
																existingStudent.Relatives!.Remove(relative);

												await ctx.SaveChangesAsync();
												return true;


								}
				}
}

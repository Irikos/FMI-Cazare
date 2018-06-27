﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FMI_Cazare.Models;
using Microsoft.EntityFrameworkCore;

namespace FMI_Cazare.Controllers
{
    [Produces("application/json")]
    [Route("api/Generate")]
    public class GenerateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenerateController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("Licenta1")]
        public async Task<IActionResult> DummyDataAsync()
        {
            try
            {
                /*_context.Documents.RemoveRange(_context.Documents);
                _context.DormCategories.RemoveRange(_context.DormCategories);
                _context.DormPreferences.RemoveRange(_context.DormPreferences);
                _context.Dorms.RemoveRange(_context.Dorms);
                _context.Forms.RemoveRange(_context.Forms);
                _context.Histories.RemoveRange(_context.Histories);
                _context.Messages.RemoveRange(_context.Messages);
                _context.Notifications.RemoveRange(_context.Notifications);
                _context.RoomatePreferences.RemoveRange(_context.RoomatePreferences);
                _context.Rooms.RemoveRange(_context.Rooms);
                _context.Sessions.RemoveRange(_context.Sessions);
                _context.Spots.RemoveRange(_context.Spots);
                _context.Users.RemoveRange(_context.Users);*/

                await _context.Database.EnsureDeletedAsync();

                await _context.Database.EnsureCreatedAsync();

                var adminUserModel = new UserModel()
                {
                    UserId = 1,
                    Email = "admin@fmi.unibuc.ro",
                    PasswordHash = AuthController.ComputeHash("admin"),
                    Role = UserModel.UserRole.Admin
                };

                await _context.Users.AddRangeAsync(
                    adminUserModel,
                    new UserModel
                    {
                        UserId = 2,
                        Email = "management@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("management"),
                        Role = UserModel.UserRole.Management
                    },
                    new UserModel
                    {
                        UserId = 3,
                        Email = "teacher@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("teacher"),
                        Role = UserModel.UserRole.Teacher
                    },
                    new UserModel
                    {
                        UserId = 4,
                        Email = "student@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("student"),
                        Role = UserModel.UserRole.Student
                    },
                    new UserModel
                    {
                        UserId = 5,
                        Email = "student2@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("student"),
                        Role = UserModel.UserRole.Student
                    },
                    new UserModel
                    {
                        UserId = 6,
                        Email = "student3@fmi.unibuc.ro",
                        PasswordHash = AuthController.ComputeHash("student"),
                        Role = UserModel.UserRole.Student
                    }
                );

                await _context.Forms.AddRangeAsync(
                    new FormModel
                    {
                        FormId = 1,
                        SessionId = 1,
                        UserId = 4,
                        State = FormModel.FormState.Saved,
                        IsContinuity = false,
                        IsSocial = true
                    }
                );

                await _context.DormPreferences.AddRangeAsync(
                    new DormPreferenceModel
                    {
                        DormPreferenceId = 1,
                        DormId = 1,
                        Priority = 1,
                    }
                );

                await _context.DormPreferences.AddRangeAsync(
                    new DormPreferenceModel
                    {
                        DormPreferenceId = 1,
                        DormId = 2,
                        Priority = 2,
                    }
                );

                await _context.DormPreferences.AddRangeAsync(
                    new DormPreferenceModel
                    {
                        DormPreferenceId = 2,
                        DormId = 3,
                        Priority = 3,
                    }
                );
           
                await _context.RoomatePreferences.AddRangeAsync(
                    new RoomatePreferenceModel
                    {
                        RoommatePreferenceId = 2,
                        StudentId = 5,
                        Priority = 1,
                    }
                );

                await _context.RoomatePreferences.AddRangeAsync(
                    new RoomatePreferenceModel
                    {
                        RoommatePreferenceId = 2,
                        StudentId = 6,
                        Priority = 2,
                    }
                );
                //var studentId = _context.Users.FirstOrDefault(m => m.Email == "student@fmi.unibuc.ro").UserId;




                await _context.SaveChangesAsync();

                return Ok("Success.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Generate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Generate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Generate
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Generate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

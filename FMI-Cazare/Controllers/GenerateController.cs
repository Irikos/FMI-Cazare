using System;
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
                    Role = UserModel.UserRole.Admin,
                    Cnp = "1922345987292",
                    FirstName = "Adminus",
                    LastName = "Optimus",
                    IcSerie = "VS",
                    IcNumber = "665577",
                    BirthPlace = "Vaslui, strada Alcoolului",
                    FatherFirstName = "Sudo Su",
                    MotherFirstName = "Emilia",
                    Specialization = "Informatica",
                    Year = "3",
                    Gender = UserModel.UserGender.Male,
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
                        Role = UserModel.UserRole.Student,
                        Cnp = "1922345987292",
                        FirstName = "Studentus",
                        LastName = "Optimus",
                        IcSerie = "VS",
                        IcNumber = "665577",
                        BirthPlace = "Vaslui, strada Alcoolului",
                        FatherFirstName = "Sudo Su",
                        MotherFirstName = "Emilia",
                        Specialization = "Informatica",
                        Year = "3",
                        Gender = UserModel.UserGender.Male,
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



                await _context.Sessions.AddRangeAsync(
                    new SessionModel
                    {
                        SessionId = 1,
                        Name = "Princeps",
                        Description = "Prima sesiune de test",
                        DormCategories = new List<DormCategoryModel>
                        {
                            new DormCategoryModel
                            {
                                DormCategoryId = 1,
                                Name = "A",
                                Dorms = new List<DormModel>
                                {
                                    new DormModel
                                    {
                                        DormId = 1,
                                        Name = "Kogalniceanu",
                                        Rooms = new List<RoomModel>
                                        {
                                            new RoomModel
                                            {
                                                RoomId = 1,
                                                RoomNumber = "100",
                                                Type = RoomModel.RoomType.Masculin,
                                                Spots = new List<SpotModel>
                                                {
                                                }
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 2,
                                                RoomNumber = "101",
                                                Type = RoomModel.RoomType.Masculin,
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 3,
                                                RoomNumber = "102",
                                                Type = RoomModel.RoomType.Feminin,
                                            },

                                        }
                                    },
                                    new DormModel
                                    {
                                        DormId = 2,
                                        Name = "Grozavesti A1",
                                        Rooms = new List<RoomModel>
                                        {
                                            new RoomModel
                                            {
                                                RoomId = 4,
                                                RoomNumber = "200",
                                                Type = RoomModel.RoomType.Masculin,
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 5,
                                                RoomNumber = "201",
                                                Type = RoomModel.RoomType.Masculin,
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 6,
                                                RoomNumber = "202",
                                                Type = RoomModel.RoomType.Feminin,
                                            },

                                        }
                                    },
                                    new DormModel
                                    {
                                        DormId = 3,
                                        Name = "Grozavesti B",
                                        Rooms = new List<RoomModel>
                                        {
                                            new RoomModel
                                            {
                                                RoomId = 7,
                                                RoomNumber = "300",
                                                Type = RoomModel.RoomType.Masculin,
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 8,
                                                RoomNumber = "301",
                                                Type = RoomModel.RoomType.Masculin,
                                            },
                                            new RoomModel
                                            {
                                                RoomId = 9,
                                                RoomNumber = "302",
                                                Type = RoomModel.RoomType.Feminin,
                                            },

                                        }
                                    }
                                }

                            },
                            new DormCategoryModel
                            {
                                DormCategoryId = 2,
                                Name = "B",
                                Dorms = new List<DormModel>
                                {
                                    new DormModel
                                    {
                                        DormId = 4,
                                        Name = "Grozavesti C",
                                    },
                                    new DormModel
                                    {
                                        DormId = 5,
                                        Name = "Grozavesti D",
                                    },
                                    new DormModel
                                    {
                                        DormId = 6,
                                        Name = "Grozavesti E",
                                    }
                                }
                            }
                        }

                    }
                );

                await _context.DormCategories.AddRangeAsync(
                );

                await _context.Dorms.AddRangeAsync(
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

                await _context.Forms.AddRangeAsync(
                    new FormModel
                    {
                        FormId = 2,
                        SessionId = 1,
                        UserId = 5,
                        State = FormModel.FormState.Sent,
                        IsContinuity = true,
                        IsSocial = true,
                        DormPreferences = new List<DormPreferenceModel>
                        {
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 1,
                                DormId = 1,
                                Priority = 1,
                            },
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 2,
                                DormId = 2,
                                Priority = 2,
                            },
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 3,
                                DormId = 3,
                                Priority = 3,
                            }
                        }
                    }
                );

                await _context.Forms.AddRangeAsync(
                    new FormModel
                    {
                        FormId = 3,
                        SessionId = 1,
                        UserId = 6,
                        State = FormModel.FormState.Approved,
                        IsContinuity = true,
                        IsSocial = false,
                        DormPreferences = new List<DormPreferenceModel>
                        {
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 4,
                                DormId = 1,
                                Priority = 1,
                            },
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 5,
                                DormId = 2,
                                Priority = 2,
                            },
                            new DormPreferenceModel
                            {
                                DormPreferenceId = 6,
                                DormId = 3,
                                Priority = 3,
                            }
                        }
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

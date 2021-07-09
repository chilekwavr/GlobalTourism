using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SeedData
    {

        private readonly ApplicationDbContext _ctx;

        public SeedData(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {

            if (!_ctx.Developers.Any())
            {
                for (int i = 1; i <= 1000; i++)
                {
                    var developer = new Developer
                    {
                        WorkHistories = new List<WorkHistory>
                        {
                            new WorkHistory{Name = $"work history {i*1}"},
                            new WorkHistory{Name = $"work history {i*2}"},
                            new WorkHistory{Name = $"work history {i*3}"}
                        },
                        Address = new Address
                        {
                            City = $"City{i}",
                            Street = $"Street{i}"
                        },
                        EstimatedIncome = i,
                        Name = $"Name{i}",
                        YearsOfExperience = i / 100

                    };
                    _ctx.Developers.Add(developer);
                }
                _ctx.SaveChanges();

            }

            if (!_ctx.PersonNames.Any())
            { 
                var personname = new PersonName()
                {
                    FirstName = "firstname",
                    LastName = "lastname",
                    MiddleName = "middlename"
                };

                _ctx.PersonNames.Add(personname);

                var contactdetail = new ContactDetail()
                {
                    Email = "contact@contact.com",
                    Phone = "12367894"
                };

                _ctx.ContactDetails.Add(contactdetail);
                _ctx.SaveChanges();

            }

            
        }
    }
}

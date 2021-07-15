using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorldTour.Infrastructure;

namespace Infrastructure
{
    public class SeedData
    {

        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<StoreUser> _userManager;

        public SeedData(ApplicationDbContext ctx, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            StoreUser user = await _userManager.FindByEmailAsync("victor@chola.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "victor",
                    LastName = "chola",
                    Email = "victor@chola.com",
                    UserName = "victor@chola.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }

            if (!_ctx.Developers.Any())
            {
                for (int i = 1; i <= 10; i++)
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

            if (!_ctx.Customers.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category
                    {
                        CategoryName = "category1",
                        Description = "Description1"
                    },
                     new Category
                    {
                        CategoryName = "category2",
                        Description = "Description2"
                    },
                      new Category
                    {
                        CategoryName = "category3",
                        Description = "Description3"
                    }
                };
                _ctx.Categories.AddRange(categories);

                List<Supplier> Suppliers = new List<Supplier>
                {
                        new Supplier
                        {
                            SupplierName = "supplier1"
                        },
                        new Supplier
                        {
                            SupplierName = "supplier2"
                        },
                        new Supplier
                        {
                            SupplierName = "supplier3"
                        }
                    };
                _ctx.Suppliers.AddRange(Suppliers);

                var products = new List<Product>
                {
                    new Product
                    {
                        ProductName = "product name 1",
                        UnitPrice = 123.09M + 1,
                        Categories = categories[0],
                        Suppliers = Suppliers[0]
                    },
                     new Product
                    {
                        ProductName = "product name 2",
                        UnitPrice = 123.09M + 20,
                        Categories = categories[1],
                        Suppliers = Suppliers[1]
                    },
                      new Product
                    {
                        ProductName = "product name 3",
                        UnitPrice = 123.09M + 30,
                        Categories = categories[0],
                        Suppliers = Suppliers[0]
                    },
                       new Product
                    {
                        ProductName = "product name 4",
                        UnitPrice = 123.09M + 40,
                        Categories = categories[2],
                        Suppliers = Suppliers[2]
                    },
                        new Product
                    {
                        ProductName = "product name 5",
                        UnitPrice = 123.09M + 50,
                        Categories = categories[1],
                        Suppliers = Suppliers[1]
                    },
                         new Product
                    {
                        ProductName = "product name 6",
                        UnitPrice = 123.09M + 1,
                        Categories = categories[1],
                        Suppliers = Suppliers[0]
                    },
                };

                _ctx.Products.AddRange(products);

                var Orders = new List<Order>
                {
                      new Order{
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now,
                         OrderDetails = new List<OrderDetail>
                        {
                              new OrderDetail
                                {
                                    Product = products[0]
                                }
                        }
                        },
                        new Order{
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now,
                         OrderDetails = new List<OrderDetail>
                        {
                              new OrderDetail
                                {
                                    Product = products[1]
                                }
                        }
                        }
                };
                _ctx.Orders.AddRange(Orders);
                var customer = new Customer
                {
                    Orders = Orders,
                    Phone = $"phone {1}",
                    Address = $"address {1}",
                    ContactName = $"contact name {1}",
                    CustomerName = $"customer name {1}",
                    PostalCode = $"postal code {1}",
                    Country = $"country {1}",
                    Fax = $"fax {1}"
                };

                _ctx.Customers.Add(customer);

                Orders = new List<Order>
                {
                      new Order{
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now,
                         OrderDetails = new List<OrderDetail>
                        {
                              new OrderDetail
                                {
                                    Product = products[4]
                                }
                        }
                        },
                        new Order{
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now,
                         OrderDetails = new List<OrderDetail>
                        {
                              new OrderDetail
                                {
                                    Product = products[5]
                                }
                        }
                        }
                };
                _ctx.Orders.AddRange(Orders);
                customer = new Customer
                {
                    Orders = Orders,
                    Phone = $"phone {2}",
                    Address = $"address {2}",
                    ContactName = $"contact name {2}",
                    CustomerName = $"customer name {2}",
                    PostalCode = $"postal code {2}",
                    Country = $"country {2}",
                    Fax = $"fax {2}"
                };

                _ctx.Customers.Add(customer);

                //var Orders = new List<Order>();
                //for (int i=0;i<5;i++)
                //{
                //    var order = new Order
                //    {
                //        OrderDetails = new List<OrderDetail>
                //        {
                //              new OrderDetail
                //                {
                //                    Product = new Product
                //                    {
                //                        ProductName = $"product name {i*1}",
                //                        UnitPrice = 123.09M + i,
                //                        Categories = categories[0],
                //                        Suppliers = Suppliers[0]
                //                    }
                //                }
                //        }
                //    };

                //    Orders.Add(order);
                //}


                //_ctx.Orders.AddRange(Orders);

                //for (int i = 0; i < 5; i++)
                //{
                //    var order = new Order
                //    {
                //        OrderDetails = new List<OrderDetail>
                //        {
                //              new OrderDetail
                //                {
                //                    Product = new Product
                //                    {
                //                        ProductName = $"product name {i*2}",
                //                        UnitPrice = 123.09M + (i*2),
                //                        Categories = categories[1],
                //                        Suppliers = Suppliers[1]
                //                    }
                //                }
                //        }
                //    };

                //    Orders.Add(order);
                //}
                //for (int i = 0; i < 5; i++)
                //{
                //    var order = new Order
                //    {
                //        OrderDetails = new List<OrderDetail>
                //        {
                //              new OrderDetail
                //                {
                //                    Product = new Product
                //                    {
                //                        ProductName = $"product name {i*3}",
                //                        UnitPrice = 123.09M + (i*3),
                //                        Categories = categories[2],
                //                        Suppliers = Suppliers[2]
                //                    }
                //                }
                //        }
                //    };

                //    Orders.Add(order);
                //}

                //for (int i = 0; i < 5; i++)
                //{
                //    var order = new Order
                //    {
                //        OrderDetails = new List<OrderDetail>
                //        {
                //              new OrderDetail
                //                {
                //                    Product = new Product
                //                    {
                //                        ProductName = $"product name {i*4}",
                //                        UnitPrice = 123.09M + (i*4),
                //                        Categories = categories[2],
                //                        Suppliers = Suppliers[1]
                //                    }
                //                }
                //        }
                //    };

                //    Orders.Add(order);
                //}


                //var customer1 = new Customer
                //{
                //    Orders = new List<Order>
                //    {
                //        Orders[0],Orders[1]
                //    },
                //    Phone = $"phone {1}",
                //    Address = $"address {1}",
                //    ContactName = $"contact name {1}",
                //    CustomerName = $"customer name {1}",
                //    PostalCode = $"postal code {1}",
                //    Country = $"country {1}",
                //    Fax = $"fax {1}"
                //};

                //_ctx.Customers.Add(customer1);

                //customer = new Customer
                //{
                //    //Orders = new List<Order>
                //    //{
                //    //    Orders[2],Orders[3]
                //    //},
                //    Phone = $"phone {2}",
                //    Address = $"address {2}",
                //    ContactName = $"contact name {2}",
                //    CustomerName = $"customer name {2}",
                //    PostalCode = $"postal code {2}",
                //    Country = $"country {2}",
                //    Fax = $"fax {2}"
                //};

                //_ctx.Customers.Add(customer);

                //customer = new Customer
                //{
                //    //Orders = new List<Order>
                //    //{
                //    //    Orders[4],Orders[5]
                //    //},
                //    Phone = $"phone {3}",
                //    Address = $"address {3}",
                //    ContactName = $"contact name {3}",
                //    CustomerName = $"customer name {3}",
                //    PostalCode = $"postal code {3}",
                //    Country = $"country {3}",
                //    Fax = $"fax {3}"
                //};

                //_ctx.Customers.Add(customer);

                //customer = new Customer
                //{
                //    //Orders = new List<Order>
                //    //{
                //    //    Orders[6],Orders[7]
                //    //},
                //    Phone = $"phone {4}",
                //    Address = $"address {4}",
                //    ContactName = $"contact name {4}",
                //    CustomerName = $"customer name {4}",
                //    PostalCode = $"postal code {4}",
                //    Country = $"country {4}",
                //    Fax = $"fax {4}"
                //};

                //_ctx.Customers.Add(customer);

                //customer = new Customer
                //{
                //    //Orders = new List<Order>
                //    //{
                //    //    Orders[8],Orders[9]
                //    //},
                //    Phone = $"phone {5}",
                //    Address = $"address {5}",
                //    ContactName = $"contact name {5}",
                //    CustomerName = $"customer name {5}",
                //    PostalCode = $"postal code {5}",
                //    Country = $"country {5}",
                //    Fax = $"fax {5}"
                //};

                //_ctx.Customers.Add(customer);

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

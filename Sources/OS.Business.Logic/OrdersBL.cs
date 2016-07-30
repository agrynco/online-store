using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using AGrynCo.Lib.ResourcesUtils;
using OS.Business.Domain;
using OS.Business.Logic.Exceptions;
using OS.Business.Logic.Mailing;
using OS.Configuration;
using OS.DAL.Abstract;
using RazorEngine;

namespace OS.Business.Logic
{
    public class CreateOrderQuery
    {
        public string AdditionalComment { get; set; }
        public IEnumerable<AddOrderedProductQuery> OrderedProducts { get; set; }
        public AddPersonQuery Person { get; set; }

        public class AddOrderedProductQuery
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class AddPersonQuery
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string PhoneNumber { get; set; }
        }
    }

    public class OrdersBL
    {
        private readonly IMailService _mailService;
        private readonly IOrderedProductsRepository _orderedProductsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderStatusHistoryItemsRepository _orderStatusHistoryItemsRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IUsersRepository _usersRepository;

        public OrdersBL(IPersonsRepository personsRepository, IOrdersRepository ordersRepository,
            IOrderStatusHistoryItemsRepository orderStatusHistoryItemsRepository,
            IOrderedProductsRepository orderedProductsRepository, IProductsRepository productsRepository,
            IMailService mailService, IUsersRepository usersRepository)
        {
            _personsRepository = personsRepository;
            _ordersRepository = ordersRepository;
            _orderStatusHistoryItemsRepository = orderStatusHistoryItemsRepository;
            _orderedProductsRepository = orderedProductsRepository;
            _productsRepository = productsRepository;
            _mailService = mailService;
            _usersRepository = usersRepository;
        }

        public Order CreateOrder(CreateOrderQuery createOrderQuery)
        {
            Person person = _personsRepository.Add(new Person
                {
                    Email = createOrderQuery.Person.Email,
                    FirstName = createOrderQuery.Person.FirstName,
                    LastName = createOrderQuery.Person.LastName,
                    MiddleName = createOrderQuery.Person.MiddleName,
                    PhoneNumber = createOrderQuery.Person.PhoneNumber
                });

            Order order = _ordersRepository.Add(new Order
                {
                    Person = person,
                    AdditionalComment = createOrderQuery.AdditionalComment
                });

            _orderStatusHistoryItemsRepository.Add(new OrderStatusHistoryItem
                {
                    Created = DateTime.Now,
                    OrderId = order.Id,
                    Status = OrderStatus.Open
                });

            foreach (CreateOrderQuery.AddOrderedProductQuery addOrderedProductQuery in createOrderQuery.OrderedProducts)
            {
                Product product = _productsRepository.GetById(addOrderedProductQuery.ProductId);
                _orderedProductsRepository.Add(new OrderedProduct
                    {
                        ProductId = addOrderedProductQuery.ProductId,
                        Product = product,
                        Quantity = addOrderedProductQuery.Quantity,
                        OrderId = order.Id,
                        PriceAtTheTimeOfPurchase = product.PriceInTheMainCurrency
                    });
                order.TotalAmount += product.PriceInTheMainCurrency * addOrderedProductQuery.Quantity;
            }

            _ordersRepository.Update(order);

            NotifyAboutOrder(order);

            return order;
        }

        private void NotifyAboutOrder(Order order)
        {
            IQueryable<ApplicationUser> administrators = _usersRepository.GetAdministrators();

            string template = ResourceReader.ReadAsString(GetType(), "OS.Business.Logic.EmailTemplates.OrderDetails.cshtml");

            string body;

            try
            {
                body = Razor.Parse(template, order);
            }
            catch (Exception ex)
            {
                throw new OrderNotificationMessageTextBuildException(order, ex);
            }

            MailMessage mailMessage = new MailMessage
                {
                    Subject = $"{ApplicationSettings.Instance.AppSettings.ApplicationName}: Замовлення",
                    Body = body,
                    From = new MailAddress(ApplicationSettings.Instance.MailServiceSettings.FromAddress,
                        ApplicationSettings.Instance.AppSettings.ApplicationName),
                    To = {order.Person.Email},
                    IsBodyHtml = true
                };
            mailMessage.CC.Add(string.Join(",", administrators.Select(admin => admin.Email)));

            _mailService.Send(mailMessage);
        }

        public Order GetById(int id)
        {
            return _ordersRepository.GetById(id);
        }
    }
}
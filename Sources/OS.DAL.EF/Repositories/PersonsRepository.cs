﻿using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.DAL.EF.Repositories
{
    public class PersonsRepository : BaseOnlineStoreCRUDRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}
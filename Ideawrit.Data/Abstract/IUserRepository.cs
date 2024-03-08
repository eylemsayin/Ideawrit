using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Data.Abstract
{
    public interface IUserRepository:IEntityRepository<User>
    {
    }
}

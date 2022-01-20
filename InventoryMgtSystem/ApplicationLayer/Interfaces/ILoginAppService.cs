using DataAccess.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface ILoginAppService
    {
        Task<IEnumerable<UserDetail>> GetUserDetailsByExpression(Expression<Func<UserDetail, bool>> predicate);
        TokenViewModel GetTokenModel(UserDetail user);
    }
}

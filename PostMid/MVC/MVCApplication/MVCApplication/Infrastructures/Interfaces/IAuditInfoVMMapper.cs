using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Infrastructures.Interfaces
{
    public interface IAuditInfoVMMapper<T, U>
        where T: class
        where U: AuditInformationVM
    {
        T Map(U obj);
        U Map(T obj);

        IEnumerable<T> Map(IEnumerable<U> objs);
        IEnumerable<U> Map(IEnumerable<T> objs);
    }
}
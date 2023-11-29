using MVCApplication.Infrastructures.Interfaces;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Infrastructures.Mappers
{
    public abstract class AuditInfoVMMapper<T, U> : IAuditInfoVMMapper<T, U>
        where T: class
        where U: AuditInformationVM
    {
        public abstract T Map(U obj);
        public abstract U Map(T obj);

        public IEnumerable<T> Map(IEnumerable<U> objs)
        {
            if (ReferenceEquals(objs, null))
                return null;

            var list = new List<T>();
            foreach (var obj in objs)
            {
                list.Add(Map(obj));
            }
            return list;
        }
        public IEnumerable<U> Map(IEnumerable<T> objs)
        {
            if (ReferenceEquals(objs, null))
                return null;

            var list = new List<U>();
            foreach (var obj in objs)
            {
                list.Add(Map(obj));
            }
            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestAssambly
{
    public class PersonService: IPersonService
    {

        public ValueTask<List<TResult>> GetPartAsync<TResult>(Func<Person, TResult> selresult, Func<Person, bool> predicate)
        {
            return new ValueTask<List<TResult>>(dataSource.Where(predicate).Select(selresult).ToList());
        }

        private static List<Person> dataSource=new List<Person>
        {
            new Person{ ID = 1,Name = "张三"},
            new Person{ ID = 2,Name = "李四"}
        };
    }

    public interface IPersonService
    {
        ValueTask<List<TResult>> GetPartAsync<TResult>(Func<Person, TResult> selresult, Func<Person, bool> predicate);
    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

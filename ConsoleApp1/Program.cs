using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAssambly;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = (await ProxyDecorator2<IPersonService, PersonService>.Create().GetPartAsync(x => new { x.ID, x.Name }, x => x.ID == 1));

            foreach (var item in items)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("结束");
        }
    }
}

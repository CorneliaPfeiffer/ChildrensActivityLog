using ChildrensActivityLog.Data;
using ChildrensActivityLog.Data.Repositories;
using ChildrensActivityLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChildrensActivityLog.ConsoleApp1
{
    
    class Program
    {
        //private readonly IChildrensAcitivityLogRepository _iRepo;
        //public Program(IChildrensAcitivityLogRepository iRepo)
        //{
        //    _iRepo = iRepo;
        //}
        private static void AddOneChild()
        {
            var child = new Child { DateOfBirth = Convert.ToDateTime("2002-01-22"), FirstName = "Sina", LastName = "Sinason" };
            using (var context = new ChildrensActivityLogContext())
            {
                context.Children.Add(child);
                context.SaveChanges();
            }
        }
        private static void GetAllChildren()
        { // IChildrensAcitivityLogRepository _iRepo = new ChildrensAcitivityLogRepository();

            //return _iRepo.GetAllChildren().ToString();
            using (var context = new ChildrensActivityLogContext())
            {
                var result = context.Children.ToList();
                foreach (var item in result)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
                static void Main(string[] args)
        {

            //AddOneChild();
            GetAllChildren();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
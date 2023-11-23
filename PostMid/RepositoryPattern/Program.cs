using Ninject;
using RepositoryPattern.Common.Infrastructure;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            new ReferenceFinder();

            //var repo = ReferenceFinder.Find<IRepository<User>>();
            //repo.Get();

            //var showroom = ReferenceFinder.Find<IShowroom>();
            //showroom.Display();

            var connString = ConfigurationManager.ConnectionStrings["MasterDB"].ConnectionString;
            Console.WriteLine(connString);
        }
    }

    public interface IVehicle
    {
        void Tell();
    }

    public class Car : IVehicle
    {
        public Car()
        {
            Console.WriteLine("CAR ctor");
        }

        public void Tell()
        {
            Console.WriteLine("CAR");
        }
    }
    public class Ship : IVehicle
    {
        public Ship()
        {
            Console.WriteLine("Ship ctor");
        }

        public void Tell()
        {
            Console.WriteLine("Ship");
        }
    }

    public interface IShowroom
    {
        void Display();
    }

    public class Showroom : IShowroom
    {
        private readonly IVehicle _vehicle;

        public Showroom(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Display()
        {
            _vehicle.Tell();
        }
    }
}

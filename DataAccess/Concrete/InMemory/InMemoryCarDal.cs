using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=90000, Description="-" },
                new Car{ Id=2, BrandId=1, ColorId=2, ModelYear=2014, DailyPrice=80000, Description="--" },
                new Car{ Id=3, BrandId=2, ColorId=1, ModelYear=2012, DailyPrice=60000, Description="---" },
                new Car{ Id=4, BrandId=4, ColorId=2, ModelYear=2018, DailyPrice=130000, Description="----" },
                new Car{ Id=5, BrandId=3, ColorId=3, ModelYear=2021, DailyPrice=160000, Description="-----" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetAllById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
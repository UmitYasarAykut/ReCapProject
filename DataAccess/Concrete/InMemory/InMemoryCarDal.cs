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
        private bool carToDelete;
        private int c;

        public InMemoryCarDal()
        {
                _cars = new List<Car> 
                {
                    new Car {Id=1, BrandId=1, ColorId = "Beyaz", ModelYear=2018, DailyPrice=780, Description= "Toyota Corolla Manuel" },
                    new Car {Id=2, BrandId=1, ColorId = "Siyah", ModelYear=2020, DailyPrice=900, Description= "Toyota Corolla Otomatik" },
                    new Car {Id=3, BrandId=1, ColorId = "Gri", ModelYear=2021, DailyPrice=850, Description= "Toyota Corolla Otomatik" },
                    new Car {Id=4, BrandId=2, ColorId = "Kırmızı", ModelYear=2022, DailyPrice=1100, Description= "BMW F30 Otomatik" },
                    new Car {Id=5, BrandId=2, ColorId = "Mavi", ModelYear=2023, DailyPrice=1200, Description= "BMW 418 Manuel" }
                };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
           Car  carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }


        public List<Car> GetById(int id)
        {
          return _cars.Where(c=>c.Id==id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.Description= car.Description;
            carToUpdate.ModelYear= car.ModelYear;
            
        }
    }
}

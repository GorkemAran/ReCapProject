using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Colors.Add(color);
                context.SaveChanges();
            }
        }

        public void Delete(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Colors.Remove(context.Colors.SingleOrDefault(c => c.ColorId == color.ColorId));
                context.SaveChanges();
            }
        }

        public List<Color> GetAll()
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Colors.ToList();
            }
        }

        public void Update(Color color)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var colorToUpdate = context.Colors.SingleOrDefault(c => c.ColorId == color.ColorId);
                colorToUpdate.ColorId = color.ColorId;
                colorToUpdate.ColorName = color.ColorName;
                context.SaveChanges();
            }
        }

        Color IColorService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

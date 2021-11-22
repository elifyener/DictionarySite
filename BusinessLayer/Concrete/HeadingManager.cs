﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public List<Heading> GetListByWriterSearch(string p, int id)
        {
           
            if(string.IsNullOrEmpty(p))
            {
                return _headingDal.List(x => x.WriterID == id);
            }
            else
            {
                return _headingDal.List(x => x.WriterID == id && x.HeadingName.Contains(p));
            }
        }

        public List<Heading> GetListByCategorySearch(string p, int id)
        {
            if (string.IsNullOrEmpty(p))
            {
                return _headingDal.List(x => x.CategoryID == id);
            }
            else
            {
                return _headingDal.List(x => x.CategoryID == id && x.HeadingName.Contains(p));
            }
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
        public List<Heading> GetListSearch(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return _headingDal.List();
            }
            else
            {
                return _headingDal.List(x => x.HeadingName.Contains(p));
            }
        }
    }
}

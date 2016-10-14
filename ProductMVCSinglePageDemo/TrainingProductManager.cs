using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVCSinglePageDemo
{
    public class TrainingProductManager
    {

        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<String, String>>();
        }

        public List<KeyValuePair<String, String>> ValidationErrors { get; set; }

        public Boolean Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();

            if (!String.IsNullOrEmpty(entity.ProductName))
            {

                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Productname must not be all lower case."));
                }
            }

            return (ValidationErrors.Count == 0);
        }

        public bool Insert(TrainingProduct Entity)
        {
            bool ret = false;

            ret = Validate(Entity);

            if(ret)
            {
                //Create Insert code here
            }

            return ret;
        }
            

    public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret = CreateMockData();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                //This area filters the class - Search 
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
                //ret = ret.FindAll(p => p.ProductName.StartsWith(entity.ProductName));
            }
            return ret;
        }

        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret.Add(new TrainingProduct()
            {
                ProductID = 1,
                ProductName = "Samsung TV",
                Introductiondate = Convert.ToDateTime("02/18/2015"),
                Url = "www.samsung.com",
                Price = Convert.ToDecimal(450.1)
            });
            ret.Add(new TrainingProduct()
            {
                ProductID = 2,
                ProductName = "LG TV",
                Introductiondate = Convert.ToDateTime("03/18/2015"),
                Url = "www.LG.com",
                Price = Convert.ToDecimal(500.1)

            });
            ret.Add(new TrainingProduct()
            {
                ProductID = 3,
                ProductName = "AppleTV",
                Introductiondate = Convert.ToDateTime("04/18/2015"),
                Url = "www.Apple.com",
                Price = Convert.ToDecimal(150.1)

            });
            ret.Add(new TrainingProduct()
            {
                ProductID = 4,
                ProductName = "Samsung AC",
                Introductiondate = Convert.ToDateTime("06/18/2016"),
                Url = "www.samsung.com",
                Price = Convert.ToDecimal(350.1)

            });
            ret.Add(new TrainingProduct()
            {
                ProductID = 5,
                ProductName = "Samsung tab",
                Introductiondate = Convert.ToDateTime("10/18/2016"),
                Url = "www.samsung.com",
                Price = Convert.ToDecimal(100.45)

            });

            return ret;
        }



    }
}
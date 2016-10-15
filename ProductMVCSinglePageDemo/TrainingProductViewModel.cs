using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductMVCSinglePageDemo;

namespace ProductMVCSinglePageDemo
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()
        {
            // init();
        }

        //Step1
        public List<TrainingProduct> Products { get; set; }
        //Step3 - Creating for Search functionality implementation
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }

        protected override void init()
        {
            base.init();

            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
        }

        protected override void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct();
            Entity.Introductiondate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            base.Add();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            //Entity holds the current ProductID
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            // Entity = mgr.Get(Convert.ToInt32("6"));

            //Set to Edit view Mode
            base.Edit();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductID = Convert.ToInt32(EventArgument);
            mgr.Delete(Entity);

            Get();
            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
            base.Get();
        }

        protected override void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else //Edit mode
            {
                mgr.Update(Entity);
            }
            ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        public override void HandleRequest()
        {
            base.HandleRequest();
        }

    }
}
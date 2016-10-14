using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductMVCSinglePageDemo;


namespace ProductMVCSinglePageDemo
{
    public class TrainingProductViewModel
    {


        public TrainingProductViewModel()
        {
            init();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
        }

        //step2
        public string EventCommand { get; set; }
        //Step1
        public List<TrainingProduct> Products { get; set; }
        //Step3 - Creating for Search functionality implementation
        public TrainingProduct SearchEntity { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public TrainingProduct Entity { get; set; }
        public Boolean IsValid { get; set; }
        public string Mode { get; set; }

        public List<KeyValuePair<String, String>> ValidationErrors { get; set; }


        private void init()
        {
            listmode();

            ValidationErrors = new List<KeyValuePair<String, String>>();

            EventCommand = "List";

        }

        private void listmode()
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.Introductiondate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            Addmode();
        }

        private void Addmode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }

        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

            if(ValidationErrors.Count>0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    Addmode();
                }
            }
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "cancel":
                    listmode();
                    Get();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
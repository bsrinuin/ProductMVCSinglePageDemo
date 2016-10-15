using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVCSinglePageDemo
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            init();
        }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        //step2
        public string EventCommand { get; set; }
        public Boolean IsValid { get; set; }
        public string Mode { get; set; }

        public List<KeyValuePair<String, String>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        //Protected - can be inherited, Virtual Override incase if any added
        protected virtual void listmode()
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void init()
        {
            listmode();
            ValidationErrors = new List<KeyValuePair<String, String>>();
            EventCommand = "List";
            EventArgument = String.Empty;

        }

        protected virtual void Addmode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        protected virtual void Editmode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        protected virtual void Get()
        { }

        //Moved from Training ProductVM
        protected virtual void ResetSearch()
        {        }

        protected virtual  void Add()
        {
            Addmode();
        }

        protected virtual void Edit()
        {
            Editmode();
        }

        protected virtual void Delete()
        {
            listmode();
        }

        protected virtual void Save()
        {
             if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    Addmode();
                }
                else //Edit Mode 
                {
                    Editmode();
                }
            }
        }

        //Create a public method to handle CRUD - we expose only this method
        public virtual void HandleRequest()
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

                case "edit":
                    //edit
                    //System.Diagnostics.Debugger.Break();
                    IsValid = true;
                    //Grab the data  to be displayed
                    Edit();
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

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                default:
                    break;
            }
        }

    }
}
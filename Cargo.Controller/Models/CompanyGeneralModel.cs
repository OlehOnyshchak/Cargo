﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using System.ComponentModel;

namespace Cargo.Controller.Models
{
    public class CompanyGeneralModel : INotifyPropertyChanged
    {
        private string title;
        private string taxNum;
        private string email;
        private string phone;
        private string companyType;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string TaxNumber  
        {
            get { return taxNum; }
            set
            {
                taxNum = value;
                OnPropertyChanged("TaxNumber");
}
        }

        public string Email     
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string CompanyType
        {
            get { return companyType; }
            set
            {
                companyType = value;
                OnPropertyChanged("CompanyType");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
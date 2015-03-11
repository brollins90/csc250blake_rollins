﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans.Models
{
    public class DataPoint : INotifyPropertyChanged
    {
        private int _type;
        private double _variableX, _variableY;
        private string _id;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Type
        {
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
            get { return _type; }
        }

        public double VariableX
        {
            set
            {
                if (_variableX != value)
                {
                    _variableX = value;
                    OnPropertyChanged("VariableX");
                }
            }
            get { return _variableX; }
        }

        public double VariableY
        {
            set
            {
                if (_variableY != value)
                {
                    _variableY = value;
                    OnPropertyChanged("VariableY");
                }
            }
            get { return _variableY; }
        }

        public string Id
        {
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
            get { return _id; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

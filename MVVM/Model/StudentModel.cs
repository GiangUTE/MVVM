using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace MVVM.Model
{
    class StudentModel
    {
    }
    public class Student:INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName!=value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("LastName");
                }
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName!=value)
                {
                    lastName = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("LastName");
                }
            }
        }
        public string FullName
        {
            get
            {
                return firstName + " " + lastName;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

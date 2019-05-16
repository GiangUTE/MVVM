using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Model;
using System.Collections.ObjectModel;
namespace MVVM.ViewModel
{
    class StudentViewModel
    {
        public StudentViewModel()
        {
            LoadStudents();
        }
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brow" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });
            Students = students;
        }
    }
}

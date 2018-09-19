using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    public class Employe
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dol { get; set; }
        public string NumberPhone { get; set; }  
        public Employe(string fName,string lName,string dol,string numPhone)
        {
            FirstName = fName;
            LastName = lName;
            Dol = dol;
            NumberPhone = numPhone;            
        }
        public Employe()
        {
            FirstName = null;LastName = null;Dol = null;NumberPhone = null;
        }
        public static bool operator ==(Employe e1, Employe e2)
        {
            if (e1.FirstName == e2.FirstName && e1.Dol == e2.Dol &&
                e1.LastName == e2.LastName && e1.NumberPhone == e2.NumberPhone) return true;
            return false;
        }
        public static bool operator !=(Employe e1, Employe e2)
        {
            return !(e1 == e2);
        }
        public Employe(ref Employe e)
        {
            Console.WriteLine("Конструктор копирования!");
            FirstName = e.FirstName;LastName = e.LastName;
            Dol = e.Dol;NumberPhone = e.NumberPhone;
        }
    }
    public interface IMethod
    {
        void Add(Employe emplaye);
        void Show();
        void Delete(Employe e);
    }
    public class Employess:IMethod
    {
        public Employe[] Array { get; set; }
        public int Count { get; set; }
        public Employe this[int index]
        {
            set
            {
                Array[index] = value;
            }
            get
            {
                return Array[index];
            }
        }
        public Employess() { Array =new Employe[100]; Count = 0; }
      public void Add(Employe employe)
        {
           // Array[Count] = new Employe();
            Array[Count] = employe;
            Count++;
        }
        public void Delete(Employe employe)
        {
            for(int i = 0; i < Count; i++)
            {
                if (Array[i] == employe)
                {
                    Array[i].Dol = "-";
                }
            }
        }
        public void Show()
        {
            Console.WriteLine("count="+Count);
            for(int i = 0; i < Count; i++)
            {
                if (Array[i].Dol == "-") continue;
                Console.WriteLine(Array[i].FirstName+" "+Array[i].LastName+"  "
                    +Array[i].Dol+"  "+Array[i].NumberPhone);
            }
        }
        
    }
}

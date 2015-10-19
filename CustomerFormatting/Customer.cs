using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerFormatting
{
    public class Customer
    {
        private string name;
        private string contactPhone;

        public string Name 
        {
            get { return name; }
            set
            {
                Regex r = new Regex(@"^[a-zA-Z-'\s]{1,40}$");
                if (!r.IsMatch(value))
                    throw new ArgumentException();
                else
                    name = value;
            }
        }
        public string ContactPhone
        {
            get { return contactPhone; }
            set
            {
                Regex r = new Regex(@"^\+?\d{1,3} ?\(\d{2,3}\) ?\d{3}-\d{4}$");
                if (!r.IsMatch(value))
                    throw new ArgumentException();
                else
                {
                    if (value[0] != '+')
                        value = value.Insert(0, "+");
                    int index = value.IndexOf('(');
                    if (value[index - 1] != ' ')
                        value = value.Insert(index, " ");
                    index = value.IndexOf(')');
                    if (value[index+1] != ' ')
                        value = value.Insert(index + 1, " ");
                    contactPhone = value;
                }                    
            }
        }
        public decimal Revenue { get; set; }
    }
}

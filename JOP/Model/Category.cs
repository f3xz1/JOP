using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOP
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products{get;set;}


        //[NotMapped]
        //public virtual Product IdProductNavigation { get; set; } = null!;
        public Category(string name)
        {
            this.Name = name;
        }
        public Category()
        {

        }
    }
}

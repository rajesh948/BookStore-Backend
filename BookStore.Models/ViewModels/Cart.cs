using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models.ViewModels
{
    public partial class Cart
    {
    public Cart()
        {
               Books = new HashSet<Book>();
             Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
       public int Bookid { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<User> Users{ get; set; }

    }
}

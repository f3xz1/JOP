using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JOP
{
    public class User
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public List<Product> qwe { get; set; }
        public bool IsAdmin { get; set; }

        public User(string login, string password, string name, string surname, string email, bool IsAdmin = false)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.qwe = new();
            this.Email = email;
            this.IsAdmin = IsAdmin;
        }
        public User()
        {

        }
        public async Task create_user_async()
        {
            try
            {
                using (DBContext db = new())
                {
                    db.Users.Add(this);// await
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CreateUserThrow");
                throw;
            }
        }
        public bool create_user()
        {
            try
            {
                using (DBContext db = new())
                {
                    db.Users.Add(this);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CreateUserThrow");
                throw;
            }
            return true;
        }
        public void LoadCustomers()
        {

        }
        public void LoadOrders()
        {

        }
        public void AddOrder()
        {

        }
        public void Update_Orders()
        {

        }
        public void Upload_Customers()
        {

        }
    }
}

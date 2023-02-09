using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigos.Domain.Friend
{
    public class Friend
    {
        public Friend(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSelected { get; set; } = false;



        public void SelectFriend()
        {
            
            if (IsSelected == true)
            {
                IsSelected = false;
            }
            else
            {
                IsSelected = true;
            }
        }




    }
}

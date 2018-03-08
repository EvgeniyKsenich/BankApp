using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BA.Web.Modeles
{
	public class UserView
	{
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Balance { get; set; }
    }
}
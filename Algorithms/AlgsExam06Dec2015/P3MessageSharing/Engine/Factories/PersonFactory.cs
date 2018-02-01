using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Persons;

namespace P3MessageSharing.Engine.Factories
{
    public class PersonFactory
    {
        public Person CreatePerson(string name)
        {
            Person person = new Person(name);
            return person;
        }
    }
}

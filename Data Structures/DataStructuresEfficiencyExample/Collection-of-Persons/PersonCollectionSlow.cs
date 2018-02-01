using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private List<Person> persons;

    public PersonCollectionSlow()
    {
        this.persons = new List<Person>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;   
        }
        
        var person = new Person(email, name, age, town);
        
        this.persons.Add(person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.persons.Count;
        }
    }

    public Person FindPerson(string email)
    {
        var personByEmail = this.persons.FirstOrDefault(p => p.Email == email);

        return personByEmail;
    }

    public bool DeletePerson(string email)
    {
        var personByEmail = this.FindPerson(email);
        if (personByEmail == null)
        {
            return false;
        }

        this.persons.Remove(personByEmail);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var personsByEmailDomain = this.persons.Where(p => p.Email.EndsWith("@" + emailDomain)).
            OrderBy(p => p.Email);

        return personsByEmailDomain;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var personsByNameAndTown = this.persons.Where(p => p.Name == name && p.Town == town).
            OrderBy(p => p.Email);

        return personsByNameAndTown;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsByAgeRange = this.persons.Where(p => p.Age >= startAge && p.Age <= endAge).
            OrderBy(p => p.Age).ThenBy(p => p.Email);

        return personsByAgeRange;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var personsByAgeRangeAndTown = this.persons.Where(p => p.Age >= startAge && p.Age <= endAge).
            Where(p => p.Town == town).OrderBy(p => p.Age).ThenBy(p => p.Email);

        return personsByAgeRangeAndTown;
    }
}

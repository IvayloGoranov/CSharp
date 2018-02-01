using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail;
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain;
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> personsByAge;
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

    public PersonCollection()
    {
        this.personsByEmail = new Dictionary<string, Person>();
        this.personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        this.personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        this.personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }
    
    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person(email, name, age, town);
        this.personsByEmail.Add(email, person);

        string emailDomain = this.EtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        string nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personsByAge.AppendValueToKey(age, person);

        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        bool personExists = this.personsByEmail.TryGetValue(email, out person);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }

        var personDeleted = this.personsByEmail.Remove(email);

        string emailDomain = this.EtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        string nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        int personAge = person.Age;
        this.personsByAge[personAge].Remove(person);

        string town = person.Town;
        this.personsByTownAndAge[town][personAge].Remove(person);

        return personDeleted;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var personsByEmailDomain = this.personsByEmailDomain.GetValuesForKey(emailDomain);

        return personsByEmailDomain;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameAndTown = this.CombineNameAndTown(name, town);
        var personsByNameAndTown = this.personsByNameAndTown.GetValuesForKey(nameAndTown);

        return personsByNameAndTown;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsByAgeRange = this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsByAgeRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            //Returns an empty sequence of persons.
            yield break;
        }

        var personsByTownInAgeRange = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsByTownInAgeRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    private string EtractEmailDomain(string email)
    {
        int indexOfSeparator = email.IndexOf("@");
        int startIndex = indexOfSeparator + 1;
        string emailDomain = email.Substring(startIndex);

        return emailDomain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string Separator = "|!|";

        return name + Separator + town;
    }
}

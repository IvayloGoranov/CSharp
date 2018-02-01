using System;

public class Person : IComparable<Person>
{
    public Person(string eMail, string name, int age, string town)
    {
        this.Email = eMail;
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }
    
    public string Email { get; set; }

    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Town { get; set; }

    public int CompareTo(Person otherPerson)
    {
        if (otherPerson == null)
        {
            return -1;   
        }

        return this.Email.CompareTo(otherPerson.Email);
    }

    public override bool Equals(object obj)
    {
        var otherPerson = obj as Person;
        if (otherPerson == null)
        {
            return false;
        }

        if (this.Email == otherPerson.Email)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Email.GetHashCode();
    }
}

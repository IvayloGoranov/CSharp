
namespace PizzaMore.Utility
{
    public class Cookie
    {
        public Cookie()
        {
        }

        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Set-Cookie: {0}={1}", this.Name, this.Value);
        }
    }
}

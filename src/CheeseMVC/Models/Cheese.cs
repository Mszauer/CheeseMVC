namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }
        public int Rating { get; set; }
        public int ID { get; set; }

        public Cheese(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public Cheese()
        {
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return ID == (obj as Cheese).ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }
    }
}

namespace DNP2.Models
{
    public class Pet
    {
        public string Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Species: {Species} Age: {Age}";
        }
    }
}
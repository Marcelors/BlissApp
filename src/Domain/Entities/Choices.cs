namespace Domain.Entities
{
    public class Choices : Entity
    {
        public string Choice { get; private set; }
        public int Votes { get; private set; }

        private Choices() { }

        public Choices(string choice)
        {
            Choice = choice;
            Votes = 0;
        }
    }
}

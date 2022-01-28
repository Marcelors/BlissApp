namespace Domain.Entities
{
    public class Choices : Entity
    {
        public string Choice { get; private set; }
        public int Votes { get; private set; }
        public Questions Question { get; private set; }
        public int QuestionId { get; private set; }

        private Choices() { }

        public Choices(string choice)
        {
            Choice = choice;
            Votes = 0;
        }

        public Choices(string choice, int votes)
        {
            Choice = choice;
            Votes = votes;
        }

        public Choices(int id, int questionId, string choice, int votes)
        {
            SetId(id);
            QuestionId = questionId;
            Choice = choice;
            Votes = votes;
        }

        public void SetVotes(int votes)
        {
            Votes = votes;
        }
    }
}

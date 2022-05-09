namespace AdventureApp.DataAccess.Entities
{
    public class UserAdventure
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int AdventureId { get; set; }

        public virtual Adventure Adventure { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}

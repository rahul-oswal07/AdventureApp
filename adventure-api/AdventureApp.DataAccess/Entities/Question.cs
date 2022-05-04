namespace AdventureApp.DataAccess.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Value { get; set; }

        public virtual IEnumerable<Question>? Questions { get; set; }

    }
}

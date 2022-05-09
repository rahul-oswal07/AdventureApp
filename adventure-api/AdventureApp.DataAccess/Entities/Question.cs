namespace AdventureApp.DataAccess.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Value { get; set; }

        public int? ParentQuestionId { get; set; }

        public virtual Question? ParentQuestion { get; set; }

        public virtual ICollection<Question>? Questions { get; set; }

    }
}

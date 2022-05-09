namespace AdventureApp.DataAccess.Entities
{
    public class Adventure
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int? RootQuestionId { get; set; }

        public virtual Question? RootQuestion { get; set; }
    }
}
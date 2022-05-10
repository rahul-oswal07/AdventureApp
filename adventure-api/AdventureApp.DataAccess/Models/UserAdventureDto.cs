namespace AdventureApp.DataAccess.Models
{
    public class UserAdventureDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AdventureId { get; set; }

        public int? RootQuestionId { get; set; }

        public int LeafQuestionId { get; set; }

        public QuestionDto Question { get; set; }

    }
}

namespace AdventureApp.DataAccess.Models
{
    public class UserAdventureDto
    {
        public string Name { get; set; }

        public int AdventureId { get; set; }

        public QuestionDto Question { get; set; }

    }
}

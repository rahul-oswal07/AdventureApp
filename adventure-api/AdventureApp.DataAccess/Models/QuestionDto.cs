namespace AdventureApp.DataAccess.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public bool Value { get; set; }

        public IEnumerable<QuestionDto>? Questions { get; set; }
    }
}

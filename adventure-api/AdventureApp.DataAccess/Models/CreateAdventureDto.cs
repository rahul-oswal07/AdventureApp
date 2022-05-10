namespace AdventureApp.DataAccess.Models
{
    public class CreateAdventureDto
    {
        public string Name { get; set; }

        public QuestionDto RootQuestion { get; set; }   

    }
}

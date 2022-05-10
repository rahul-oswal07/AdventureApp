namespace AdventureApp.DataAccess.Models
{
    public  class CreateQuestionDto
    {
        public string Name { get; set; }

        public bool Value { get; set; }

        public IEnumerable<CreateAdventureDto>? Questions { get; set; }  
    }
}

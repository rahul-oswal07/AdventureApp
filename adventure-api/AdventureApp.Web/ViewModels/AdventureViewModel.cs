using AdventureApp.DataAccess.Entities;

namespace AdventureApp.Web.ViewModels
{
    public class AdventureViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RootQuestionId { get; set; }

        public virtual Question RootQuestion { get; set; }

    }
}

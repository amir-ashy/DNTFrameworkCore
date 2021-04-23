using DNTFrameworkCore.Domain;

namespace DNTFrameworkCore.TestWebApp.Domain.Tasks
{
    public class Task : Entity, IHasRowVersion, IHasRowIntegrity, INumberedEntity
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 1024;

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; } = TaskState.Todo;
        public string Number { get; set; }
        public byte[] Version { get; set; }
    }
}
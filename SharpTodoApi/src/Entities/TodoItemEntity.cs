using System.ComponentModel.DataAnnotations.Schema;

namespace SharpTodoApi.Entities;

public class TodoItemEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsComplete { get; set; }
}

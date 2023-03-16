using System.ComponentModel.DataAnnotations;

namespace Yan.Demo.Request;

public class MessageRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Message { get; set; }
}

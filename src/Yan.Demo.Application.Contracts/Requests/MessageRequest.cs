using System;
using System.ComponentModel.DataAnnotations;

namespace Yan.Demo.Requests;

public class MessageRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Message { get; set; }
    [Required]
    public DateTime CreateDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}

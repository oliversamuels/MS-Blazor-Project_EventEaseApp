using System;
using System.ComponentModel.DataAnnotations;

namespace EventEaseApp;
public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    [StringLength(100, ErrorMessage = "Event name can't be longer than 100 characters.")]
    public string? EventName { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(200, ErrorMessage = "Location can't be longer than 200 characters.")]
    public string? Location { get; set; }

    public List<Attendee> Attendees { get; set; } = new List<Attendee>();
}
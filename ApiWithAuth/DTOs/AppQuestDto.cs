﻿namespace ApiWithAuth.DTOs;

public class AppQuestDto
{

    public long Id { get; set; }
    public string? Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; } = false;
    public bool Status { get; set; } = false;
    
    
    public List<string> Links { get; set; } = new List<string>();
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiWithAuth.Entity;

public class AppQuest
{
    
    public int Id { get; set; }
    public int AppPlanId { get; set; }
    public string? Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; } = false;
    public bool Status { get; set; } = false;
    public AppPlan? AppPlan{ get; set; }
    public List<string> Links { get; set; } = new List<string>();


}
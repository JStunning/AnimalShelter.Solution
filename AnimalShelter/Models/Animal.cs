using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace AnimalShelter.Models
{
  public class Animal
  {
    [Required]
    public int AnimalId { get; set; }
    public string AnimalName { get; set; }
    public string Species { get; set; }
    public string Gender { get; set; }

    public List<int> AnimalIds = new List<int>();
  }
}
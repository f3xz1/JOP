﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Windows;

namespace JOP;

public partial class User
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Surname { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<TakenProduct> TakenProducts { get; } = new List<TakenProduct>();
    public User(string login, string password, string name, string surname, string email, bool IsAdmin = false)
    {
        this.Login = login;
        this.Password = password;
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
        this.IsAdmin = IsAdmin;
    }
    public User()
    {

    }
}
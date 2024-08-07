﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class UserListViewModel
{
    public List<UserListItemViewModel> Items { get; set; } = new();
}

public class UserListItemViewModel
{
    public long Id { get; set; }

    public string? Forename { get; set; }

    public string? Surname { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateOnly DateOfBirth { get; set; }
}

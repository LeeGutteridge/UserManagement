using System.Collections;
using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> GetAll();
    User FilterByID(int Id);
    void SaveChanges(User changes);
    void DeleteUser(User deleteUser);
    IEnumerable UserChange(User trackUser);
}

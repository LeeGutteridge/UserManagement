using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive) =>
        _dataAccess.GetAll<User>().Where(p => p.IsActive == isActive);

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

    public User FilterByID(int Id) =>
        _dataAccess.GetAll<User>().Where(p => p.Id == Id).First() ?? new User();

    public void SaveChanges(User changes) => _dataAccess.Update(changes);

    public void DeleteUser(User deleteUser) => _dataAccess.Delete(deleteUser);

    public IEnumerable UserChange(User trackUser) => _dataAccess.Changes(trackUser);
}

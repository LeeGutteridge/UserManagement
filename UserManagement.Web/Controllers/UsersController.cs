using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("")]
    public ViewResult List()
    {
        var items =
            _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpGet("{isActive}")]
    public ViewResult List(bool isActive)
    {
        var items =
            _userService.FilterByActive(isActive).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel { Items = items.ToList() };
        return View(model);
    }

    [HttpGet("edit/{id}")]
    public ViewResult EditDetail(int id)
    {
        var item = _userService.FilterByID(id);
        var modelItem =  new UserListItemViewModel
        {
            Id = item.Id,
            Forename = item.Forename,
            Surname = item.Surname,
            Email = item.Email,
            IsActive = item.IsActive,
            DateOfBirth = item.DateOfBirth
        };

        var model = modelItem;
        return View(model);
    }

    [HttpPost("edit/{id}")]
    public ActionResult EditDetail(UserListItemViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        {
            var user = new User
            {
                Id = model.Id,
                Forename = model.Forename ?? "",
                Surname = model.Surname ?? "",
                Email = model.Email ?? "",
                IsActive = model.IsActive,
                DateOfBirth = model.DateOfBirth

            };
            _userService.SaveChanges(user);
            return RedirectToAction("List");
        }
    }

    [HttpGet("view/{id}")]
    public ViewResult ViewDetail(int id)
    {
        var item = _userService.FilterByID(id);
        var modelItem =  new UserListItemViewModel
        {
            Id = item.Id,
            Forename = item.Forename,
            Surname = item.Surname,
            Email = item.Email,
            IsActive = item.IsActive,
            DateOfBirth = item.DateOfBirth
        };

        var model = modelItem;
        return View(model);
    }

    [HttpPost("view/{id}")]
    public ActionResult ViewDetail(UserListItemViewModel model)
    {
        return RedirectToAction("List");
    }

    [HttpGet("delete")]
    public ActionResult DeleteUser(int id)
    {
        var user =  new User()
        {
            Id = id
        };

        _userService.DeleteUser(user);

        return RedirectToAction("List");
    }

    [HttpGet("add")]
    public ViewResult AddUser()
    {
        return View();
    }

    [HttpPost("add")]
    public ActionResult AddUser(UserListItemViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        {
            var user = new User
            {
                Forename = model.Forename ?? "",
                Surname = model.Surname ?? "",
                Email = model.Email ?? "",
                IsActive = model.IsActive,
                DateOfBirth = model.DateOfBirth
            };
            _userService.SaveChanges(user);
            return RedirectToAction("List");
        }
    }
}

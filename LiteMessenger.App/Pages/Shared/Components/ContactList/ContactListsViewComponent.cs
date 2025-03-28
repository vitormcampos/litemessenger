using Microsoft.AspNetCore.Mvc;

namespace LiteMessenger.App.Pages.Shared.Components.ContactList;

public class ContactListViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

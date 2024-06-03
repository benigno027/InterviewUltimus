using EntrevistaUltimus.Models;
using X.PagedList;

namespace EntrevistaUltimus.ViewModels
{
    public class UsersViewModel
    {
        public IPagedList<User> Users { get; set; }
    }
}

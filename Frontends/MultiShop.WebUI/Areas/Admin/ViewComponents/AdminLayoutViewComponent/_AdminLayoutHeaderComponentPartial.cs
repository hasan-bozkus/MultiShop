using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            string id = user.Id;
            var TotalMessageCount = await _messageService.GetTotalMessageCountByReceiverId(id);
            ViewBag.TotalMessageCount = TotalMessageCount;

            var TotalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.TotalCommentCount = TotalCommentCount;
            return View();
        }
    }
}

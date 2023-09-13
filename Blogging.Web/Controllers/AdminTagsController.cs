using Blogging.Web.Data;
using Blogging.Web.Models.Domain;
using Blogging.Web.Models.ViewModels;
using Blogging.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTag addTag)
        {
            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];
            //var name = addTag.Name;
            //var displayName = addTag.DisplayName;

            var tag = new Tag
            {
                Name = addTag.Name,
                DisplayName = addTag.DisplayName,
            };
            await tagRepository.AddAsync(tag);
            return RedirectToAction("List");
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);
            if (tag != null)
            {
                var editTagRequest = new EditTag
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };
                return View(editTagRequest);
            }
            return View(null);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(EditTag editTag)
        {
            var tag = new Tag
            {
                Id = editTag.Id,
                Name = editTag.Name,
                DisplayName = editTag.DisplayName,
            };
            var updated_tag = await tagRepository.UpdateAsync(tag);
            if(updated_tag != null)
            {
                //show success notification
                return RedirectToAction("List");
            }
            else
            {
                //show error notification
                return RedirectToAction("Edit", new { id = editTag.Id });
            }          

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(EditTag editTag)
        {
            var tag = await tagRepository.DeleteAsync(editTag.Id);
            if (tag != null)
            {               
                //show success notification
                return RedirectToAction("List");
            }
            //show error notification
            return RedirectToAction("Edit", new { Id = editTag.Id });
        }

    }
}

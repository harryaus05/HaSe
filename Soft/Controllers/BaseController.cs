using HaSe.Domain.Common;
using HaSe.Facade;
using HaSe.Facade.Contoso;
using HaSe.Helpers.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Soft.Controllers {
    public abstract class BaseController<TModel, TViewModel>(IPagedRepo<TModel> r) : Controller where TModel : class where TViewModel : EntityViewModel, new() {
        protected readonly IPagedRepo<TModel> repo = r;
        protected abstract TModel ToModel(TViewModel viewmodel);
        protected virtual async Task PopulateRelatedItems(TModel? model) => await Task.CompletedTask;
        protected virtual TViewModel ToViewModel(TModel model) => PropertyCopier.CopyPropertiesFrom<TModel, TViewModel>(model);
        protected virtual string selectItemTextField => nameof(EntityViewModel.Id);
        protected internal async Task<SelectList> SelectListAsync() {
            repo.PageSize = repo.TotalItems;
            var departments = (await repo.GetAsync()).Select(ToViewModel);
            return new SelectList(departments, nameof(DepartmentViewModel.Id), selectItemTextField);
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber) {
            repo.PageNumber = pageNumber;
            repo.SearchString = searchString;
            repo.SortOrder = sortOrder;
            ViewBag.HasNextPage = repo.HasNextPage;
            ViewBag.HasPreviousPage = repo.HasPreviousPage;
            ViewBag.PageNumber = repo.Page;
            ViewBag.SearchString = repo.SearchString;
            ViewBag.SortOrder = repo.SortOrder;
            ViewBag.TotalPages = repo.TotalPages;
            var list = await repo.GetAsync();
            var viewList = list.Select(ToViewModel);
            return View(viewList);
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null)
                return NotFound();
            var model = await repo.GetAsync(id);
            return model == null ? NotFound() : View(ToViewModel(model));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(TViewModel view) {
            if (!ModelState.IsValid)
                return View(view);
            if (await repo.AddAsync(ToModel(view)))
                return RedirectToAction(nameof(Index));
            return View(view);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null)
                return NotFound();
            var model = await repo.FindAsync(id);
            await PopulateRelatedItems(model);
            return model == null ? NotFound() : View(ToViewModel(model));
        }

        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(TViewModel view) {
            if (!ModelState.IsValid)
                return View(view);
            if (await repo.UpdateAsync(ToModel(view)))
                return RedirectToAction(nameof(Index));
            return View(view);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();
            var model = await repo.GetAsync(id);
            return model == null ? NotFound() : View(ToViewModel(model));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var deleteResult = await repo.DeleteAsync(id);
            if (!deleteResult)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
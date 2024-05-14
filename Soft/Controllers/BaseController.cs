using HaSe.Domain.Common;
using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Soft.Controllers {
    public abstract class BaseController<TModel, TViewModel>(IRepo<TModel> r) : Controller where TModel : class where TViewModel : EntityViewModel, new() {
        protected readonly IRepo<TModel> repo = r;
        protected bool loadLazy;
        protected abstract TModel ToModel(TViewModel viewmodel);
   
        protected virtual async Task PopulateRelatedItems(TModel? model) => await Task.CompletedTask;
        protected virtual TViewModel ToViewModel(TModel model) => PropertyCopier.CopyPropertiesFrom<TModel, TViewModel>(model);
        protected virtual string selectItemTextField => nameof(EntityViewModel.Id);
        protected internal async Task<SelectList> SelectListAsync() {
            repo.PageSize = repo.TotalItems;
            var departments = (await repo.GetAsync()).Select(ToViewModel);
            return new SelectList(departments, nameof(PartSpecificationViewModel.Id), selectItemTextField);
        }
        protected async virtual Task LoadRelatedItems(TModel? m) => await Task.CompletedTask;
        protected bool loadlazy;
        protected virtual async Task<TViewModel> ToViewAsync(TModel m) {
            await Task.CompletedTask;
            return Copy.Members<TModel, TViewModel>(m);
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber) {
            loadLazy = false;
            repo.PageNumber = pageNumber;
            repo.SearchString = searchString;
            repo.SortOrder = sortOrder;
            ViewBag.HasNextPage = repo.HasNextPage;
            ViewBag.HasPreviousPage = repo.HasPreviousPage;
            ViewBag.PageNumber = repo.PageNumberAsInt;
            ViewBag.SearchString = repo.SearchString;
            ViewBag.SortOrder = repo.SortOrder;
            ViewBag.TotalPages = repo.TotalPages;
            var list = await repo.GetAsync();
            var viewList = list.Select(ToViewModel);
            var tasks = list.Select(ToViewAsync);
            return View(viewList);
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null)
                return NotFound();
            var model = await repo.GetAsync(id);
            loadLazy = true;
            return model == null ? NotFound() : View(ToViewModel(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TViewModel v)
        => !ModelState.IsValid
            ? View(v)
            : await repo.AddAsync(ToModel(v))
            ? RedirectToAction(nameof(Index))
            : View(v);

        public async Task<IActionResult> Create() {
            await LoadRelatedItems(null);
            return View();
        }

        public async Task<IActionResult> Edit(int? id) {
            var m = await repo.GetAsync(id);
            loadLazy = true;
            await LoadRelatedItems(m);
            return m == null ? NotFound() : View(await ToViewAsync(m));
        }

        [HttpPost, ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(TViewModel v) =>
        !ModelState.IsValid
            ? View(v)
            : await repo.UpdateAsync(ToModel(v))
            ? RedirectToAction(nameof(Index))
            : View(v);

        public async Task<IActionResult> Delete(int? id) {
            var m = await repo.GetAsync(id);
            loadLazy = true;
            return m == null ? NotFound() : View(await ToViewAsync(m));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) =>
            await repo.DeleteAsync(id)
            ? RedirectToAction(nameof(Index))
            : RedirectToAction(nameof(Delete), id);
        public async Task<IActionResult> SelectItems(string searchString, int id) {
            return Ok(await repo.SelectItems(searchString, id));
        }
        public async Task<IActionResult> SelectItem(int id) {
            return Ok(await repo.SelectItem(id));
        }
    }
}
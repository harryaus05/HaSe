using HaSe.Domain.Common;
using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Soft.Controllers {
    public abstract class BaseController<TModel, ToViewModel>(IRepo<TModel> r) : Controller
    where TModel : class where ToViewModel : EntityViewModel, new() {
        protected readonly IRepo<TModel> repo = r;
        protected bool loadlazy;
        protected async virtual Task loadRelatedItems(TModel? m) => await Task.CompletedTask;
        protected abstract TModel ToModel(ToViewModel v);
        protected virtual async Task<ToViewModel> ToViewAsync(TModel m) {
            await Task.CompletedTask;
            return Copy.Members<TModel, ToViewModel>(m);
        }
        protected virtual string selectItemTextField => nameof(EntityViewModel.Id);
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber) {
            loadlazy = false;
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
            var tasks = list.Select(ToViewAsync);
            var viewList = await Task.WhenAll(tasks);
            return View(viewList);
        }
        public async Task<IActionResult> Details(int? id) {
            var m = await repo.GetAsync(id);
            loadlazy = true;
            return m == null ? NotFound() : View(await ToViewAsync(m));
        }
        public async Task<IActionResult> Create() {
            await loadRelatedItems(null);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToViewModel v)
            => !ModelState.IsValid
                ? View(v)
                : await repo.AddAsync(ToModel(v))
                ? RedirectToAction(nameof(Index))
                : View(v);
        public async Task<IActionResult> Edit(int? id) {
            var m = await repo.GetAsync(id);
            loadlazy = true;
            await loadRelatedItems(m);
            return m == null ? NotFound() : View(await ToViewAsync(m));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToViewModel v) =>
            !ModelState.IsValid
                ? View(v)
                : await repo.UpdateAsync(ToModel(v))
                ? RedirectToAction(nameof(Index))
                : View(v);
        public async Task<IActionResult> Delete(int? id) {
            var m = await repo.GetAsync(id);
            loadlazy = true;
            return m == null ? NotFound() : View(await ToViewAsync(m));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
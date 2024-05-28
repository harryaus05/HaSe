using HaSe.Domain.Common;
using HaSe.Facade;
using HaSe.Facade.Project;
using HaSe.Helpers.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Soft.Controllers {
    public abstract class BaseController<TModel, TView>(IRepo<TModel> r) : Controller
    where TModel : class where TView : EntityViewModel, new() {
        protected readonly IRepo<TModel> repo = r;
        protected bool loadlazy;
        protected async virtual Task loadRelatedItems(TModel? m) => await Task.CompletedTask;
        protected abstract TModel toModel(TView v);
        protected virtual async Task<TView> toViewAsync(TModel m) {
            await Task.CompletedTask;
            return Copy.Members<TModel, TView>(m);
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
            var tasks = list.Select(toViewAsync);
            var viewList = await Task.WhenAll(tasks);
            return View(viewList);
        }
        public async Task<IActionResult> Details(int? id, string? masterController, int? masterId) {
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            var m = await repo.GetAsync(id);
            loadlazy = true;
            return m == null ? NotFound() : View(await toViewAsync(m));
        }
        public async Task<IActionResult> Create(string? masterController, int? masterId) {
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            await loadRelatedItems(null);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TView v, string? masterController, int? masterId) {
            if (!ModelState.IsValid) return View(v);
            if (await repo.AddAsync(toModel(v))) {
                if (masterController is null) return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", masterController, new { id = masterId });
            }
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            ModelState.AddModelError(string.Empty, repo.ErrorMessage);
            return View(v);
        }
        public async Task<IActionResult> Edit(int? id, string? masterController, int? masterId) {
            ViewBag.IsEditView = true;
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            var m = await repo.GetAsync(id);
            loadlazy = true;
            await loadRelatedItems(m);
            return m == null ? NotFound() : View(await toViewAsync(m));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TView v, string? masterController, int? masterId) {
            if (!ModelState.IsValid) return View(v);
            if (await repo.UpdateAsync(toModel(v))) {
                if (masterController is null) return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", masterController, new { id = masterId });
            }
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            ModelState.AddModelError(string.Empty, repo.ErrorMessage);
            return View(v);
        }
        public async Task<IActionResult> Delete(int? id, string? masterController, int? masterId) {
            ViewBag.MasterController = masterController;
            ViewBag.MasterId = masterId;
            var m = await repo.GetAsync(id);
            loadlazy = true;
            return m == null ? NotFound() : View(await toViewAsync(m));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? masterController, int? masterId) {
            if (await repo.DeleteAsync(id)) {
                if (masterController is null) return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", masterController, new { id = masterId });
            }
            return RedirectToAction(nameof(Delete), new { id, masterController, masterId });
        }

        public async Task<IActionResult> SelectItems(string searchString, int id) {
            return Ok(await repo.SelectItems(searchString, id));
        }
        public async Task<IActionResult> SelectItem(int id) {
            return Ok(await repo.SelectItem(id));
        }
    }
}
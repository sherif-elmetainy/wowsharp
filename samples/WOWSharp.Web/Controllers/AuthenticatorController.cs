using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.Internal;
using WOWSharp.BattleNet.Authenticator;
using WOWSharp.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WOWSharp.Web.Controllers
{
    /// <summary>
    /// Authenticator test controllers
    /// While it is typically not ideal to have authenticator functionality in a web page
    /// This controller and related views are created only to test and demonstrate the functionality of the authenticators library.
    /// </summary>
    public class AuthenticatorController : Controller
    {
        private readonly IAuthenticatorDataRepository _repository;
        private readonly IAuthenticator _authenticator;
        private readonly IEnrollmentClient _enrolClient;

        public AuthenticatorController([NotNull] IAuthenticatorDataRepository repository, [NotNull] IAuthenticator authenticator, [NotNull] IEnrollmentClient enrollClient)
        {
            _repository = repository;
            _authenticator = authenticator;
            _enrolClient = enrollClient;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAuthenticatorsAsync();
            return View(data);
        }

        public IActionResult Restore()
        {
            return View();
        }

        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Restore(RestoreAuthenticatorModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _repository.CheckAccountNameExistsAsync(model.AccountName))
                {
                    ModelState.AddModelError(nameof(model.AccountName), "An account with that name already exists.");
                }
                else
                {
                    await _repository.AddAuthenticatorAsync(new AuthenticatorData()
                    {
                        Serial = model.Serial,
                        AccountName = model.AccountName,
                        RestoreCode = model.RestoreCode
                    });
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData.Add(nameof(CreateAuthenticatorModel.Region), AuthenticatorDefaults.Regions.Select(r => new SelectListItem() { Text = r, Value = r }).ToList());
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthenticatorModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _repository.CheckAccountNameExistsAsync(model.AccountName))
                {
                    ModelState.AddModelError(nameof(model.AccountName), "An account with that name already exists.");
                }
                else
                {
                    await _repository.AddAuthenticatorAsync(new AuthenticatorData()
                    {
                        RegionCode = model.Region,
                        AccountName = model.AccountName
                    });
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData.Add(nameof(CreateAuthenticatorModel.Region), AuthenticatorDefaults.Regions.Select(r => new SelectListItem() { Text = r, Value = r }));
            return View(model);
        }

        public Task<AuthenticatorCode> Code(string name)
        {
            return _authenticator.GetAuthenticatorCodeAsync(name);
        }

        [HttpPost]
        public async Task Sync(string name)
        {
            var result = await _repository.GetAuthenticatorByAccountNameAsync(name);
            result.ServerTimeDifference = await _enrolClient.GetServerTimeDifferenceAsync(result.RegionCode);
            await _repository.UpdateAuthenticatorAsync(result);
        }

        [HttpDelete]
        public async Task Delete(string name)
        {
            await _repository.DeleteAuthenticatorByAccountNameAsync(name);
        }
    }
}

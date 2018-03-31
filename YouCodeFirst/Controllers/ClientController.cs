using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Dal.DataBase;
using WebSite.Dal.Models;
using WebSite.Dal.Models.Account;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_CLIENT)]
    public class ClientController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        protected IClientRepository _clientRepository = null;
        protected IApplicationRepository _applicationRepository = null;
        protected IOperationRepository _operationRepository = null;

        public ClientController(
            IClientRepository clientRepository,
            IApplicationRepository applicationRepository,
            IOperationRepository operationRepository
            )
        {
            if (clientRepository == null) throw new ArgumentNullException("clientRepository");
            if (applicationRepository == null) throw new ArgumentNullException("applicationRepository");
            if (operationRepository == null) throw new ArgumentNullException("operationRepository");

            _clientRepository = clientRepository;
            _applicationRepository = applicationRepository;
            _operationRepository = operationRepository;
        }

        // GET: /Client/Applications
        public ActionResult Applications(WebSiteDBContext context)
        {
            string idClient = User.Identity.GetUserId(); //get current user id
            var applications = _clientRepository.
                getClientApplications(context, idClient);

            return View("../Application/Applications", applications);
        }

        // GET: /Client/Applications
        public ActionResult ApplicationOperations(WebSiteDBContext context, int applicationId)
        {
            string idClient = User.Identity.GetUserId(); //get current user id
            if (_applicationRepository.AutorizeToClient(context, applicationId, idClient))
            {
                var operations = _applicationRepository.
                    ApplicationOperationsDisplay(context, applicationId);

                return View("../Operation/Operations", operations);
            }
            else
            {
                return RedirectToAction("Index", "Default");
            }
        }

        // GET: /Client/Applications
        public ActionResult OperationsDocuments(WebSiteDBContext context, int operationId)
        {
            string idClient = User.Identity.GetUserId(); //get current user id
            if (_operationRepository.AutorizeToClient(context, operationId, idClient))
            {
                var operations = _operationRepository.
                    OperationDocumentsDisplay(context, operationId);

                return View("../Document/Documents", operations);
            }
            else
            {
                return RedirectToAction("Index", "Default");
            }
        }
    }
}
using RateIt.Services;
using RateIt.Services.Interfaces;
using RateItHome.Models;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateItHome.Controllers
{
    [Authorize]
    public class MiningController : BaseController
    {
        private readonly IMiningService _miningService;

        public MiningController(IMiningService miningService, IUserService userService):base(userService)
        {
            _miningService = miningService;
        }

        // GET: Mining
        public ActionResult Index(MiningViewModel model)
        {
            if (model == null) model = new MiningViewModel();
            var user = GetUser();
            model.UserId = user.Id;
            model.TopInvestigations = _miningService.GetTopInvestigations(30, user.Id);
            return View(model);
        }

        [HttpPost]
        public bool Review(MiningViewModel model)
        {
            var user = GetUser();
            var success = _miningService.AddReview(user.Id, model.SelectedId, new RateIt.Common.Models.Mining()
            {
                IsIdentityHate = model.IsIdentityHate,
                IsInsult = model.IsInsult,
                IsObscence = model.IsObscence,
                IsSevereToxic = model.IsSevereToxic,
                IsSpam = model.IsSpam,
                IsThreat = model.IsThreat,
                IsToxic = model.IsToxic
            });
            return success;
        }
    }
}
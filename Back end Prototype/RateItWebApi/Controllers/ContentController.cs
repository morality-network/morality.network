using AutoMapper;
using RateIt.Common.Models;
using RateIt.Services.Interfaces;
using RateItWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RateItWebApi.Controllers
{
    [RoutePrefix("api/content")]
    public class ContentController : BaseController
    {
        private readonly ILoggingService _loggingService;
        private readonly IUserService _userService;
        private readonly IContentService _contentService;
        private readonly ISubDirectoryService _subDirectoryService;
        private readonly IContentPersistanceService _contentPersistanceService;

        public ContentController(ILoggingService loggingService, IUserService userService, IContentService contentService,
            ISubDirectoryService subDirectoryService, IContentPersistanceService contentPersistanceService,
            IMapper mapper) : base(mapper)
        {
            _loggingService = loggingService;
            _contentService = contentService;
            _userService = userService;
            _subDirectoryService = subDirectoryService;
            _contentPersistanceService = contentPersistanceService;
        }

        [MoralityAuthenticationFilter]
        [Route("get")]
        [HttpGet]
        public PageContents GetStandardContent(PageContentModel model)
        {
            try
            {
                if (!ModelState.IsValid) return null;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                var decodedUrl = HttpUtility.UrlDecode(model.EncodedUrl);
                var subDirectory = _subDirectoryService.FindOrInsertSite(decodedUrl);
                var content = _contentService.GetContentBySubDirectory(subDirectory.Id, model.Page, 20);
                var structuredContent = _mapper.Map<IList<PageContent>>(content);
                return new PageContents()
                {
                    Contents = structuredContent,
                    Page = model.Page,
                    SiteId = subDirectory.SiteId,
                    SubDirectoryId = subDirectory.Id
                };
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("publish/apply")]
        [HttpPost]
        public bool ApplyToPersistContent([FromBody]ContentPersistenceModel model)
        {
            try
            {
                if (!ModelState.IsValid) return false;
                var user = _userService.GetUserByEmail(User.Identity.Name);
                return _contentPersistanceService.ApplyForContentPersistance(model.ContentId);
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return false;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("publish/home/get")]
        [HttpGet]
        public PageContents GetPersistedContentForHome(PageContentModel model)
        {
            try
            {
                if (!ModelState.IsValid) return null;

                var decodedUrl = HttpUtility.UrlDecode(model.EncodedUrl);
                var subDirectory = _subDirectoryService.FindOrInsertSite(decodedUrl);
                var contentRows = _contentPersistanceService.GetPersistedContentByArticleId(subDirectory.SiteId, model.Page, 20);
                return new PageContents() {
                    Contents = contentRows,
                    Page = model.Page,
                    SiteId = subDirectory.SiteId,
                    SubDirectoryId = subDirectory.Id
                };
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }

        [MoralityAuthenticationFilter]
        [Route("publish/sub/get")]
        [HttpGet]
        public PageContents GetPersistedContentForSubDirectory(PageContentModel model)
        {
            try
            {
                if (!ModelState.IsValid) return null;

                var decodedUrl = HttpUtility.UrlDecode(model.EncodedUrl);
                var subDirectory = _subDirectoryService.FindOrInsertSite(decodedUrl);
                var contentRows = _contentPersistanceService.GetPersistedContentBySubArticleId(subDirectory.Id, model.Page, 20);
                return new PageContents()
                {
                    Contents = contentRows,
                    Page = model.Page,
                    SiteId = subDirectory.SiteId,
                    SubDirectoryId = subDirectory.Id
                };
            }
            catch (Exception ex)
            {
                _loggingService.Log(ex.StackTrace);
                return null;
            }
        }
        
    }
}

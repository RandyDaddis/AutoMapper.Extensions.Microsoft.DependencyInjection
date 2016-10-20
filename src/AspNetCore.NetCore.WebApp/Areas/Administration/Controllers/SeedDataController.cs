using AspNetCore.NetCore.WebApp.Areas.Administration.ViewModels;
using AspNetCore.NetCore.WebApp.Initializers;
using Dna.NetCore.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dna.AspNet4.MVC.Areas.Administration.Controllers.Api
{
    [Area("Administration")]
    public class SeedDataController : Controller
    {
        #region Private Fields

        private readonly SeedData _seedData;

        #endregion

        #region ctor

        public SeedDataController(SeedData seedData)
        {
            _seedData = seedData;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Get(string password)
        {
            if (string.IsNullOrEmpty(password) || password != "password")
                return BadRequest("invalid password");

            SeedDataModel model = new SeedDataModel();
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage = Seed();

            if (customMessage != null && customMessage.MessageDictionary1 != null && customMessage.MessageDictionary2 != null)
            {
                model.Results = new List<SeedDataResult>();

                foreach (var message in customMessage.MessageDictionary1)
                {
                    // add failure count
                    int prefixLength = message.Key.LastIndexOf('.');
                    string entityName = message.Key.Substring(0, prefixLength);
                    string failureCountKey = entityName + ".AddFailureCount";

                    SeedDataResult result = new SeedDataResult() { Entity = entityName, AddSuccessCount = message.Value };

                    if (customMessage.MessageDictionary2.ContainsKey(failureCountKey))
                        result.AddFailureCount = customMessage.MessageDictionary2[failureCountKey];

                    model.Results.Add(result);
                }
                return Ok(model);
            }

            return Ok(new { model = model });
        }

        private CustomMessage Seed()
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage = _seedData.Execute();

            return customMessage;
        }

        #endregion

    }
}

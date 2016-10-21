using AspNetCore.NetCore.WebApp.Areas.Administration.ViewModels;
using AspNetCore.NetCore.WebApp.Initializers;
using Dna.NetCore.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dna.AspNet4.MVC.Areas.Administration.Controllers.Api
{
    [Area("administration")]
    [Route("api/[controller]")]
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

        //[HttpGet]
        //public async Task<IActionResult> Get(string password)
        //{
        //    if (string.IsNullOrEmpty(password) || password != "password")
        //        return BadRequest("invalid password");

        //        SeedDataModel model = new SeedDataModel();
        //        CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

        //        customMessage = Seed();

        //        if (customMessage != null && customMessage.MessageDictionary1 != null && customMessage.MessageDictionary2 != null)
        //        {
        //            model.Results = new List<SeedDataResult>();

        //            foreach (var message in customMessage.MessageDictionary1)
        //            {
        //                // add failure count
        //                int prefixLength = message.Key.LastIndexOf('.');
        //                string entityName = message.Key.Substring(0, prefixLength);
        //                string failureCountKey = entityName + ".AddFailureCount";

        //                SeedDataResult result = new SeedDataResult() { Entity = entityName, AddSuccessCount = message.Value };

        //                if (customMessage.MessageDictionary2.ContainsKey(failureCountKey))
        //                    result.AddFailureCount = customMessage.MessageDictionary2[failureCountKey];

        //                model.Results.Add(result);
        //            }
        //            return new ObjectResult(model); // success
        //        }

        //        return Ok(new { model = model });  // something went wrong
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get(string password)
        //{
        //    // Workaround due to synchronous nature of SeedData.cs
        //    return await Task.Run(() =>  
        //    {
        //        return Execute(password);
        //    });
        //}

        private async Task<IActionResult> Get(string password)
        {
            if (string.IsNullOrEmpty(password) || password != "password")
                return BadRequest("invalid password");

            SeedDataModel model = new SeedDataModel();
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            customMessage = await Seed();

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
                return new ObjectResult(model); // success
            }

            return Ok(new { model = model });  // something went wrong
        }

        private async Task<CustomMessage> Seed()
        {
            // Workaround due to synchronous nature of SeedData.cs
            return await Task.Run(() =>
            {
                CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                customMessage = _seedData.Execute();

                return customMessage;
            });
        }

        #endregion

    }
}

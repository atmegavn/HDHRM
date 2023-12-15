using HD.HRM.Models.Test;
using HD.Profiles.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace HD.HRM.Controllers
{
    [ApiController]
    [Route("organization")]
    public class OrganizationController: HRMController
    {
        private IOrganizationAppService _organizationAppService;
        public OrganizationController(IOrganizationAppService organizationAppService) {
            _organizationAppService = organizationAppService;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> TestAsync() {

            var test = new TestModel();
            test.Name = "Thanh";
            test.BirthDate = DateTime.Now;
            return new JsonResult(test);
        }

        [HttpGet]
        [Route("getChildNode")]
        public async Task<IActionResult> GetChildNodeAsync(Guid? id)
        {
            var childrents = await _organizationAppService.GetListSubOrganizationAsync(id);
            List<Node> nodeList = new List<Node>();
            foreach (var child in childrents)
            {
                Node node = ConvertToNode(child);
                nodeList.Add(node);
            }
            return new JsonResult(nodeList);
        }

        static Node ConvertToNode(OrganizationDto org)
        {
            return new Node
            {
                Id = org.Id.ToString(),
                Text = org.Name,
                Children = org.Childrent != null && org.Childrent.Count > 0
            };
        }
    }

    class Node
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Children { get; set; }
    }
}

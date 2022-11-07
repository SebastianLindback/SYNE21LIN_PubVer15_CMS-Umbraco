using Microsoft.AspNetCore.Mvc;
using NPoco;
using Umbraco.Cms.Infrastructure.Scoping;

namespace CMS.Components
{
    public class ContactViewComponent : ViewComponent
    {

        private readonly IScopeProvider _scopeProvider;

        public ContactViewComponent(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }


        public IViewComponentResult Invoke()
        {
            var scope = _scopeProvider.CreateScope();
            var query = new Sql().Select("*").From("Contacts");
            var result = scope.Database.Fetch<CMS.AddCommentsTable.Contactschema>(query);

            var modelList = new List<ContactDTO>();
            foreach (var data in result)
            {
                var model = new ContactDTO()
                {
                    Name = data.Name,
                    Email = data.Email,
                    Message = data.Message,
                };
                modelList.Add(model);
            }

            scope.Complete();
            return View(modelList);
        }
    }
}


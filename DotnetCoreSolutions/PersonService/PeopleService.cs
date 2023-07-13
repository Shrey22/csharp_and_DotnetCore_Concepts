using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonServiceContract;

namespace PersonService 
{
    public class PeopleService : IPersonService
    {
        private List<string> _people;
        private Guid  _serviceInstaceId;

        public PeopleService()
        {
            _serviceInstaceId = Guid.NewGuid();
            _people = new List<string>()
            {
                "Shrey",
                "Shrishti",
                "Anonymus"
            };
        }

        public Guid serviceInstaceId
        {
            get
            {
                return _serviceInstaceId;
            }
        }

        public List<string> GetListOfPeople()
        {
            return _people;
        }

    }
}

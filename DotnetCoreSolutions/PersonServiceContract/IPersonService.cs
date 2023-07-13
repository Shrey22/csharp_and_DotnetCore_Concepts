using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonServiceContract
{
    public interface IPersonService
    {
        Guid serviceInstaceId { get; }
        List<string> GetListOfPeople();
    }
}

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public interface IComplaintRequestRepository
    {
        bool SaveComplaintRequest(ComplaintRequest complaint);
        List<ComplaintRequest> ComplaintRequestList(int? createdById);
    }
}

using Contracts.Interfaces.Domain;
using Contracts.Interfaces.Domain.OrderTest;
using Contracts.Interfaces.Domain.PurchaseOrders;
using Contracts.Interfaces.Utility;
using Entities.Models.OrderTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repository
{
    public interface IRepositoryManager
    {

        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IProfilePictureRepository ProfilePicture { get; }

        #region OrderTest
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IProductRepository Product { get; }

        #endregion

        #region Purchase Order
        IPurchaseOrderRepository PurchaseOrder { get; }
        IPurchaseOrderDetailRepository PurchaseOrderDetail { get; }
        #endregion

        #region Utility
        IDropdownRepository Dropdown { get; }
        IAutoCompleteRepository AutoComplete { get; }
        #endregion
        Task SaveAsync();
    }
}

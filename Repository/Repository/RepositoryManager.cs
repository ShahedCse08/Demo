using Contracts.Interfaces.Domain;
using Contracts.Interfaces.Domain.OrderTest;
using Contracts.Interfaces.Domain.PurchaseOrder;
using Contracts.Interfaces.Repository;
using Contracts.Interfaces.Utility;
using Entities.Context;
using Repository.Domain;
using Repository.Domain.OrderTest;
using Repository.Domain.PurchaseOrders;
using Repository.Utility;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IProfilePictureRepository _profilePictureRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IDropdownRepository _dropdownRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;


        // private IEmailSender _emailSender;
        // private readonly EmailConfiguration _emailConfig;
        public RepositoryManager(RepositoryContext repositoryContext) {
            _repositoryContext  = repositoryContext;
         
        }


        #region Email

        //public IEmailSender EmailSender
        //{
        //    get
        //    {
        //        if (_emailSender == null)
        //            _emailSender = new EmailSender(_emailConfig,_repositoryContext);
        //        return _emailSender;
        //    }
        //}



        #endregion

        #region Demo

        #endregion

        #region OrderTest

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_repositoryContext);
                return _customerRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_repositoryContext);
                return _orderRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }

        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if (_orderDetailRepository == null)
                    _orderDetailRepository = new OrderDetailRepository(_repositoryContext);
                return _orderDetailRepository;
            }
        }

        #endregion


        #region PurchaseOrder

        public IPurchaseOrderRepository PurchaseOrder
        {
            get
            {
                if (_purchaseOrderRepository == null)
                    _purchaseOrderRepository = new PurchaseOrderRepository(_repositoryContext);
                return _purchaseOrderRepository;
            }
        }

        public IPurchaseOrderDetailRepository PurchaseOrderDetail
        {
            get
            {
                if (_purchaseOrderDetailRepository == null)
                    _purchaseOrderDetailRepository = new PurchaseOrderDetailRepository(_repositoryContext);
                return _purchaseOrderDetailRepository;
            }
        }

        #endregion

        #region Utility
        public IDropdownRepository Dropdown
        {
            get
            {
                if (_dropdownRepository == null)
                    _dropdownRepository = new DropdownRepository(_repositoryContext);
                return _dropdownRepository;
            }
        }
        #endregion


        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);

                return _employeeRepository;
            }
        }

    
        public IProfilePictureRepository ProfilePicture
        {
            get
            {
                if (_profilePictureRepository == null)
                    _profilePictureRepository = new ProfilePictureRepository(_repositoryContext);

                return _profilePictureRepository;
            }
        }

        

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}

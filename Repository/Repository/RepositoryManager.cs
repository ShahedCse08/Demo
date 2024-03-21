using Contracts.Interfaces.Domain;
using Contracts.Interfaces.Repository;
using Entities.Context;
using Repository.Domain;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IProfilePictureRepository _profilePictureRepository;
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

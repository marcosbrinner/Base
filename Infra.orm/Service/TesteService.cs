using Domain.Entity;
using Domain.IRepository;
using Infra.orm.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.orm.Service
{
    public class TesteService : ITesteService
    {
        private readonly IUnityOfWork _uniytOfWork;
        public TesteService(IUnityOfWork unityOfWork)
        {
            _uniytOfWork = unityOfWork;
        }

        public void createNew()
        {
            _uniytOfWork.TesteRepository.Add(new Teste {
                 TesteName ="1 - teste",
            });
            _uniytOfWork.Commit();
        }
    }
}

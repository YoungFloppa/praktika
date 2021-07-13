using Models;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ArduinoService : EntityService<Arduino>, IArduinoService
    {
        public ArduinoService(IUnitOfWork unitOfWork, IArduinoRepository repository) :base(unitOfWork, repository)
        {

        }
    }
}

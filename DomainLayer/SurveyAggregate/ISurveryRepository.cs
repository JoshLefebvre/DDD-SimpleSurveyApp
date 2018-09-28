using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate
{
    public interface ISurveryRepository
    {
        Task SaveAsync(Survey survey);
        Task<Survey> GetAsync(int id);
    }
}

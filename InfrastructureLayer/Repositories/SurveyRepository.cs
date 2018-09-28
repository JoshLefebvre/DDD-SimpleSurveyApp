using DomainLayer.Entities;
using DomainLayer.SurveyAggregate;
using InfrastructureLayer.DBContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class SurveyRepository : ISurveryRepository
    {
        private readonly SurveyContext _dbContext;

        public SurveyRepository(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(Survey survey)
        {
            _dbContext.Surveys.Add(survey);
            _dbContext.SaveChanges();
        }

        public async Task<Survey> GetAsync(int id)
        {
            //Hack: For demo purposes we only have 1 survey
            return _dbContext.Surveys.First();
        }
    }
}

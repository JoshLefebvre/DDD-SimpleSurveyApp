using DomainLayer.Entities;
using DomainLayer.SurveyAggregate;
using InfrastructureLayer.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class SurveyRepository : ISurveryRepository
    {
        private readonly SurveyContext _dbContext;

        public SurveyRepository(/*IOptions<Settings> settings*/)
        {
            _dbContext = new SurveyContext(/*settings*/);
        }

        public async Task SaveAsync(Survey survey)
        {
            try
            {
                await _dbContext.Surveys.InsertOneAsync(survey);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Survey> GetAsync(int id)
        {
            try
            {
                return _dbContext.Surveys.Find(_ => true).FirstOrDefault();
                //return await _dbContext.Surveys.Find(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}

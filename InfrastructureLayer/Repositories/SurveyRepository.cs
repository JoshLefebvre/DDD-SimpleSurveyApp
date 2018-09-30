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

        public async Task CreateAsync(Survey survey)
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

        public async Task<Survey> GetAsync(string id)
        {
            try
            {
                return _dbContext.Surveys.Find(_ => true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task UpdateAsync(Survey survey)
        {
            try
            {
                var filter = Builders<Survey>.Filter.Eq(s => s.EntityId, survey.EntityId);
                await _dbContext.Surveys.ReplaceOneAsync(filter, survey);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}

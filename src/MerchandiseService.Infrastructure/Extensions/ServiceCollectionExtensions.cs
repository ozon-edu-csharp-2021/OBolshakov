using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ReservationMerchCommandHandler).Assembly);
            services.AddScoped<IRequestMerchRepository, Repo>();
            
            return services;
        }
        
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
    
    public class Repo : IRequestMerchRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        Task<RequestMerch> IRepository<RequestMerch>.CreateAsync(RequestMerch itemToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<RequestMerch> IRequestMerchRepository.UpdateAsync(RequestMerch requestMerch, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestMerch> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<RequestMerch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        Task<RequestMerch> IRequestMerchRepository.CreateAsync(RequestMerch requestMerch, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<RequestMerch> IRepository<RequestMerch>.UpdateAsync(RequestMerch itemToUpdate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
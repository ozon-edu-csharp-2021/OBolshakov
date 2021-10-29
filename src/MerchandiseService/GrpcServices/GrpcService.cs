using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Models;
using MerchandiseService.Services;

namespace MerchandiseService.GrpcServices
{
    public class GrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchService _merchService;

        public GrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<Empty> AddMerch(
            AddMerchRequest request,
            ServerCallContext context)
        {

            await _merchService.Add(new MerchItemCreationModel
            {
                ItemName = request.ItemName,
                Quantity = request.Quantity
            }, context.CancellationToken);

            return new Empty();
        }

        public override async Task<GetAllMerchResponse> GetInfoAboutIssuanceMerch(Empty request, ServerCallContext context)
        {
            var merchItems = await _merchService.GetAll(context.CancellationToken);
            return new GetAllMerchResponse
            {
                Merchs = { merchItems.Select(x => new GetAllMerchResponseUnit
                {
                    ItemId = x.ItemId,
                    Quantity = x.Quantity,
                    ItemName = x.ItemName
                })}
            };
        }
    }
}
using AsapTask.Models;
using AsapTask.Polygon.Dto;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace AsapTask.Polygon
{
    public class PolygonService : AsapTaskAppService, IPolygonService
    {
        private readonly IRepository<PolygonData, int> _PolygonDataRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public PolygonService(IRepository<PolygonData, int> polygonDataRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _PolygonDataRepository = polygonDataRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task CreateAsync(PolygonDataDto polygonDataDto)
        {
            var polygonData = new PolygonData
            {
                Status = polygonDataDto.Status,
                From = polygonDataDto.From,
                Symbol = polygonDataDto.Symbol,
                Open = polygonDataDto.Open,
                High = polygonDataDto.High,
                Low = polygonDataDto.Low,
                Close = polygonDataDto.Close,
                Volume = polygonDataDto.Volume,
                AfterHours = polygonDataDto.AfterHours,
                PreMarket = polygonDataDto.PreMarket
            };

            try
            {
                using (var uow = _unitOfWorkManager.Begin())
                {
                    await _PolygonDataRepository.InsertAsync(polygonData);
                    await uow.CompleteAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

using TradeScope.Domain.Models;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Models.Entities;

namespace TradeScope.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static AssetItemModel ToModel(this AssetEntity entity)
        {
            return new AssetItemModel
            {
                Id = entity.Id,
                Asset = entity.Asset,
                Type = entity.Type,
                Name = entity.Name,
                Source = entity.Source,
                Endpoint = entity.Endpoint
            };
        }

        public static CryptoItemModel ToModel(this CryptoEntity entity)
        {
            return new CryptoItemModel
            {
                Id = entity.Id,
                Symbol = entity.Symbol,
                Name = entity.Name
            };
        }

        public static CryptoEntity  ToEntity(this CryptoItemModel dto)
        {
            return new CryptoEntity
            {
                //Id = dto.Id,
                Symbol = dto.Symbol,
                Name = dto.Name
            };
        }

        public static IndexItemModel ToModel(this IndexEntity entity)
        {
            return new IndexItemModel
            {
                Id = entity.Id,
                Stock = entity.Stock,
                Name = entity.Name
            };
        }

        public static IndexEntity ToEntity(this IndexItemModel dto)
        {
            return new IndexEntity
            {
                //Id = dto.Id,
                Stock = dto.Stock,
                Name = dto.Name
            };
        }

        public static CommoditieItemModel ToModel(this CommoditieEntity entity)
        {
            return new CommoditieItemModel
            {
                Id = entity.Id,
                Symbol = entity.Symbol,
                Name = entity.Name
            };
        }

        public static CommoditieEntity ToEntity(this CommoditieItemModel dto)
        {
            return new CommoditieEntity
            {
                //Id = dto.Id,
                Symbol = dto.Symbol,
                Name = dto.Name
            };
        }

        public static B3StockItemModel ToModel(this B3StockEntity entity)
        {
            return new B3StockItemModel
            {
                Id = entity.Id,
                Stock = entity.Stock,
                Name = entity.Name,
                Logo = entity.Logo,
                Sector = entity.Sector,
                Type = entity.Type
            };
        }

        public static B3StockEntity ToEntity(this B3StockItemModel dto)
        {
            return new B3StockEntity
            {
                //Id = entity.Id,
                Stock = dto.Stock,
                Name = dto.Name,
                Logo = dto.Logo,
                Sector = dto.Sector,
                Type = dto.Type
            };
        }

        public static ForexItemModel ToModel(this ForexEntity entity)
        {
            return new ForexItemModel
            {
                Id = entity.Id,
                Currency = entity.Currency,
                Pair = entity.Pair
            };
        }

        public static ForexEntity ToEntity(this ForexItemModel dto)
        {
            return new ForexEntity
            {
                //Id = entity.Id,
                Currency = dto.Currency,
                Pair = dto.Pair
            };
        }
    }
}

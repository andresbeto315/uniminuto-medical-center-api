using AutoMapper;

namespace Adapters.Mapper
{
    public class Mapper : Domain.Contracts.Adapter.IMapper.IMapper
    {
        private MapperConfigurationExpression _configExpression;

        private MapperConfigurationExpression ConfigExpression
        {
            get
            {
                return _configExpression ?? new MapperConfigurationExpression();
            }
        }

        private MapperConfiguration _config { get; set; }

        public void CreateMap<TSource, TDestination>() => ConfigExpression.CreateMap<TSource, TDestination>();

        public List<TDestination> Mappear<TSource, TDestination>(
        List<TSource> obj,
        List<TDestination> obj2)
        {
            _config = new MapperConfiguration(_configExpression);
            obj2 = _config.CreateMapper().Map<List<TSource>, List<TDestination>>(obj, obj2);
            return obj2;
        }

        public TDestination Mappear<TSource, TDestination>(TSource obj, TDestination obj2)
        {
            _configExpression = new MapperConfigurationExpression();
            _config = new MapperConfiguration(_configExpression);
            obj2 = _config.CreateMapper().Map<TSource, TDestination>(obj, obj2);
            return obj2;
        }

        public TDestination Map<TDestination, TSource>(TSource source) where TDestination : new()
        {
            _configExpression = new MapperConfigurationExpression();
            _config = new MapperConfiguration(_configExpression);
            AutoMapper.IMapper mapper = _config.CreateMapper();
            new TDestination();
            return mapper.Map<TSource, TDestination>(source);
        }

        public List<TDestination> Map<TSource, TDestination>(
        List<TSource> obj,
        List<TDestination> obj2)
        {
            obj2 = new MapperConfiguration((Action<IMapperConfigurationExpression>)(cfg => cfg.CreateMap<TSource, TDestination>())).CreateMapper().Map<List<TSource>, List<TDestination>>(obj, obj2);
            return obj2;
        }

        public TDestination Map<TSource, TDestination>(TSource obj, TDestination obj2) => new MapperConfiguration((Action<IMapperConfigurationExpression>)(cfg => cfg.CreateMap<TSource, TDestination>())).CreateMapper().Map<TSource, TDestination>(obj, obj2);
    }
}
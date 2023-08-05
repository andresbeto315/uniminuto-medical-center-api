namespace Domain.Contracts.Adapter.IMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source) where TDestination : new();

        TDestination Map<TSource, TDestination>(TSource obj, TDestination obj2);

        List<TDestination> Map<TSource, TDestination>(List<TSource> obj, List<TDestination> obj2);

        void CreateMap<TSource, TDestination>();

        List<TDestination> Mappear<TSource, TDestination>(
        List<TSource> obj,
        List<TDestination> obj2);

        TDestination Mappear<TSource, TDestination>(TSource obj, TDestination obj2);
    }
}
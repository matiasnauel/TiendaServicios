using AutoMapper;

namespace TiendaServicio.api.Autor.helper
{

    public interface IMapperCustom
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
    public class MapperCustom : IMapperCustom
    {
        private readonly IMapper _mapper;

        public MapperCustom(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}

using AutoMapper;
using BookStore.Aggregates.Book;
using BookStore.Aggregates.Store;
using BookStore.Dtos;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookOutputDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value));

        CreateMap<Store, StoreOutputDto>();
    }
}

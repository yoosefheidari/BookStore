using AutoMapper;
using BookStore.Aggregates.Book;
using BookStore.Aggregates.Comment;
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
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Store, StoreOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Comment, CommentOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

    }
}

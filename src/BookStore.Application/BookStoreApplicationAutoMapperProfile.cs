using AutoMapper;
using BookStore.Aggregates.Book;
using BookStore.Aggregates.Comment;
using BookStore.Aggregates.Store;
using BookStore.Dtos;
using System;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookOutputDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Store, StoreOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Comment, CommentOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<AddBookInputDto, Book>()
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price(decimal.Parse(src.Price))))
            .ForMember(dest => dest.TenantId, opt => opt.MapFrom(src => new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761")));

        CreateMap<AddCommentInputDto, Comment>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new Rating(src.Rating)))
            .ForMember(dest => dest.TenantId, opt => opt.MapFrom(src => new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761")));

        CreateMap<Comment, CommentOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<SaveCoverInputDto, BookCover>()
           .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => new BookId(src.BookId)));
    }
}

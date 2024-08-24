using AutoMapper;
using BookStore.Aggregates.Book;
using BookStore.Aggregates.Comment;
using BookStore.Aggregates.Store;
using BookStore.Dtos;
using System;
using Volo.Abp.TenantManagement;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookOutputDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value.ToString()))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Store, StoreOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<Comment, CommentOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<AddBookInputDto, Book>()
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price(decimal.Parse(src.Price))));

        CreateMap<AddCommentInputDto, Comment>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new Rating(src.Rating)));

        CreateMap<Comment, CommentOutputDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Id));

        CreateMap<SaveCoverInputDto, BookCover>()
           .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => new BookId(src.BookId)));

        CreateMap<AddStoreInputDto, Store>();
        CreateMap<int, CommentId>()
            .ConstructUsing(x => new CommentId(x));

        CreateMap<Tenant, TenantDto>();
    }
}

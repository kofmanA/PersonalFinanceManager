using AutoMapper;
using backend.Models;
using backend.DTOs.CategoryDtos;
using backend.DTOs.TransactionDtos;
using backend.DTOs.BudgetDtos;
using backend.DTOs.RecurringTransactionDtos;
using backend.DTOs.UserDtos;
namespace backend.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categories
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();

        // Transactions
        CreateMap<Transaction, TransactionDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        CreateMap<CreateTransactionDto, Transaction>();

        // Budgets
        CreateMap<Budget, BudgetDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        CreateMap<CreateBudgetDto, Budget>();

        // Recurring Transactions
        CreateMap<RecurringTransaction, RecurringTransactionDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        CreateMap<CreateRecurringTransactionDto, RecurringTransaction>();

        // Users
        CreateMap<User, UserDto>();
    }
}

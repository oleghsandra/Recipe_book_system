using RecipeBookSystem.DAL.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookSystem.DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();

        IDishRepository DishRepository { get; }

        IProductRepository ProductRepository { get; }

        IIngredientRepository IngredientRepository { get; }

        IUserRepository UserRepository { get; }

        IProductTypeRepository ProductTypeRepository { get; }
    }
}

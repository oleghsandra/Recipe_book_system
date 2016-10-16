using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.Repositories;
using System;

namespace RecipeBookSystem.DAL.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connection;

        private IUserRepository _userRepository;
        private IProductRepository _productRepository;
        private IIngredientRepository _ingredientRepository;
        private IDishRepository _dishRepository;
        private IProductTypeRepository _productTypeRepository;

        public UnitOfWork(string connection)
        {
            _connection = connection;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public IDishRepository DishRepository
        {
            get
            {
                return _dishRepository ?? (_dishRepository = new DishRepository(_connection));
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new ProductRepository(_connection));
            }
        }

        public IIngredientRepository IngredientRepository
        {
            get
            {
                return _ingredientRepository ?? (_ingredientRepository = new IngredientRepository(_connection));
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_connection));
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                return _productTypeRepository ?? (_productTypeRepository = new ProductTypeRepository(_connection));
            }
        }
    }
}

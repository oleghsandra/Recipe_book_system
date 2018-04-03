using Microsoft.Extensions.DependencyInjection;
using RecipeBookSystem.BL.ModelProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookSystem.API
{
    public static class RecipeSystemServicesProviderExtensions
    {
        public static void AddRecipeSystemServices(this IServiceCollection services)
        {
            services.AddTransient<DishProvider>();
            services.AddTransient<IngredientProvider>();
            services.AddTransient<ProductProvider>();
            services.AddTransient<ProductTypeProvider>();
            services.AddTransient<UserProvider>();
        }
    }
}

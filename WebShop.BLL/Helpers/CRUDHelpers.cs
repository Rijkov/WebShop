namespace WebShop.BLL.Helpers
{
    using DTO;
    using Interfaces;
    using WebShop.DAL.Interfaces;
    using WebShop.DAL.Entites;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    /// <summary>
    /// Auxiliary method to C.R.U.D operations:
    /// </summary>
    internal class CRUDHelpers
    {
        #region Create / Async:
        public static void Create(IModel model, IUnitOfWork db)
        {
            var objName = model.GetType().Name;
            switch (objName)
            {
                case nameof(ProductDTO):
                    var ProdDto = model as ProductDTO;
                    var entity = new Product
                    {
                        CategoryId = ProdDto.CategoryId,
                        Code = ProdDto.Code,
                        Description = ProdDto.Description,
                        Price = ProdDto.Price,
                        IsStock = ProdDto.IsStock,
                        Name = ProdDto.Name,
                        Photo = ProdDto.Photo
                    };
                    db.Products.Create(entity);
                    break;
                case nameof(CategoryDTO):
                    var CategoryDto = model as CategoryDTO;
                    var categ = new Category
                    {
                        Id = CategoryDto.Id,
                        Name = CategoryDto.Name,
                        TagName = CategoryDto.TagName,
                        Photo = CategoryDto.Photo
                    };
                    db.Categories.Create(categ);
                    break;
                case nameof(CartDTO):
                    var CartDto = model as CartDTO;
                    var cart = new ShopCart
                    {
                        Id = CartDto.Id,
                        DateOrder = CartDto.DateOrder,
                        UserId = CartDto.UserId,
                        ProductId = CartDto.ProductId,
                        Quantity = CartDto.Quantity,
                        ItemPrice = CartDto.ItemPrice,
                        TotalPrice = CartDto.TotalPrice
                    };
                    db.ShopCarts.Create(cart);
                    break;
            }
        }

        public static async Task CreateAsync(IModel model, IUnitOfWork db)
        {
            var objName = model.GetType().Name;
            switch (objName)
            {
                case nameof(ProductDTO):
                    var ProdDto = model as ProductDTO;
                    var entity = new Product
                    {
                        CategoryId = ProdDto.CategoryId,
                        Code = ProdDto.Code,
                        Description = ProdDto.Description,
                        Price = ProdDto.Price,
                        IsStock = ProdDto.IsStock,
                        Name = ProdDto.Name,
                        Photo = ProdDto.Photo
                    };
                    await db.Products.CreateAsync(entity);
                    break;
                case nameof(CategoryDTO):
                    var CategoryDto = model as CategoryDTO;
                    var categ = new Category
                    {
                        Id = CategoryDto.Id,
                        Name = CategoryDto.Name,
                        TagName = CategoryDto.TagName,
                        Photo = CategoryDto.Photo
                    };
                    await db.Categories.CreateAsync(categ);
                    break;
                case nameof(CartDTO):
                    var CartDto = model as CartDTO;
                    var cart = new ShopCart
                    {
                        Id = CartDto.Id,
                        DateOrder = CartDto.DateOrder,
                        UserId = CartDto.UserId,
                        ProductId = CartDto.ProductId,
                        Quantity = CartDto.Quantity,
                        ItemPrice = CartDto.ItemPrice,
                        TotalPrice = CartDto.TotalPrice
                    };
                    await db.ShopCarts.CreateAsync(cart);
                    break;
            }
        }
        #endregion

        #region Read / Async:

        public static IEnumerable<IModel> Read(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(ProductDTO):
                    var list = db.Products.Read().ToList();
                    var listDto = new List<ProductDTO>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        listDto.Add(new ProductDTO());
                        listDto[i].Description = list[i].Description;
                        listDto[i].CategoryId = list[i].CategoryId;
                        listDto[i].Code = list[i].Code;
                        listDto[i].Name = list[i].Name;
                        listDto[i].Price = list[i].Price;
                        listDto[i].Photo = list[i].Photo;
                        listDto[i].IsStock = list[i].IsStock;
                    }
                    return listDto;
                case nameof(CategoryDTO):
                    var listcat =  db.Categories.Read().ToList();
                    var listDtocat = new List<CategoryDTO>();
                    for (int i = 0; i < listcat.Count; i++)
                    {
                        listDtocat.Add(new CategoryDTO());
                        listDtocat[i].TagName = listcat[i].TagName;
                        listDtocat[i].Photo = listcat[i].Photo;
                        listDtocat[i].Id = listcat[i].Id;
                        listDtocat[i].Name = listcat[i].Name;
                    }
                    return listDtocat;
                case nameof(CartDTO):
                    var listcart = db.Products.Read().ToList();
                    var listDtocart = new List<CartDTO>();
                    for (int i = 0; i < listcart.Count; i++)
                    {
                        listDtocart.Add(new CartDTO());
                        listDtocart[i].Id = listDtocart[i].Id;
                        listDtocart[i].UserId = listDtocart[i].UserId;
                        listDtocart[i].ProductId = listDtocart[i].ProductId;
                        listDtocart[i].Quantity = listDtocart[i].Quantity;
                        listDtocart[i].DateOrder = listDtocart[i].DateOrder;
                        listDtocart[i].TotalPrice = listDtocart[i].TotalPrice;
                        listDtocart[i].ItemPrice = listDtocart[i].ItemPrice;
                    }
                    return listDtocart;
                default: return default;
            }
        }

        public static async Task<IEnumerable<IModel>> ReadAsync(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(ProductDTO):
                    var list = await db.Products.ReadAsync();
                    var listDto = new List<ProductDTO>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        listDto.Add(new ProductDTO());
                        listDto[i].Description = list[i].Description;
                        listDto[i].CategoryId = list[i].CategoryId;
                        listDto[i].Code = list[i].Code;
                        listDto[i].Name = list[i].Name;
                        listDto[i].Price = list[i].Price;
                        listDto[i].Photo = list[i].Photo;
                        listDto[i].IsStock = list[i].IsStock;
                    }
                    return listDto;
                case nameof(CategoryDTO):
                    var listcat = await db.Categories.ReadAsync();
                    var listDtocat = new List<CategoryDTO>();
                    for (int i = 0; i < listcat.Count; i++)
                    {
                        listDtocat.Add(new CategoryDTO());
                        listDtocat[i].TagName = listcat[i].TagName;
                        listDtocat[i].Photo = listcat[i].Photo;
                        listDtocat[i].Id = listcat[i].Id;
                        listDtocat[i].Name = listcat[i].Name;
                    }
                    return listDtocat;
                case nameof(CartDTO):
                    var listcart = await db.Products.ReadAsync();
                    var listDtocart = new List<CartDTO>();
                    for (int i = 0; i < listcart.Count; i++)
                    {
                        listDtocart.Add(new CartDTO());
                        listDtocart[i].Id = listDtocart[i].Id;
                        listDtocart[i].UserId = listDtocart[i].UserId;
                        listDtocart[i].ProductId = listDtocart[i].ProductId;
                        listDtocart[i].Quantity = listDtocart[i].Quantity;
                        listDtocart[i].DateOrder = listDtocart[i].DateOrder;
                        listDtocart[i].TotalPrice = listDtocart[i].TotalPrice;
                        listDtocart[i].ItemPrice = listDtocart[i].ItemPrice;
                    }
                    return listDtocart;
                default:return default;
            }
        }
        #endregion

        #region Update / Async:
        public static string Update(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(CartDTO):
                    var dto = model as CartDTO;
                    var entitycart = new ShopCart
                    {
                        DateOrder = dto.DateOrder,
                        Id = dto.Id,
                        ItemPrice = dto.ItemPrice,
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity,
                        TotalPrice = dto.TotalPrice,
                        UserId = dto.UserId,
                    };
                    db.ShopCarts.Update(entitycart);
                    return $"{nameof(CartDTO)} updated successful!!!";
                case nameof(ProductDTO):
                    var pdto = model as ProductDTO;
                    var entityprod = new Product
                    {
                        Name = pdto.Name,
                        Id = pdto.Id,
                        Price = pdto.Price,
                        CategoryId = pdto.CategoryId,
                        Description = pdto.Description,
                        Code = pdto.Code,
                        Photo = pdto.Photo,
                        IsStock = pdto.IsStock
                    };
                    db.Products.Update(entityprod);
                    return $"{nameof(CartDTO)} updated successful!!!";                    
                case nameof(CategoryDTO):
                    var cdto = model as CategoryDTO;
                    var entitycat = new Category
                    {
                        Name = cdto.Name,
                        Id = cdto.Id,
                        Photo = cdto.Photo,
                        TagName = cdto.TagName
                    };
                    db.Categories.Update(entitycat);
                    return $"{nameof(CartDTO)} updated successful!!!";
                default: return null;
            }
        }

        public static async Task<string> UpdateAsync(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(CartDTO):
                    await db.ShopCarts.UpdateAsync((model as CartDTO).Id);
                    return $"{nameof(CartDTO)} {nameof(UpdateAsync)} successful!";
                case nameof(ProductDTO):
                    await db.Products.UpdateAsync((model as ProductDTO).Id);
                    return $"{nameof(ProductDTO)} {nameof(UpdateAsync)} successful!";
                case nameof(CategoryDTO):
                    await db.Categories.UpdateAsync((model as CategoryDTO).Id);
                    return $"{nameof(CategoryDTO)} {nameof(UpdateAsync)} successful!";
                default: return null;
            }
        }
        #endregion

        #region Delete / Async:
        public static string Delete(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(CartDTO):
                    db.ShopCarts.Delete((model as CartDTO).Id);
                    return $"{nameof(CartDTO)} deleted successful";
                case nameof(CategoryDTO):
                    db.Categories.Delete((model as CategoryDTO).Id);
                    return $"{nameof(CategoryDTO)} deleted successful";
                case nameof(ProductDTO):
                    db.Products.Delete((model as ProductDTO).Id);
                    return $"{nameof(ProductDTO)} deleted successful";
                default:return "Something went wrong!!!";
            }
        }

        public static async Task<string> DeleteAsync(IModel model, IUnitOfWork db)
        {
            switch (model.GetType().Name)
            {
                case nameof(CartDTO):
                    await db.ShopCarts.DeleteAsync((model as CartDTO).Id);
                    return $"{nameof(CartDTO)} deleted successful";
                case nameof(CategoryDTO):
                    await db.Categories.DeleteAsync((model as CategoryDTO).Id);
                    return $"{nameof(CategoryDTO)} deleted successful";
                case nameof(ProductDTO):
                    await db.Products.DeleteAsync((model as ProductDTO).Id);
                    return $"{nameof(ProductDTO)} deleted successful";
                default: return "Something went wrong!!!";
            }
        }
        #endregion
    }
}

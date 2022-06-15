namespace WebShop.BLL.DTO
{
    public class CategoryDTO:Interfaces.IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagName { get; set; }
        public string Photo { get; set; }
    }
}

namespace Budget.Models
{
    public class CategoriesModel
    {
        public int Id { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int ParentCategoryId { get; set; } 
    }
}

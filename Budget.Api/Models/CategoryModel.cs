namespace BudgetApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; } 
    }
}

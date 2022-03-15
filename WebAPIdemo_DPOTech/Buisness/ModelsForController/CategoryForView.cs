namespace WebAPIdemo_DPOTech.Buisness.ModelsForController;

public class CategoryForView
{
    private Guid categoryId;

    private string categoryName;

    private string categoryDescription;

    public CategoryForView()
    {
        
    }

    public CategoryForView(Guid categoryId, string categoryName, string categoryDescription)
    {
        this.categoryId = categoryId;
        this.categoryName = categoryName;
        this.categoryDescription = categoryDescription;
    }

    public Guid CategoryId
    {
        get => categoryId;
        set => categoryId = value;
    }

    public string CategoryName
    {
        get => categoryName;
        set => categoryName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string CategoryDescription
    {
        get => categoryDescription;
        set => categoryDescription = value ?? throw new ArgumentNullException(nameof(value));
    }
}
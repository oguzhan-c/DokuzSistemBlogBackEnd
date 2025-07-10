using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Image : Entity<int>
{
    public string FileName { get; set; }       
    public string FilePath { get; set; }       
    public string ContentType { get; set; }    
    public ImageType ImageType { get; set; }   
    public int DisplayOrder { get; set; } = 0;     
    
    public int UserId { get; set; }            
    public int PostId { get; set; }          
    public int CategoryId { get; set; }      
    
    public virtual User User { get; set; }
    public virtual Post? Post { get; set; }
    public virtual Category? Category { get; set; }

    public Image() 
    {
    }

    public Image(string fileName, string filePath, string contentType, 
        int userId, ImageType imageType, int displayOrder = 0)
    {
        FileName = fileName;
        FilePath = filePath;
        ContentType = contentType;
        UserId = userId;
        ImageType = imageType;
        DisplayOrder = displayOrder;
    }
}
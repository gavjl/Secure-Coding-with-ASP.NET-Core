
public class BufferedSingleFileUploadDbModel
{
    [BindProperty]
    public BufferedSingleFileUploadDb FileUpload { get; set; }

}

public class BufferedSingleFileUploadDb
{
    [Required]
    [Display(Name="File")]
    public IFormFile FormFile { get; set; }
}
namespace WidgetAndCo.Extensions;

public static class FormFileExtensions
{
    public static async Task<byte[]> GetBytes(this IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
    
    //Source: https://stackoverflow.com/questions/11063900/determine-if-uploaded-file-is-image-any-format-on-mvc
    public const int ImageMinimumBytes = 512;
    public static bool IsImage(this IFormFile postedFile)
    {
        //-------------------------------------------
        //  Check the image mime types
        //-------------------------------------------
        if (postedFile.ContentType.ToLower() != "image/jpg" &&
                    postedFile.ContentType.ToLower() != "image/jpeg" &&
                    postedFile.ContentType.ToLower() != "image/pjpeg" &&
                    postedFile.ContentType.ToLower() != "image/gif" &&
                    postedFile.ContentType.ToLower() != "image/x-png" &&
                    postedFile.ContentType.ToLower() != "image/png")
        {
            return false;
        }

        //-------------------------------------------
        //  Check the image extension
        //-------------------------------------------
        if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
            && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
            && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
            && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
        {
            return false;
        }

        //-------------------------------------------
        //  Attempt to read the file and check the first bytes
        //-------------------------------------------
        try
        {
            if (!postedFile.OpenReadStream().CanRead)
            {
                return false;
            }
            //------------------------------------------
            //check whether the image size exceeding the limit or not
            //------------------------------------------ 
            if (postedFile.Length < ImageMinimumBytes)
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
        
        return true;
    }
}
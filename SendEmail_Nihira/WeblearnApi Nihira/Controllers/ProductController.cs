using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WeblearnApi_Nihira.Helper;
using WeblearnApi_Nihira.Repos;

namespace WeblearnApi_Nihira.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class ProductController : ControllerBase
 {
  private readonly IWebHostEnvironment _environment;
  private readonly LearndataContext _context;

  public ProductController(IWebHostEnvironment environment, LearndataContext context)
  {
   _environment = environment;
   _context = context;
  }
  [HttpPut("UploadImage")]
  public async Task<IActionResult> UploadImage(IFormFile formFile, string productCode)
  {
   APIResponse response = new APIResponse();
   try
   {
    string filePath = GetFilepath(productCode);

    if (!System.IO.Directory.Exists(filePath))
    {
     System.IO.Directory.CreateDirectory(filePath);
    }

    string imagePath = filePath + "\\" + productCode + ".png";

    if (System.IO.File.Exists(imagePath))
    {
     System.IO.File.Delete(imagePath);
    }

    using (FileStream stream = System.IO.File.Create(imagePath))
    {
     await formFile.CopyToAsync(stream);
     response.ResponseCode = 200;
     response.Result = "pass";
    }

   }
   catch (Exception ex)
   {
    response.ErrorMessage = ex.Message;
   }

   return Ok(response);
  }


  [HttpPut("MultiUploadImage")]
  public async Task<IActionResult> MultiUploadImage(IFormFileCollection fileCollection, string productCode)
  {
   APIResponse response = new APIResponse();
   int passcount = 0;
   int errorcount = 0;
   try
   {
    string filePath = GetFilepath(productCode);

    if (!System.IO.Directory.Exists(filePath))
    {
     System.IO.Directory.CreateDirectory(filePath);
    }

    foreach (var file in fileCollection)
    {
     string imagePath = filePath + "\\" + file.FileName;
     if (System.IO.File.Exists(imagePath))
     {
      System.IO.File.Delete(imagePath);
     }
     using (FileStream stream = System.IO.File.Create(imagePath))
     {
      await file.CopyToAsync(stream);
      passcount++;

     }
    }
   }
   catch (Exception ex)
   {
    errorcount++;
    response.ErrorMessage = ex.Message;
   }
   response.ResponseCode = 200;
   response.Result = passcount + " Files uploaded &"
                              + errorcount + " files failed";
   return Ok(response);
  }
  [HttpPut("DBMultiUploadImage")]
  public async Task<IActionResult> DBMultiUploadImage(IFormFileCollection fileCollection, string productCode)
  {
   APIResponse response = new APIResponse();
   int passcount = 0;
   int errorcount = 0;
   try
   {
    foreach (var file in fileCollection)
    {
     using (MemoryStream stream = new MemoryStream())
     {
      await file.CopyToAsync(stream);
      _context.TblProductimages.Add(new Repos.Models.TblProductimage()
      {
       Productcode = productCode,
       Productimage = stream.ToArray()
      });
      await _context.SaveChangesAsync();
      passcount++;
     }
    }
   }

   catch (Exception ex)
   {
    errorcount++;
    response.ErrorMessage = ex.Message;
   }
   response.ResponseCode = 200;
   response.Result = passcount + " Files uploaded &"
                    + errorcount + " files failed";
   return Ok(response);
  }


  [HttpGet("GetImage")]
  public async Task<IActionResult> GetImage(string productcode)
  {
   string ImageUrl = string.Empty;
   string hostUrl = $"{this.Request.Scheme}://" +
    $"{this.Request.Host}" +
    $"{this.Request.PathBase}";
   try
   {
    string FilePath = GetFilepath(productcode);
    string imagePath = FilePath + "\\" + productcode + ".png";
    if (System.IO.File.Exists(imagePath))
    {
     ImageUrl = hostUrl + "/Upload/product/" + productcode + "/" + productcode + ".png";
    }
    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    throw;
   }
   return Ok(ImageUrl);
  }
  [HttpGet("Download")]
  public async Task<IActionResult> Download(string productcode)
  {

   try
   {
    string FilePath = GetFilepath(productcode);
    string imagePath = FilePath + "\\" + productcode + ".png";
    if (System.IO.File.Exists(imagePath))
    {
     MemoryStream stream = new MemoryStream();
     using (FileStream fileStream = new FileStream(imagePath, FileMode.Open))
     {
      await fileStream.CopyToAsync(stream);
     }
     stream.Position = 0;
     return File(stream, "image/png", productcode + ".png");
    }
    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    return NotFound();
   }
  }

  [HttpGet("MultiDownload")]
  public async Task<IActionResult> MultiDownload(string fileCode)
  {

   try
   {
    string FilePath = GetFilepath(fileCode);

    if (System.IO.Directory.Exists(FilePath))
    {
     var zipStream = new MemoryStream();
     using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create, true))
     {
      //get all files from the directory (by code of directory)
      var files = System.IO.Directory.GetFiles(FilePath);
      foreach (var file in files)
      {
       var fileName = Path.GetFileName(file);
       //create a new zip entry for each file
       var zipEntry = archive.CreateEntry(fileName,
        System.IO.Compression.CompressionLevel.Fastest);

       //write the file content into the zip entry

       using (var entryStream = zipEntry.Open())
       using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
       {
        await fileStream.CopyToAsync(entryStream);
       }
      }
     }
     zipStream.Position = 0;
     return File(zipStream, "applivation/zip", $"{fileCode}_files.zip");
    }
    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    return NotFound();
   }
  }

  [HttpGet("Remove")]
  public async Task<IActionResult> Remove(string productcode)
  {
   try
   {
    string FilePath = GetFilepath(productcode);
    string imagePath = FilePath + "\\" + productcode + ".png";
    if (System.IO.File.Exists(imagePath))
    {

     System.IO.File.Delete(imagePath);
     return Ok("pass");
    }

    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    return NotFound();
   }
  }
  [HttpGet("MultiRemove")]
  public async Task<IActionResult> MultiRemove(string productcode)
  {
   try
   {
    string FilePath = GetFilepath(productcode);
    if (System.IO.Directory.Exists(FilePath))
    {
     DirectoryInfo directoryInfo = new DirectoryInfo(FilePath);
     FileInfo[] fileInfos = directoryInfo.GetFiles();
     foreach (FileInfo fileInfo in fileInfos)
     {
      fileInfo.Delete();
     }
     return Ok("pass");
    }

    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    return NotFound();
   }
  }

  [HttpGet("RemoveFile")]
  public async Task<IActionResult> RemoveFile(string productcode)
  {
   try
   {

    string FilePath = GetFilepath(productcode);
    if (System.IO.Directory.Exists(FilePath))
    {
     System.IO.Directory.Delete(FilePath, true);
     return Ok("Directory and all files removed succesfully");
    }

    else
    {
     return NotFound();
    }
   }
   catch (Exception ex)
   {

    return NotFound();
   }
  }

  [HttpGet("GetMultiImage")]
  public async Task<IActionResult> GetMultiImage(string productcode)
  {
   List<string> ImageUrl = new List<string>();
   string hostUrl = $"{this.Request.Scheme}://" +
    $"{this.Request.Host}" +
    $"{this.Request.PathBase}";
   try
   {
    string FilePath = GetFilepath(productcode);
    if (System.IO.Directory.Exists(FilePath))
    {
     DirectoryInfo directoryInfo = new DirectoryInfo(FilePath);
     FileInfo[] fileInfos = directoryInfo.GetFiles();
     foreach (FileInfo fileInfo in fileInfos)
     {
      string filename = fileInfo.Name;
      string imagepath = FilePath + "\\" + filename;
      if (System.IO.File.Exists(imagepath))
      {
       string _ImageUrl = hostUrl + "/Upload/product/" + productcode + "/" + filename;
       ImageUrl.Add(_ImageUrl);
      }

      else
      {
       return NotFound();
      }
     }
    }


    else
    {
     return NotFound();
    }

   }
   catch (Exception ex)
   {
    throw;
   }
   return Ok(ImageUrl);
  }

  //for htmpl user 
  [HttpGet("GetDBMultiImage")]
  public async Task<IActionResult> GetDBMultiImage(string productcode)
  {
   List<string> ImageUrl = new List<string>();

   try
   {
    var _porductImage = _context.TblProductimages.Where(
     item => item.Productcode == productcode).ToList();
    if (_porductImage !=null && _porductImage.Count > 0)
    {
     _porductImage.ForEach(item => {
      ImageUrl.Add(Convert.ToBase64String(item.Productimage));
      });
    }
      else
    {
     return NotFound();
    }


   }
   catch (Exception ex)
   {
    throw;
   }
   return Ok(ImageUrl);
  } 
  [HttpGet("RemoveFileByImage")]
  public async Task<IActionResult> RemoveFileByImage(string imageName)
  {
   try
   {
    // Define the root directory where the product folders are stored
    string rootDirectory = _environment.WebRootPath + "\\Upload\\product";

    // Search for the image file within all directories under the root folder
    var files = System.IO.Directory.GetFiles(rootDirectory, imageName, SearchOption.AllDirectories);

    if (files.Length > 0)
    {
     // Get the folder path where the image is found
     string folderPath = Path.GetDirectoryName(files[0]);

     // Check if the folder exists
     if (System.IO.Directory.Exists(folderPath))
     {
      // Delete the folder and all its contents
      System.IO.Directory.Delete(folderPath, true);

      // Return a success message
      return Ok("Folder and image removed successfully.");
     }
     return Ok("Folder and image removed successfully.");

    }
    else
    {
     return NotFound("Image not found.");
    }
    
   }
   catch (Exception ex)
   {
    // Log the exception or handle it appropriately (optional)
    return NotFound("An error occurred while attempting to delete the folder.");
   }
   
  }
  [HttpGet("RemoveImageByName")]
  public async Task<IActionResult> RemoveImageByName(string imageName)
  {
   try
   {
    // Define the root directory where the product folders are stored
    string rootDirectory = _environment.WebRootPath + "\\Upload\\product";

    // Search for the image file within all directories under the root folder
    var files = System.IO.Directory.GetFiles(rootDirectory, imageName, SearchOption.AllDirectories);

    if (files.Length > 0)
    {
     // If the image is found, delete the image
     System.IO.File.Delete(files[0]);

     // Return success response
     return Ok("Image removed successfully.");
    }
    else
    {
     // Return NotFound if the image does not exist
     return NotFound("Image not found.");
    }
   }
   catch (Exception ex)
   {
    // Log the exception for troubleshooting, optional
    return NotFound("An error occurred while attempting to delete the image.");
   }
  }

  [NonAction]
  private string GetFilepath(string productcode)
  {
   return _environment.WebRootPath + "\\Upload\\product\\" + productcode;
  }   

 }
}

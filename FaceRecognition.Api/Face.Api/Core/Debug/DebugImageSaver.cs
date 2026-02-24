using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats;

namespace Face.Api.Core.Debug
{
    public static class DebugImageSaver
    {
        public static void Save(Image<Rgb24> img, string path, IImageEncoder? encoder = null)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("La ruta no puede ser nula o vacía.", nameof(path));
            
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            try
            {
                string? directory = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                if (encoder != null)
                {
                    img.Save(path, encoder);
                }
                else
                {
                    img.Save(path);
                }
            }
            catch (Exception ex)
            {
                // Log o manejar la excepción según sea necesario
                Console.WriteLine($"Error al guardar la imagen: {ex.Message}");
                throw;
            }
        }
    }
}
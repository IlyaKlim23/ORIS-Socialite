using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Socialite.Api.Core.Managers;

/// <summary>
/// Менеджер для работы с изображениями
/// </summary>
public static class ImageManager
{
    /// <summary>
    /// Ориентировочное разрешение для сжатия (чем оно ниже, тем выше степень сжатия)
    /// </summary>
    private const double NeededResolution = 800.0;
    
    /// <summary>
    /// Сжать изображение
    /// </summary>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    public static async Task<Stream> ResizeImage(Stream imageFile)
    {
        using var image = await Image.LoadAsync(imageFile);

        var resPercent = GetResolutionPercent(image);
        
        var width = (int)Math.Round(image.Width * resPercent);
        var height = (int)Math.Round(image.Height * resPercent);

        image.Mutate(x => x.Resize(width, height));

        var outputStream = new MemoryStream();
        await image.SaveAsync(outputStream, new JpegEncoder { Quality = 60 });

        outputStream.Position = 0;
        
        return outputStream;
    }

    private static double GetResolutionPercent(Image image)
    {
        var width = (double)image.Width;
        var height = (double)image.Height;
        
        var widthPercent = NeededResolution / width;
        var heightPercent = NeededResolution / height;

        double result = 1;
        if (widthPercent < 1 || heightPercent < 1)
            result = (widthPercent + heightPercent) / 2.0;

        return result;
    }
}
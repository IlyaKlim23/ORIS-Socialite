using Minio;
using Minio.DataModel.Args;
using Socialite.Api.S3.Interfaces;

namespace Socialite.Api.S3.Services;

/// <inheritdoc />
public class S3Service : IS3Service
{
    private readonly IMinioClient _minioClient;
    private const string BucketName = "socialite";
    private const string NonExistPackage = "non.exist.package";

    public S3Service(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    /// <inheritdoc />
    public async Task CheckS3AvailabilityAsync(CancellationToken cancellationToken)
    {
        var result = !await IsBucketExistAsync(NonExistPackage, cancellationToken);
        if (!result)
            throw new Exception("Сервис S3 недоступен");
    }

    /// <inheritdoc />
    public async Task<bool> IsBucketExistAsync(string bucketIdentifier, CancellationToken cancellationToken)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketIdentifier);

        return await _minioClient.BucketExistsAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddFileInBucketAsync(
        Stream fileStream,
        Guid fileIdentifier,
        string? fileExtension,
        CancellationToken cancellationToken)
    {
        var args = new PutObjectArgs()
            .WithBucket(BucketName)
            .WithStreamData(fileStream)
            .WithObject($"{fileIdentifier}.{fileExtension ?? string.Empty}")
            .WithObjectSize(fileStream.Length);

        await _minioClient.PutObjectAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveFileFromBucketAsync(
        Guid fileIdentifier,
        string? fileExtension,
        CancellationToken cancellationToken)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(BucketName)
            .WithObject($"{fileIdentifier}.{fileExtension ?? string.Empty}");

        try
        {
            await _minioClient.RemoveObjectAsync(args, cancellationToken).ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<MemoryStream?> GetFileFromBucketAsync(
        Guid fileIdentifier,
        string? fileExtension,
        CancellationToken cancellationToken)
    {
        var response = new MemoryStream();
        var args = new GetObjectArgs()
            .WithBucket(BucketName)
            .WithObject($"{fileIdentifier}.{fileExtension ?? string.Empty}")
            .WithCallbackStream(stream => stream.CopyTo(response));

        await _minioClient.GetObjectAsync(args, cancellationToken);

        response.Position = 0;
        return response.Length > 0 ? response : null;
    }
}
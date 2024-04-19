using System.Reactive.Linq;
using Minio;
using Minio.DataModel.Args;
using Socialite.Api.S3.Interfaces;

namespace Socialite.Api.S3.Services;

/// <inheritdoc />
public class S3Service : IS3Service
{
    private readonly IMinioClient _minioClient;

    public S3Service(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    /// <inheritdoc />
    public async Task<bool> IsBucketExistAsync(Guid bucketIdentifier, CancellationToken cancellationToken)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketIdentifier.ToString());

        return await _minioClient.BucketExistsAsync(args, cancellationToken);
    }

    public async Task<bool> IsBucketExistAsync(string bucketIdentifier, CancellationToken cancellationToken)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketIdentifier);

        return await _minioClient.BucketExistsAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateBucketAsync(Guid bucketIdentifier, CancellationToken cancellationToken)
    {
        var args = new MakeBucketArgs()
            .WithBucket(bucketIdentifier.ToString());

        await _minioClient.MakeBucketAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveBucketAsync(Guid bucketIdentifier, CancellationToken cancellationToken)
    {
        var listObjectsArgs = new ListObjectsArgs()
            .WithBucket(bucketIdentifier.ToString());

        var objectNames = await _minioClient
            .ListObjectsAsync(listObjectsArgs, cancellationToken)
            .Select(x => x.Key)
            .ToList();

        if (objectNames.Any())
        {
            var removeObjectsArgs = new RemoveObjectsArgs()
                .WithBucket(bucketIdentifier.ToString())
                .WithObjects(objectNames);

            await _minioClient.RemoveObjectsAsync(removeObjectsArgs, cancellationToken);
        }

        var removeBucketArgs = new RemoveBucketArgs()
            .WithBucket(bucketIdentifier.ToString());

        await _minioClient.RemoveBucketAsync(removeBucketArgs, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddFileInBucketAsync(Stream fileStream, Guid fileIdentifier, Guid bucketIdentifier,
        CancellationToken cancellationToken)
    {
        var args = new PutObjectArgs()
            .WithBucket(bucketIdentifier.ToString())
            .WithStreamData(fileStream)
            .WithObject(fileIdentifier.ToString())
            .WithObjectSize(fileStream.Length);

        await _minioClient.PutObjectAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveFileFromBucketAsync(Guid fileIdentifier, Guid bucketIdentifier, CancellationToken cancellationToken)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(bucketIdentifier.ToString())
            .WithObject(fileIdentifier.ToString());

        await _minioClient.RemoveObjectAsync(args, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<MemoryStream> GetFileFromBucketAsync(Guid fileIdentifier, Guid bucketIdentifier, CancellationToken cancellationToken)
    {
        var response = new MemoryStream();
        var args = new GetObjectArgs()
            .WithBucket(bucketIdentifier.ToString())
            .WithObject(fileIdentifier.ToString())
            .WithCallbackStream(stream => stream.CopyTo(response));

        await _minioClient.GetObjectAsync(args, cancellationToken);

        response.Position = 0;
        return response;
    }
}
namespace Socialite.Api.S3.Interfaces;

/// <summary>
/// Сервис для работы с S3
/// </summary>
public interface IS3Service
{
    /// <summary>
	/// Проверить пакет на существование 
	/// </summary>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакет</param>
	/// <param name="cancellationToken">Токен отмены</param>
	/// <returns>Существует ли</returns>
	public Task<bool> IsBucketExistAsync(Guid bucketIdentifier, CancellationToken cancellationToken);
    
    /// <summary>
	/// Проверить пакет на существование 
	/// </summary>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакет</param>
	/// <param name="cancellationToken">Токен отмены</param>
	/// <returns>Существует ли</returns>
	public Task<bool> IsBucketExistAsync(string bucketIdentifier, CancellationToken cancellationToken);

	/// <summary>
	/// Создать пакет
	/// </summary>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакета</param>
	/// <param name="cancellationToken">Токен отмены</param>
	public Task CreateBucketAsync(Guid bucketIdentifier, CancellationToken cancellationToken);

	/// <summary>
	/// Удалить пакет
	/// </summary>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакета</param>
	/// <param name="cancellationToken">Токен отмены</param>
	/// <returns></returns>
	public Task RemoveBucketAsync(Guid bucketIdentifier, CancellationToken cancellationToken);

	/// <summary>
	/// Положить файл в пакет
	/// </summary>
	/// <param name="fileStream">Файл в виде <see cref="Stream"/></param>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакета</param>
	/// <param name="cancellationToken">Токен отмены</param>
	public Task AddFileInBucketAsync(
		Stream fileStream,
		Guid fileIdentifier,
		Guid bucketIdentifier,
		CancellationToken cancellationToken);

	/// <summary>
	/// Удалить файл из пакета
	/// </summary>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакета</param>
	/// <param name="cancellationToken">Токен отмены</param>
	public Task RemoveFileFromBucketAsync(Guid fileIdentifier,
		Guid bucketIdentifier,
		CancellationToken cancellationToken);

	/// <summary>
	/// Получить файл из пакета
	/// </summary>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="bucketIdentifier">Уникальный идентификатор пакета</param>
	/// <param name="cancellationToken">Токен отмены</param>
	/// <returns>Файл в виде <see cref="MemoryStream"/></returns>
	public Task<MemoryStream> GetFileFromBucketAsync(
		Guid fileIdentifier,
		Guid bucketIdentifier,
		CancellationToken cancellationToken);
}
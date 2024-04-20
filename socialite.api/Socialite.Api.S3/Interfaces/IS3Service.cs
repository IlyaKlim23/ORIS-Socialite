﻿namespace Socialite.Api.S3.Interfaces;

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
	public Task<bool> IsBucketExistAsync(string bucketIdentifier, CancellationToken cancellationToken);

	/// <summary>
	/// Положить файл в пакет
	/// </summary>
	/// <param name="fileStream">Файл в виде <see cref="Stream"/></param>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="fileType">Тип файла</param>
	/// <param name="cancellationToken">Токен отмены</param>
	public Task AddFileInBucketAsync(
		Stream fileStream,
		Guid fileIdentifier,
		string fileType,
		CancellationToken cancellationToken);

	/// <summary>
	/// Удалить файл из пакета
	/// </summary>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="fileType">Тип файла</param>
	/// <param name="cancellationToken">Токен отмены</param>
	public Task RemoveFileFromBucketAsync(
		Guid fileIdentifier,
		string fileType,
		CancellationToken cancellationToken);

	/// <summary>
	/// Получить файл из пакета
	/// </summary>
	/// <param name="fileIdentifier">Уникальный идентификатор файла</param>
	/// <param name="fileType">Тип файла</param>
	/// <param name="cancellationToken">Токен отмены</param>
	/// <returns>Файл в виде <see cref="MemoryStream"/></returns>
	public Task<MemoryStream?> GetFileFromBucketAsync(
		Guid fileIdentifier,
		string fileType,
		CancellationToken cancellationToken);
}
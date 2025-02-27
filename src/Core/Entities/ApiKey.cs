﻿using System.ComponentModel.DataAnnotations;
using Bit.Core.Utilities;

namespace Bit.Core.Entities;

public class ApiKey : ITableObject<Guid>
{
    public Guid Id { get; set; }
    public Guid? ServiceAccountId { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string ClientSecret { get; set; }
    [MaxLength(4000)]
    public string Scope { get; set; }
    [MaxLength(4000)]
    public string EncryptedPayload { get; set; }
    // Key for decrypting `EncryptedPayload`. Encrypted using the organization key.
    public string Key { get; set; }
    public DateTime? ExpireAt { get; set; }
    public DateTime CreationDate { get; internal set; } = DateTime.UtcNow;
    public DateTime RevisionDate { get; internal set; } = DateTime.UtcNow;

    public void SetNewId()
    {
        Id = CoreHelpers.GenerateComb();
    }

    public ICollection<string> GetScopes()
    {
        return CoreHelpers.LoadClassFromJsonData<List<string>>(Scope);
    }
}

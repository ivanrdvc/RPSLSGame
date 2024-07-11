namespace RPSLSGame.Data;

/// <summary>
/// Serves as the base class for all domain entities, including common auditing information
/// like creation and update metadata.
/// </summary>
public abstract class AuditEntity
{
    /// <summary>Gets or sets the date and time the entity was created.</summary>
    /// <remarks>This property is set automatically upon the creation of the entity.</remarks>
    public DateTime CreatedAt { get; set; }

    /// <summary>Gets or sets the date and time the entity was last updated.</summary>
    /// <remarks>This property should be set each time the entity undergoes a significant update.</remarks>
    public DateTime? UpdatedAt { get; set; }
}

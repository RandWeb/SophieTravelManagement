﻿namespace SophieTravelManagement.Domain.ValueObjects;

public record TravelerCheckListId
{
    public Guid Value { get;}

    public TravelerCheckListId(Guid value)
    {
        if (value==Guid.Empty)
        {
            throw new ArgumentNullException();
        }

        this.Value = value;
    }

    public static implicit operator Guid(TravelerCheckListId id) => id.Value;

    public static implicit operator TravelerCheckListId(Guid id) => new(id);
}
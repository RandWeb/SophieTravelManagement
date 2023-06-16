using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstractions.Domain;

namespace SophieTravelManagement.Domain.Events;

public record TravelerItemTaken(TravelerCheckList TravelerCheckList, TravelerItem TravelerItem) : IDomainEvent;
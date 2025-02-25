﻿using Trips.Domain.Enums;

namespace Trips.API.Contracts.Trips;

public record class UpdateTripRequest(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    long RelativeDateTime,
    TripStatus TripStatus);
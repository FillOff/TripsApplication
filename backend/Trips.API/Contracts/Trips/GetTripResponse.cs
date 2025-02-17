﻿using Trips.API.Contracts.Comments;
using Trips.API.Contracts.Images;
using Trips.API.Contracts.Routes;
using Trips.Domain.Enums;
using Trips.Domain.Models;

namespace Trips.API.Contracts.Trips;

public record class GetTripResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    TimeSpan RelativeDateTime,
    TripStatus TripStatus,
    Guid RouteId,
    GetRouteResponse? Route,
    Guid UserId,
    List<GetCommentResponse> Comments,
    List<GetImageResponse> Images);
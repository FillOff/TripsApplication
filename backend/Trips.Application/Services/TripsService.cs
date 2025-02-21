﻿using System.Security.Cryptography;
using Trips.Domain.Enums;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class TripsService : ITripsService
{
    private readonly ITripsRepository _tripsRepository;

    public TripsService(
        ITripsRepository tripsRepository)
    {
        _tripsRepository = tripsRepository;
    }

    public async Task<List<Trip>> GetTripsWithRouteWithImagesWithCommentsAsync()
    {
        return await _tripsRepository.GetWithRouteWithImagesWithComments();
    }

    public async Task<Guid> CreateTripAsync(
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        Guid routeId, 
        Guid userId)
    {
        TimeSpan relativeDateTime = DateTime.UtcNow - startDateTime;
        TripStatus tripStatus = new TripStatus();

        if (relativeDateTime > TimeSpan.Zero)
            tripStatus = TripStatus.Scheduled;
        else
            tripStatus = TripStatus.Started;

        return await _tripsRepository.Add(
            Guid.NewGuid(),
            name, 
            description, 
            startDateTime, 
            endDateTime, 
            relativeDateTime,
            tripStatus, 
            routeId,
            userId);
    }

    public async Task<Guid> UpdateTripAsync(
        Guid id, 
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        TimeSpan relativeDateTime, 
        TripStatus tripStatus)
    {
        return await _tripsRepository.Update(
            id, 
            name, 
            description, 
            startDateTime, 
            endDateTime, 
            relativeDateTime, 
            tripStatus);
    }

    public async Task<Guid> DeleteTripAsync(Guid id)
    {
        return await _tripsRepository.Delete(id);
    }
}

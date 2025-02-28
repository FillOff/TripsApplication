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

    public async Task<List<Trip>> GetTripsWithRouteWithImagesWithCommentsAsync(Guid id)
    {
        var trips =  await _tripsRepository.GetWithRouteWithImagesWithComments();

        trips = trips
            .Where(t =>
                t.TripStatus == TripStatus.Scheduled ||
                t.TripStatus == TripStatus.Started)
            .Where(t => 
                t.UserId == id)
            .ToList();

        return trips;
    }

    public async Task<List<Trip>> GetHistoryTripsWithRouteWithImagesWithCommentsAsync(Guid id)
    {
        var trips =  await _tripsRepository.GetWithRouteWithImagesWithComments();
        trips = trips
            .Where(t =>
                t.TripStatus == TripStatus.Completed ||
                t.TripStatus == TripStatus.Cancelled)
            .Where(t =>
                t.UserId == id)
            .ToList();

        return trips;
    }

    public async Task<List<Trip>> GetTripsWithUsersWithRouteAsync()
    {
        var trips = await _tripsRepository.GetWithUserWithRoute();

        return trips;
    }

    public async Task<Trip?> GetTripWithRouteWithImagesWithCommentsAsync(Guid id)
    {
        var trip = await _tripsRepository.GetById(id);

        return trip;
    }

    public async Task<Guid> CreateTripAsync(
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        Guid routeId, 
        Guid userId)
    {
        long relativeDateTime = (long)(DateTime.UtcNow.AddHours(3) - startDateTime).TotalSeconds;
        TripStatus tripStatus = new TripStatus();

        if (DateTime.UtcNow.AddHours(3) < startDateTime)
            tripStatus = TripStatus.Scheduled;
        else if (DateTime.UtcNow.AddHours(3) >= startDateTime && DateTime.UtcNow.AddHours(3) <= endDateTime)
            tripStatus = TripStatus.Started;
        else
            tripStatus = TripStatus.Completed;

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
        long relativeDateTime, 
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

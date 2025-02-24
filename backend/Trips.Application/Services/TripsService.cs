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

    public async Task<List<Trip>> GetHistoryTripsWithRouteWithImagesWithCommentsAsync()
    {
        var trips =  await _tripsRepository.GetWithRouteWithImagesWithComments();
        trips = trips
            .Where(t =>
                t.TripStatus == TripStatus.Completed ||
                t.TripStatus == TripStatus.Cancelled)
            .ToList();

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
        long relativeDateTime = (long)(DateTime.UtcNow - startDateTime).TotalSeconds;
        TripStatus tripStatus = new TripStatus();

        if (relativeDateTime > 0)
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

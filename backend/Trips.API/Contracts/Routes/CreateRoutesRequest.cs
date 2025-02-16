﻿namespace Trips.API.Contracts.Routes;

public record class CreateRoutesRequest(
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration);
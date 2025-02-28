import { getJwtToken } from "./jwtProvider";

export async function getTrips() {
    const jwtToken = getJwtToken();
    
    const response = await fetch("http://localhost:8080/api/Trips", {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export async function getHistoryTrips() {
    const jwtToken = getJwtToken();
    
    const response = await fetch("http://localhost:8080/api/Trips/history", {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export async function getTrip(id) {
    const jwtToken = getJwtToken();
    
    const response = await fetch(`http://localhost:8080/api/Trips/${id}`, {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export async function getAllTrips() {
    const jwtToken = getJwtToken();
    
    const response = await fetch(`http://localhost:8080/api/Trips/all`, {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export async function createTrip(name, description, startDateTime, endDateTime, routeId) {
    const jwtToken = getJwtToken();
    const data = {
        name: name,
        description: description,
        startDateTime: startDateTime,
        endDateTime: endDateTime,
        routeId: routeId,
    };

    const response = await fetch(`http://localhost:8080/api/Trips`, {
        method: "POST",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data),
    });
}

export async function deleteTrip(id) {
    const jwtToken = getJwtToken();

    const response = await fetch(`http://localhost:8080/api/Trips/${id}`, {
        method: "DELETE",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        },
    });

    return await response.json();
}

export async function updateTrip(id, name, description, startDateTime, endDateTime, relativeDateTime, tripStatus) {
    const jwtToken = getJwtToken();
    
    if (new Date() < new Date(startDateTime))
        tripStatus = 0;
    else if (new Date() >= new Date(startDateTime) && new Date() <= new Date(endDateTime))
        tripStatus = 1;
    else
        tripStatus = 2;

    const data = {
        name: name,
        description: description,
        startDateTime: startDateTime,
        endDateTime: endDateTime,
        relativeDateTime: relativeDateTime,
        tripStatus: tripStatus,
    }

    const response = await fetch(`http://localhost:8080/api/Trips/${id}`, {
        method: "PUT",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
            'Content-Type': "application/json",
        },
        body: JSON.stringify(data)
    });

    return await response.json();
}
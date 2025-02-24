export const getTrips = async () => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    
    const response = await fetch("http://localhost:8080/api/Trips", {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export const getHistoryTrips = async () => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    
    const response = await fetch("http://localhost:8080/api/Trips/history", {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export const getTrip = async (id) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    
    const response = await fetch(`http://localhost:8080/api/Trips/${id}`, {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    return data;
}

export const createTrip = async (name, description, startDateTime, endDateTime, routeId) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
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
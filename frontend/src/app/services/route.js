export const createRoute = async (startPlace, endPlace, duration, length) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    const data = {
        startPlace: startPlace,
        endPlace: endPlace,
        length: length,
        duration: duration
    };

    const response = await fetch(`http://localhost:8080/api/Routes`, {
        method: "POST",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data),
    });

    const routeId = await response.text();
    return routeId;
}

export const updateRoute = async (routeId, startPlace, endPlace, duration, length, tripId) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    const data = {
        startPlace: startPlace,
        endPlace: endPlace,
        length: length,
        duration: duration,
        tripId: tripId,
    };

    const response = await fetch(`http://localhost:8080/api/Routes/${routeId}`, {
        method: "PATCH",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data),
    });

    const routeId = await response.text();
    return routeId;
}
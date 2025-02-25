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

    const routeId = await response.json();
    return routeId;
}

export const updateRoute = async (id, startPlace, endPlace, duration, length) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    const data = {
        startPlace: startPlace,
        endPlace: endPlace,
        length: length,
        duration: duration
    };

    console.log(JSON.stringify(data));
    const response = await fetch(`http://localhost:8080/api/Routes/${id}`, {
        method: "PUT",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data),
    });

    const routeId = await response.json();
    return routeId;
}
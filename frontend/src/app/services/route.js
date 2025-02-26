import { getJwtToken } from "./jwtProvider";

export async function createRoute(startPlace, endPlace, duration, length) {
    const jwtToken = getJwtToken();
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

export async function updateRoute(id, startPlace, endPlace, duration, length) {
    const jwtToken = getJwtToken();
    const data = {
        startPlace: startPlace,
        endPlace: endPlace,
        length: length,
        duration: duration
    };

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
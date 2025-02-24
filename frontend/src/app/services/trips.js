export const getTrips = async () => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    
    const response = await fetch("http://localhost:8080/api/Trips/trips", {
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
    console.log("Received data:", data); 
    return data;
}
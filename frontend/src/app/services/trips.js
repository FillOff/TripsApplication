export const getTrips = async (jwtToken) => {
    const response = await fetch("http://localhost:8080/api/Trips", {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        },
    });

    const data = await response.json();
    console.log(data);
    return data;
}

export const login = async () => {
    const url = 'http://localhost:8080/api/auth/login';

    const data = {
        email: "qwe",
        password: "qwe"
    };

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    });

    return await response.text();
}